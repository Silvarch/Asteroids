using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;

    private Rigidbody2D rd;
    private Vector2 moveVelocity;

    // Start is called before the first frame update
    void Start()
    {
        rd = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        Vector2 moveInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        moveVelocity = moveInput.normalized * speed;
    }

    void FixedUpdate()
    {
        rd.MovePosition(rd.position + moveVelocity * Time.fixedDeltaTime);

    }
}
