using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMover : MonoBehaviour
{
    public float speed=3f;
     void FixedUpdate()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;  
    }
}
