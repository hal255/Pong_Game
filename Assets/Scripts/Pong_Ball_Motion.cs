using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pong_Ball_Motion : MonoBehaviour {
    private bool debug = true;

    public float move_speed = 50.0f;               // velocity of ball

    public bool isScored = false;
    public bool isPaused = false;
    public string scored_target_name;
    public Vector3 start_position;


    // Use this for initialization
    void Start () {
        scored_target_name = "none";
        start_position = new Vector3(0, 0, -5.0f);
        AddRandomForce();
    }

    public Vector2 GetForce()
    {
        float new_x = Random.value * 18 - 9;
        float new_y = Random.value * 6 - 3;
        return new Vector2(new_x, new_y);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        string collided_name = collision.gameObject.name;
        if (debug)
            Debug.Log(gameObject.name + "collided with " + collided_name);
        if (collided_name.Contains("east"))
        {
            scored_target_name = "player1";
            isScored = true;
        }
        else if (collided_name.Contains("west"))
        {
            scored_target_name = "player2";
            isScored = true;
        }
    }

    public void AddRandomForce()
    {
        gameObject.GetComponent<Rigidbody2D>().AddForce(GetForce() * move_speed);
    }

    public bool GetIsScored()
    {
        return isScored;
    }

    public string GetScoredTarget()
    {
        return scored_target_name;
    }

    public void ResetBall()
    {
        gameObject.transform.position = new Vector3(start_position.x, start_position.y, start_position.z);
        gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
//        AddRandomForce();
        scored_target_name = "none";
        isScored = false;
    }

    public void PauseBall()
    {
    }
}
