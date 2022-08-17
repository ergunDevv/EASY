using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemieMoveScript : MonoBehaviour
{
    float moveForce = 5f;
    Rigidbody2D rb;
    private float revSpeed = 300f;
    public GameObject target;
    public Obstacle10PlayerTrigger obstacle10PlayerTrigger;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (obstacle10PlayerTrigger._isPlayerTriggered == true)
        {
            move();
            rb.MoveRotation(rb.rotation + revSpeed * Time.fixedDeltaTime);
        }
        

    }

    void move()
    {

        rb.AddForce(Vector2.left * moveForce);
    }
}
