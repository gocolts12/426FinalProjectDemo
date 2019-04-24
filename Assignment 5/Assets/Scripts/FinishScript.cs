using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class FinishScript : NetworkBehaviour
{


    public GameObject finishedPrefab;
    private int popped = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
   [Command]
   void CmdDoEnd()
    {

        GameObject finished = (GameObject)Instantiate(finishedPrefab);

        NetworkServer.Spawn(finished);
    }
    [Command]
    void CmdDontEnd()
    {
        

    }

    private void OnTriggerEnter(Collider other)
    {
        if (!isLocalPlayer)
        {
            return;
        }
        if (other.gameObject.tag.Contains("Finish"))
        {
            if(popped == 0)
            {
                CmdDoEnd();
                popped = 1;
            }
            
            
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (!isLocalPlayer)
        {
            return;
        }
        if (other.gameObject.tag.Contains("Finish"))
        {
            CmdDontEnd();
        }
    }
}
