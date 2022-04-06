using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPositionController : MonoBehaviour
{
    private Rigidbody2D rd;
    private Vector2 newPosition;
    private Vector2 center = new Vector2(0, 0);

    //private int counter = 0;

    // Start is called before the first frame update
    void Start()
    {
        rd = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        
        
    }

    void FixedUpdate()
    {
        rd.transform.Translate(newPosition);
    }

    //private void OnBecameInvisible()
    //{
    //    if (rd.position.x > 9)
    //    {
    //        newPosition = new Vector2(-rd.position.x, rd.position.y);
    //    }
    //    else if (rd.position.x < -9)
    //    {
    //        newPosition = new Vector2(-rd.position.x, rd.position.y);
    //    }
    //    else if (rd.position.y > 5)
    //    {
    //        newPosition = new Vector2(rd.position.x, -rd.position.y);
    //    }
    //    else if (rd.position.y < -5)
    //    {
    //        newPosition = new Vector2(rd.position.x, -rd.position.y);
    //    }
    //}
}
