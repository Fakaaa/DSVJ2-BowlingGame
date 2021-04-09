using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine;


public class CheckKegels : MonoBehaviour
{
    private AudioSource toPlay;
    [SerializeField] GameObject[] kegels;
    [SerializeField] Kegels kegelsHit;
    private void Start()
    {
        toPlay = gameObject.GetComponent<AudioSource>();
    }
    private void Update()
    {
        if(kegelsHit.hitByBall)
        {
            toPlay.Play();
            kegelsHit.hitByBall = false;
        }
    }
}
