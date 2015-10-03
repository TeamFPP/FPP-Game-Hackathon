using UnityEngine;
using System.Collections;
using UnityStandardAssets.Characters.FirstPerson;

public class PlayerManager : MonoBehaviour {

    public GameObject[] actors;
    public int currentActor;

    // Use this for initialization
    void Start()
    {
        SwitchActor(0);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
            SwitchActor(0);
        if (Input.GetKeyDown(KeyCode.Alpha2))
            SwitchActor(1);
        if (Input.GetKeyDown(KeyCode.Alpha3))
            SwitchActor(2);

        if (Input.GetKeyDown(KeyCode.L))
            actors[currentActor].GetComponent<Player>().ChangeView(true);
        if (Input.GetKeyDown(KeyCode.K))
            actors[currentActor].GetComponent<Player>().ChangeView(false);

        for (int i = 0; i < actors.Length; i++)
        {
            for (int j = 0; j < actors.Length; j++)
            {
                if (i == j)
                    break;
                else
                {
                    Vector3 ori = actors[i].transform.localPosition;
                    Vector3 dir = actors[j].transform.localPosition - actors[i].transform.localPosition;
                    Ray r = new Ray(ori, dir);
                    RaycastHit hit;
                    if (Physics.Raycast(r, out hit))
                    {
                        Debug.Log("Hit Something");
                        Debug.Log(hit.collider.tag);
                        if (hit.collider.tag == "Player")
                        {
                            actors[i].GetComponent<Player>().ChangeView(true);
                            actors[j].GetComponent<Player>().ChangeView(true);
                        }
                        else
                        {
                            actors[i].GetComponent<Player>().ChangeView(false);
                            actors[j].GetComponent<Player>().ChangeView(false);
                        }
                    }

                }
            }
        }

        Debug.DrawRay(actors[0].transform.position, actors[1].transform.position - actors[0].transform.position, Color.black);
        Debug.DrawRay(actors[1].transform.position, actors[2].transform.position - actors[1].transform.position, Color.black);
        Debug.DrawRay(actors[2].transform.position, actors[0].transform.position - actors[2].transform.position, Color.black);
    }

    void OnDrawGizmos()
    {
        
    }


    void SwitchActor(int id)
    {
        if (id > actors.Length)
            return;

        currentActor = id;
        for (int i = 0; i < actors.Length; i++)
        {
            if (id == i)
                ModifyActor(actors[i], true);
            else
                ModifyActor(actors[i], false);
        }
    }



    void ModifyActor(GameObject g, bool changeTo)
    {
        g.GetComponent<CharacterController>().enabled = changeTo;
        g.GetComponentInChildren<Camera>().enabled = changeTo;
        g.GetComponent<FirstPersonController>().enabled = changeTo;
    }
}
