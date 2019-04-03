using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FSM : MonoBehaviour
{
    private GameObject[] player;
    public GameObject cat;
    public GameObject ball;
    public FSM_AI.CatAIScript cat_ai;
    // Start is called before the first frame update
    private void Start()
    {
        player = GameObject.FindGameObjectsWithTag("RedPlayer");
    }
    // Update is called once per frame
    void Update()
    {
        if (player.Length == 0)
            player = GameObject.FindGameObjectsWithTag("RedPlayer");
        for (int i = 0; i < player.Length; i++)
        {
            if (Vector3.Distance(player[i].transform.position, cat.transform.position) >= 4.0)
            {
                cat_ai.SetState(0);
            }
            else if (Vector3.Distance(player[i].transform.position, cat.transform.position) < 4.0 && Vector3.Distance(player[i].transform.position, cat.transform.position) >= 3.5)
            {
                cat_ai.endpos = player[i].transform.position;
                cat_ai.SetState(1);
            }
            else if (Vector3.Distance(player[i].transform.position, cat.transform.position) < 3.5 && Vector3.Distance(player[i].transform.position, cat.transform.position) >= 3.0)
            {
                cat_ai.endpos = player[i].transform.position;
                cat_ai.SetState(2);
            }
            else if (Vector3.Distance(player[i].transform.position, cat.transform.position) < 3.0 && Vector3.Distance(player[i].transform.position, cat.transform.position) >= 2.5)
            {
                cat_ai.endpos = ball.transform.position;
                cat_ai.SetState(3);
            }
            else if (Vector3.Distance(player[i].transform.position, cat.transform.position) < 2.5)
            {
                cat_ai.endpos = player[i].transform.position;
                cat_ai.SetState(3);
            }
        }
    }
}
