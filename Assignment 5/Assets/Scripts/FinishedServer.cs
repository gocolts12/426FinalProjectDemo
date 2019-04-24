using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class FinishedServer : NetworkBehaviour

{


    // Update is called once per frame
    void Update()
    {
        if(GameObject.FindGameObjectsWithTag("Finished").Length > 1)
        {
            Debug.Log("Theres Two");
            NetworkManager.singleton.ServerChangeScene("Credits Scene");
        }
    }

 

}
