using UnityEngine;
using System.Collections;

public class PanelOperator : MonoBehaviour {

    Renderer rend;

	// Use this for initialization
	void Start () {
        rend = GetComponent<Renderer>();

	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButton(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, 100.0f))
            {
                gameObject.GetComponent<Renderer>().material.color = Color.black;
                
            }
        }
	}
}
