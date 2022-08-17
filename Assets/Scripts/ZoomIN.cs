using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class ZoomIN : MonoBehaviour
{
    public GameObject animationzoom;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            animationzoom.GetComponent<Animator>().Play("zoomInOut");
        }if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            animationzoom.GetComponent<Animator>().Play("zoomOut");
        }
        
    }


}
