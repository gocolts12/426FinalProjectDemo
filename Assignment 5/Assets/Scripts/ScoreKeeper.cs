﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreKeeper : MonoBehaviour
{
    public Text Player1Exp;
    public Text Player2Exp;
    public Text TimeRemaining;
    private int Player1Score;
    private int Player2Score;
    private float Remaining;

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
        Remaining -= Time.deltaTime;
        TimeRemaining.text = "Time Remaining: " + Mathf.Floor(Remaining / 60.0f) + ":" + Mathf.Round(Remaining % 60);
        Player1Exp.text = "Player 1 Explosions: " + Player1Score;
        Player2Exp.text = "Player 2 Explosions: " + Player2Score;
        if (Remaining <= 0.0)
        {
            GameOver();
        }
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
