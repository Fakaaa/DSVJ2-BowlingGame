using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PrepareShoot : MonoBehaviour
{
    [SerializeField] Slider sliderUI;
    [SerializeField] Ball ballForce;

    private bool goingUp;
    private bool goingDown;
    private void Start()
    {
        goingDown = false;
        goingUp = true;
    }
    private void Update()
    {
        if(!ballForce.handleForce && !ballForce.ballMoving)
        {
            if (goingUp)
                ballForce.forceApliedX += (ballForce.forceMultipler * ballForce.ballSpeed) * Time.deltaTime;
            if(goingDown)
                ballForce.forceApliedX -= (ballForce.forceMultipler * ballForce.ballSpeed) * Time.deltaTime;

            if (ballForce.forceApliedX < ballForce.forceLimit && !goingDown)
            {
                goingDown = false;
                goingUp = true;
            }
            else
                goingUp = false;
            if (ballForce.forceApliedX >= 0 && !goingUp)
            {
                goingUp = false;
                goingDown = true;
            }
            else
                goingDown = false;
        }
        sliderUI.value = ballForce.forceApliedX;
    }
}
