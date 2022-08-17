using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleForce : MonoBehaviour
{
    public Rigidbody2D rigid;


    public void Start()
    {
       
        
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            
            rigid.AddForce(transform.right * -180);
            Debug.Log("hetyy");
        }

    }
}
