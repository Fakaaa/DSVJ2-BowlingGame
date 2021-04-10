using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine;


public class CheckKegels : MonoBehaviour
{
    [SerializeField] GameObject[] kegels;
    [SerializeField] Kegels kegelsHit;
    private void Update()
    {
        if(kegelsHit.hitByBall)
        {
            FindObjectOfType<AudioManager>().Play("HIT");
            kegelsHit.hitByBall = false;
        }
    }
}
