using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMoverHorizontal : MonoBehaviour
{
    //adjust this to change speed
    [SerializeField]
    float speed = 5f;
    //adjust this to change how high it goes
    [SerializeField]
    float height = 0.5f;


    Vector3 pos;

    public void Start()
    {

        pos = transform.position;

    }

    void Update()
    {
        //calculate what the new Y position will be
        float newX = Mathf.Sin(Time.time * speed) * height + pos.x;
        //set the object's Y to the new calculated Y
        transform.position = new Vector3(newX, transform.position.y, transform.position.z);

    }
}
