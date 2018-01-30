using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pong_Player_Keyboard_Controls : MonoBehaviour {
    private bool debug = false;

    [SerializeField]
    float move_speed = 1.0f;

    private float modifier = 1.0f;
    private bool isPlayer01 = true;
    private bool isWestWallCollided = false;        // if colliding with wall, stop moving in direction of west wall
    private bool isEastWallCollided = false;        // if colliding with wall, stop moving in direction of east wall

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
        if (Input.GetKey(KeyCode.A) && isPlayer01)
        {
            if (debug)
                Debug.Log("Pressed player1 left key.");
            moveLeft();
        }

        if (Input.GetKey(KeyCode.D) && isPlayer01)
        {
            if (debug)
                Debug.Log("Pressed player1 right key.");
            moveRight();
        }

        if (Input.GetKey(KeyCode.J) && !isPlayer01)
        {
            if (debug)
                Debug.Log("Pressed player2 left key.");
            moveLeft();
        }

        if (Input.GetKey(KeyCode.L) && !isPlayer01)
        {
            if (debug)
                Debug.Log("Pressed player2 right key.");
            moveRight();
        }

    }

    private void moveLeft()
    {
        // if colliding with west wall, stop moving west
        if (!isWestWallCollided)
        {
            if (move_speed > 0)
                move_speed *= -1.0f;
            transform.Translate(Vector3.forward * move_speed * modifier * Time.deltaTime);
        }
    }
    private void moveRight()
    {
        // if colliding with east wall, stop moving east
        if (!isEastWallCollided)
        {
            if (move_speed < 0)
                move_speed *= -1.0f;
            transform.Translate(Vector3.forward * move_speed * modifier * Time.deltaTime);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        string collided_name = collision.gameObject.name;
        Debug.Log(gameObject.name + " collided with " + collided_name);

        if (collided_name.Contains("west"))
            isWestWallCollided = true;
        if (collided_name.Contains("east"))
            isEastWallCollided = true;
    }

    private void OnCollisionExit(Collision collision)
    {
        string collided_name = collision.gameObject.name;
        Debug.Log(gameObject.name + " no longer collides with " + collided_name);

        if (collided_name.Contains("west"))
            isWestWallCollided = false;
        if (collided_name.Contains("east"))
            isEastWallCollided = false;
    }
}
