using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pong_Ball_Motion : MonoBehaviour {
    private bool debug = true;

    public float move_speed = 10.0f;               // velocity of ball

    public Vector2 prev_pos = new Vector2(0, 0);
    public Vector2 next_pos = new Vector2(0, 0);



    // Use this for initialization
    void Start () {
        gameObject.GetComponent<Rigidbody2D>().AddForce(GetForce() * move_speed);
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnCollisionEnter(Collision collision)
    {
        string collider_name = collision.gameObject.name;
        if(collider_name != "Floor")
        {
            Debug.Log("Pong ball collided with " + collider_name);
            FindNext(true);
        }
    }

    public void FindNext(bool isCollided)
    {
        next_pos.x = 2 * transform.position.x - prev_pos.x;
        next_pos.y = 2 * transform.position.y - prev_pos.y;
        //// if collided, move in opposite direction of prev_pos
        //if (isCollided)
        //{
        //    // if prev_x is left of current_x, move right
        //    if (prev_pos.x < transform.position.x)
        //        next_pos.x = 2 * transform.position.x - prev_pos.x;
        //    else if (prev_pos.x > transform.position.x)
        //        next_pos.x = -2 * transform.position.x - prev_pos.x;
        //    else
        //        next_pos.x = prev_pos.x;

        //    // if prev_y is bottom of current_y, move up
        //    if (prev_pos.y < transform.position.y)
        //        next_pos.y = 2 * transform.position.y - prev_pos.y;
        //    else if (prev_pos.y > transform.position.y)
        //        next_pos.y = -2 * transform.position.y - prev_pos.y;
        //    else
        //        next_pos.y = prev_pos.y;
        //}
        //// else, apply the midpoint formula
        //else
        //{
        //    next_pos.x = 2 * transform.position.x - prev_pos.x;
        //    next_pos.y = 2 * transform.position.y - prev_pos.y;
        //}
    }

    public void SetPrevPos(bool isNew)
    {
        if (isNew)
        {
            prev_pos.x = Random.value * 18 - 9;
            prev_pos.y = Random.value * 6 - 3;
        }
        else
            prev_pos = transform.position;
    }

    public Vector2 GetForce()
    {
        float new_x = Random.value * 18 - 9;
        float new_y = Random.value * 6 - 3;
        return new Vector2(new_x, new_y);
    }
}
