using UnityEngine;
using System.Collections;

public class TimedDoor : MonoBehaviour
{

    public float TimeOpen;
    public float Timer;
    public bool Paused;

    public PlayerManager pMan;
    public float moveSpeed;
    public Vector3 doorStart;
    public Vector3 doorEnd;
    public GameObject door;
    public bool doorClosed = true;
    public enum DoorMovement
    {
        Opening,
        Closing,
        None
    };
    public DoorMovement move;

    void Start()
    {
        pMan = GameObject.Find("GameManager").GetComponent<PlayerManager>();
    }

    public void interactDoor()
    {
        if (doorClosed)
        {
            move = DoorMovement.Opening;
            Debug.Log("Opening Door");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!doorClosed)
        {
            Timer += Time.deltaTime;
            if (Timer > TimeOpen)
            {
                Timer = 0;
                move = DoorMovement.Closing;
            }
        }

        if (move == DoorMovement.None)
        { }
        else if (move == DoorMovement.Closing)
        {
            door.transform.Translate(new Vector3(0, -moveSpeed, 0) * Time.deltaTime);
            if (door.transform.position.y < doorStart.y)
            {
                Vector3 d = door.transform.position;
                d.y = doorStart.y;
                door.transform.position = d;
                move = DoorMovement.None;
                doorClosed = true;
            }
        }
        else if (move == DoorMovement.Opening)
        {
            door.transform.Translate(new Vector3(0, moveSpeed, 0) * Time.deltaTime);
            if (door.transform.position.y > doorEnd.y)
            {
                Vector3 d = door.transform.position;
                d.y = doorEnd.y;
                door.transform.position = d;
                move = DoorMovement.None;
                doorClosed = false;
            }
        }

    }
}
