using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Galaxy : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        RotateLeft();
    }

    void RotateLeft()
    {
        transform.Rotate(Vector3.back);
    }

}
