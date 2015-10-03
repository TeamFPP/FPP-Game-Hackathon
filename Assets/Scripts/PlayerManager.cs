using UnityEngine;
using System.Collections.Generic;
using UnityStandardAssets.Characters.FirstPerson;

public class PlayerManager : MonoBehaviour {

    public List<GameObject> actors;
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

        if (actors.Count > 0)
        {
            bool viewingPlayer = false;
            for (int i = 0; i < actors.Count; i++)
            {
                if (i != currentActor)
                {
                    Vector3 ori = actors[currentActor].transform.position;
                    Vector3 dir = actors[i].transform.position - actors[currentActor].transform.position;
                    Ray r = new Ray(ori, dir);
                    RaycastHit hit;
                    if (Physics.Raycast(r, out hit))
                    {
                        if (hit.collider.tag == "Player")
                        {
                            viewingPlayer = true;
                        }
                    }
                }
            }
            actors[currentActor].GetComponent<Player>().ChangeView(viewingPlayer);
        }

        //Debug.DrawRay(actors[0].transform.position, actors[1].transform.position - actors[0].transform.position, Color.black);
        //Debug.DrawRay(actors[1].transform.position, actors[2].transform.position - actors[1].transform.position, Color.black);
        //Debug.DrawRay(actors[2].transform.position, actors[0].transform.position - actors[2].transform.position, Color.black);
    }

    void SwitchActor(int id)
    {
        if (id > actors.Count)
            return;

        currentActor = id;
        for (int i = 0; i < actors.Count; i++)
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
