using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstecle3Script : MonoBehaviour
{
    // Start is called before the first frame update
    public AnimationCurve myCurve;

    void Update()
    {
        transform.position = new Vector3(transform.position.x, myCurve.Evaluate((Time.time % myCurve.length)), transform.position.z);
    }
}
