using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KegelsGroup : MonoBehaviour
{
    public bool hitByBall;
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
