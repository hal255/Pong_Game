using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pong_Ball_Motion : MonoBehaviour {
    private bool debug = true;

    public float move_speed = 50.0f;               // velocity of ball

    // Use this for initialization
    void Start () {
        gameObject.GetComponent<Rigidbody2D>().AddForce(GetForce() * move_speed);
    }

    public Vector2 GetForce()
    {
        float new_x = Random.value * 18 - 9;
        float new_y = Random.value * 6 - 3;
        return new Vector2(new_x, new_y);
    }
}
