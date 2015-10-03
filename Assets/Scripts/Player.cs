using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    public Material OpaqueMat;
    public Material TransperentMat;
    public GameObject helmetScreen;
   
    public void ChangeView(bool caught)
    {
        if (caught)
            helmetScreen.GetComponent<MeshRenderer>().material = OpaqueMat;
        else
            helmetScreen.GetComponent<MeshRenderer>().material = TransperentMat;
    }
}
