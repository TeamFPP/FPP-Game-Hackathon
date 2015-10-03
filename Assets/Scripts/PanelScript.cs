using UnityEngine;
using System.Collections;

public class PanelScript : MonoBehaviour
{
    public Canvas canvas;
    public GameObject player;
    public GameObject[] Cameras;
    public Camera currCam;
    bool isPaused = false;
    int currentCamera = 0;
    // Use this for initialization
    void Start()
    {
        Cameras = GameObject.FindGameObjectsWithTag("CameraTag");
        foreach (GameObject g in Cameras)
        {
            g.GetComponent<Camera>().enabled = false;
        }
        currCam = Camera.main;
        /*player.GetComponentInChildren<Camera>().enabled = false; //also disable player completely
        Cameras[0].GetComponent<Camera>().enabled = true;*/
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0) || Input.GetKey(KeyCode.E))
        {
            RaycastHit hit;
            Ray ray = currCam.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, 1.2f))
            {
               // if (!isPaused)
                //{
                currCam.enabled = false;
                    GetComponent<Renderer>().material.color = Color.blue;

                    player.GetComponentInChildren<Camera>().enabled = false;
                    //Camera.m
                    //Time.timeScale = 0.0f;

                    //Camera.main.Equals(Cameras[0].GetComponent<Camera>());
                    Cameras[currentCamera].GetComponent<Camera>().enabled = true;
                    currCam = Cameras[currentCamera].GetComponent<Camera>();
                    isPaused = true;
                //}
            }
        }
        
    }

    public void NextCamera()
    {
        if (currentCamera < Cameras.Length -1)
        {
            Cameras[currentCamera].GetComponent<Camera>().enabled = false;
            currentCamera++;
            Cameras[currentCamera].GetComponent<Camera>().enabled = true;
            currCam = Cameras[currentCamera].GetComponent<Camera>();
            Update();
        }
        Debug.LogWarning(Cameras[currentCamera].GetComponent<Camera>().name);
    }

    public void PreviousCamera()
    {
        if (currentCamera > 0)
        {
            Cameras[currentCamera].GetComponent<Camera>().enabled = false;
            currentCamera--;
            Cameras[currentCamera].GetComponent<Camera>().enabled = true;
            currCam = Cameras[currentCamera].GetComponent<Camera>();
            Update();
        }
        Debug.LogWarning(Cameras[currentCamera].GetComponent<Camera>().name);
    }

    public void unPause()
    {

    }


}
