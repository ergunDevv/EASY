using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle7DissapearingGround : MonoBehaviour
{

    public float timeToTogglePlatform = 2;
    public float currentTime = 0;
    public bool enabledd = true;


    // Start is called before the first frame update
    void Start()
    {
        enabledd = true;
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;
        if (currentTime>=timeToTogglePlatform)
        {
            currentTime = 0;
            TogglePlatform();
            
        }
    }

    void TogglePlatform()
    {
        enabledd = !enabledd;
        foreach (Transform child in gameObject.transform)
        {
            if (child.tag == "YellowGround")
            {
                child.gameObject.SetActive(enabledd);
            }
            
        }

    }
}
