using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float MoveSpeed;
    public Rigidbody2D rb;
    private Vector2 MoveDirection;

    // Update is called once per frame
    void Update() //Best for processing inputs as it is called differently depenindig on framerate
    {
        ProcessInputs();
    }

    void FixedUpdate() //called a set amount of times regardless of framerate. best for game physics calculations
    {
        Move();
    }

    void ProcessInputs()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        MoveDirection = new Vector2(moveX, moveY);
    }

    void Move()
    {
        rb.velocity = new Vector2(MoveDirection.x * MoveSpeed, MoveDirection.y * MoveSpeed);
    }

}
