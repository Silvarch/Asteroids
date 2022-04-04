using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Written by JP
public class Player_Controller_Script : MonoBehaviour
{
    // Start is called before the first frame update
    public float moveSpeed;
    public float rotationSpeed;

    private Rigidbody2D rd;
    private Vector2 moveVelocity;
    private float rotationVelocity;
    private float radians;
    

    // Start is called before the first frame update
    void Start()
    {
        rd = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    private void Update()
    {
        radians = rd.rotation * (Mathf.PI / 180);
        float rotationInput = Input.GetAxisRaw("Horizontal");
        float moveInput = Input.GetAxisRaw("Vertical");
        if (moveInput == 1)
        {
            Vector2 moveVector = new Vector2(Mathf.Cos(radians + (Mathf.PI / 2)), Mathf.Sin(radians + (Mathf.PI / 2)));
            moveVelocity = moveVector.normalized * moveSpeed;
        }

        rotationVelocity = rotationInput * rotationSpeed * -1;
    }

    private void FixedUpdate()
    {
        rd.MovePosition(rd.position + moveVelocity * Time.fixedDeltaTime);
        rd.MoveRotation(rd.rotation + rotationVelocity * Time.fixedDeltaTime);

    }
}
//Written by JP
