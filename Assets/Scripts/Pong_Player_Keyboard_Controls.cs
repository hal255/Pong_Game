using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pong_Player_Keyboard_Controls : MonoBehaviour {
    private bool debug = false;

    public float move_speed = 3.0f;

    public float modifier = 1.0f;
    private bool isPlayer01 = true;
    private bool isNorthWallCollided = false;        // if colliding with wall, stop moving in direction of north wall
    private bool isSouthWallCollided = false;        // if colliding with wall, stop moving in direction of south wall

    // Use this for initialization
    void Start () {
        if (gameObject.name.Contains("2"))
        {
            modifier *= -1;
            isPlayer01 = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W) && isPlayer01)
        {
            if (debug)
                Debug.Log("Pressed player1 left key.");
            moveUp();
        }

        if (Input.GetKey(KeyCode.S) && isPlayer01)
        {
            if (debug)
                Debug.Log("Pressed player1 right key.");
            moveDown();
        }

        if (Input.GetKey(KeyCode.I) && !isPlayer01)
        {
            if (debug)
                Debug.Log("Pressed player2 left key.");
            moveUp();
        }

        if (Input.GetKey(KeyCode.K) && !isPlayer01)
        {
            if (debug)
                Debug.Log("Pressed player2 right key.");
            moveDown();
        }

    }

    private void moveUp()
    {
        // if colliding with west wall, stop moving west
        if (!isNorthWallCollided)
        {
            //if (move_speed > 0)
            //    move_speed *= -1.0f;
            transform.Translate(Vector2.up * move_speed * Time.deltaTime);
        }
    }
    private void moveDown()
    {
        // if colliding with east wall, stop moving east
        if (!isSouthWallCollided)
        {
            //if (move_speed < 0)
            //    move_speed *= -1.0f;
            transform.Translate(Vector2.down * move_speed * Time.deltaTime);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        string collided_name = collision.gameObject.name;
        Debug.Log(gameObject.name + " collided with " + collided_name);

        if (collided_name.Contains("north"))
            isNorthWallCollided = true;
        if (collided_name.Contains("south"))
            isSouthWallCollided = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        string collided_name = collision.gameObject.name;
        Debug.Log(gameObject.name + " no longer collides with " + collided_name);

        if (collided_name.Contains("north"))
            isNorthWallCollided = false;
        if (collided_name.Contains("south"))
            isSouthWallCollided = false;
    }
}
