using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class FinishedServer : NetworkBehaviour

{
    public GameObject explodeP1;
    public GameObject explodeP2;
    private int previousP1 = 0;
    private int previousP2 = 0;

    // Update is called once per frame
    void Update()
    {
        if(GameObject.FindGameObjectsWithTag("Finished").Length > 1)
        {
            
            NetworkManager.singleton.ServerChangeScene("Credits Scene");
        }

        if (GameObject.FindGameObjectsWithTag("explodeP1").Length > 0)
        {
            if(GameObject.FindGameObjectsWithTag("explodeP1").Length > previousP1)
            {
                previousP1 = GameObject.FindGameObjectsWithTag("explodeP1").Length;
                NetworkServer.Spawn(explodeP1);
            }
            
        }

        if (GameObject.FindGameObjectsWithTag("explodeP2").Length > 0)
        {
            if (GameObject.FindGameObjectsWithTag("explodeP2").Length > previousP2)
            {
                previousP2 = GameObject.FindGameObjectsWithTag("explodeP2").Length;
                NetworkServer.Spawn(explodeP2);
            }
                
        }
    }

 

}
