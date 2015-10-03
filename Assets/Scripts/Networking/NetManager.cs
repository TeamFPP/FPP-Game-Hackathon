using UnityEngine;
using System.Collections;

public class NetManager : MonoBehaviour {

    public string hostIP = "localhost";
    public int hostPort = 27015;

    public GameObject playerPrefab;
    public NetworkView view;

	// Use this for initialization
	void Start () {
	
	}
	
    void OnGUI()
    {
        if (Network.peerType == NetworkPeerType.Disconnected)
        { 
            if (GUI.Button(new Rect(0, 0, 100, 50), "Host Game"))
            {
                Network.InitializeServer(3, hostPort, true);
                Network.logLevel = NetworkLogLevel.Full;
            }
            hostIP = GUI.TextField(new Rect(0, 60, 150, 40), hostIP);
            if (GUI.Button(new Rect(0, 110, 100, 50), "Join Game"))
            {
                Network.Connect(hostIP, 27015);
            }
        }
    }

    [RPC]
    void SpawnPlayer()
    {
        GameObject[] spawns = GameObject.FindGameObjectsWithTag("SpawnPoint");
        GameObject player = (GameObject)Network.Instantiate(playerPrefab, spawns[Random.Range(0, spawns.Length)].transform.position, Quaternion.identity, 0);
        GameObject.Find("PlayerManager").GetComponent<PlayerManager>().actors.Add(player);
    }

    void OnServerInitialized()
    {
        //view.RPC("SpawnPlayer", RPCMode.AllBuffered);
    }

    void OnPlayerConnected()
    {
        
    }
}
