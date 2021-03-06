﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager_ScoreTracker : MonoBehaviour {

    public float reset_wait_time = 1.0f;
    public Pong_Ball_Motion pong_ball;

    public Text player1_score;
    public Text player2_score;

    private IEnumerator coroutine;

    // Use this for initialization
    void Start()
    {
        player1_score = GameObject.FindGameObjectWithTag("p1_score").GetComponent<Text>();
        player2_score = GameObject.FindGameObjectWithTag("p2_score").GetComponent<Text>();
        pong_ball = GameObject.FindGameObjectWithTag("pong_ball").GetComponent<Pong_Ball_Motion>();
        coroutine = WaitAndReset(reset_wait_time);
        StartCoroutine(coroutine);
    }

    // Update is called once per frame
    void Update () {
		if (pong_ball.GetIsScored())
        {
            if (pong_ball.GetScoredTarget().Contains("1"))
                player1_score.text = UpdateScore(player1_score);
            else if (pong_ball.GetScoredTarget().Contains("2"))
                player2_score.text = UpdateScore(player2_score);

            pong_ball.ResetBall();
            coroutine = WaitAndReset(reset_wait_time);
            StartCoroutine(coroutine);
        }
	}

    private string UpdateScore(Text player)
    {
        int x = 0;
        if (int.TryParse(player.text, out x))
            x++;
        return x + "";
    }

    private IEnumerator WaitAndReset(float wait_time)
    {
        yield return new WaitForSeconds(wait_time);
        pong_ball.AddRandomForce();
    }
}
