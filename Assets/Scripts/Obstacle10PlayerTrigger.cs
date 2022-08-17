using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle10PlayerTrigger : MonoBehaviour
{
    public bool _isPlayerTriggered;
    public void Start()
    {
        _isPlayerTriggered = false;
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {

            _isPlayerTriggered = true;
            StartCoroutine(passiveMe(10));

        }

    }

IEnumerator passiveMe(int secs)
{
    
    yield return new WaitForSeconds(secs);
    Destroy(GameObject.FindGameObjectWithTag("ObstacleTarget"));
    }

    
}
