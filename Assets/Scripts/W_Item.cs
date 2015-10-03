using UnityEngine;
using System.Collections;

//W_Item - World Item 
//This is the class which will be used for the visual keys

public class W_Item : MonoBehaviour {

    public float RotateRate = 0.5f;

	// Update is called once per frame
	void Update () {
        transform.Rotate(0, RotateRate, 0, Space.Self);
        Debug.DrawRay(transform.position, Vector3.up * 100);
	}

    void OnTriggerEnter(Collider c)
    {
        if (c.gameObject.tag == "Player")
        {
            Debug.Log("Player picking up item");
            c.gameObject.GetComponent<Player>().HoldingItem = true;
            Destroy(this.gameObject);
        }
    }
}
