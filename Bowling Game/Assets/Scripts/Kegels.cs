using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kegels : MonoBehaviour
{
    public bool hitByBall;
    // Start is called before the first frame update
    void Awake()
    {
        hitByBall = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Ball")
            hitByBall = true;
    }
}
