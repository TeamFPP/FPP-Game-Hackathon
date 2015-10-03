using UnityEngine;
using System.Collections;

public class Button : MonoBehaviour {

    public GameObject parent;

    void OnTriggerEnter(Collider c)
    {
        if (c.gameObject.tag == "Player")
        {
            if (parent.GetComponent<Door>() != null)
                parent.GetComponent<Door>().interactDoor();
            if (parent.GetComponent<TimedDoor>() != null)
                parent.GetComponent<TimedDoor>().interactDoor();
        }
    }
    
}
