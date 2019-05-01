using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class ScoreKeeper : NetworkBehaviour
{
    public Text Player1Exp;
    public Text Player2Exp;
    public Text TimeRemaining;
    private int Player1Score;
    private int Player2Score;
    private float Remaining;
    public GameObject explodeP1;
    public GameObject explodeP2;
    // Start is called before the first frame update
    void Start()
    {
        Player1Score = 0;
        Player1Exp.text = "Player 1 Explosions: " + Player1Score;
        Player2Score = 0;
        Player2Exp.text = "Player 2 Explosions: " + Player2Score;
        Remaining = 600.0f;
    }

    // Update is called once per frame
    void Update()
    {

        //Player1Score = GameObject.FindGameObjectsWithTag("explodeP1").Length;
        //Player2Score = GameObject.FindGameObjectsWithTag("explodeP2").Length;


        Remaining -= Time.deltaTime;
        TimeRemaining.text = "Time Remaining: " + Mathf.Floor(Remaining / 60.0f) + ":" + Mathf.Round(Remaining % 60);
        Player1Exp.text = "Player 1 Explosions: " + Player1Score;
        Player2Exp.text = "Player 2 Explosions: " + Player2Score;
        if (Remaining <= 0.0)
        {
            GameOver();
        }
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
    public void P1Explode()
    {
        Player1Score++;
    }

    public void P2Explode()
    {
        Player2Score++;
    }

    void GameOver()
    {
        TimeRemaining.text = "Game Over!";
    }
}
