using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class FinishScript : NetworkBehaviour
{
    public GameObject explodeP1;
    public GameObject explodeP2;

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
    [Command]
    void CmdDoEndP1()
    {

        GameObject finished = (GameObject)Instantiate(explodeP1);

        NetworkServer.Spawn(finished);


    }
    [Command]
    void CmdDoEndP2()
    {

        GameObject finished = (GameObject)Instantiate(explodeP2);

        NetworkServer.Spawn(finished);
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
        else if (other.gameObject.tag.Contains("player1"))
        {
            Debug.Log("Do Stuff");
            CmdDoEndP1();
        }
        else if (other.gameObject.tag.Contains("player2"))
        {
            Debug.Log("Do Stuff");
            CmdDoEndP2();
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
