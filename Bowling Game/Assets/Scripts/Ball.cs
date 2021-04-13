﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Ball : MonoBehaviour
{
    [SerializeField] public float ballSpeed;
    [SerializeField] Rigidbody ball;
    [SerializeField] public int forceMultipler;
    [SerializeField] private float actualForce;

    [SerializeField] FocusBall ballFocusCamera;
    [SerializeField] public bool onPrepareShoot;
    [SerializeField] float speedPreShoot;

    [SerializeField] public float forceLimit;
    [SerializeField] public bool handleForce; //Lets the player choose if want control the force that throws the ball, if false will be random.
    [SerializeField] public float timeUntilResetIfNotHit;
    [SerializeField] public float timer;

    [SerializeField] public int shootsAvaible;
    [SerializeField] public int maxShoots;

    public float forceApliedX = 0;
    public bool ballMoving;
    public bool ballSoundStops;
    private Vector3 initialTransfomr;

    [SerializeField] float limitValueRight;
    [SerializeField] float limitValueLeft;
    [SerializeField] float speedBallSides;
    private bool leftSide;
    private bool rightSide;

    [SerializeField] UI_World uiHandle;
    private void Start()
    {
        initialTransfomr = gameObject.transform.position;
        ballMoving = false;
        ballSoundStops = true;
        leftSide = true;
        rightSide = false;
        shootsAvaible = maxShoots;
    }
    public void Update()
    {
        if (onPrepareShoot && shootsAvaible > 0 && !uiHandle.endGame)
            OnPrepareShoot();

        if (!onPrepareShoot)
            timer += Time.deltaTime;
        if (timer >= timeUntilResetIfNotHit)
            ResetBall();

        if(Input.GetKey(KeyCode.R))
        {
            ResetBall();
        }
    }
    public void FixedUpdate()
    {

        if (!onPrepareShoot && !uiHandle.endGame)
        {
            if (!ballMoving && shootsAvaible > 0)
            {
                ballSoundStops = false;
                MoveBall();
                shootsAvaible--;
            }
            actualForce = forceApliedX;
        }
    }
    public void MoveBall()
    {
        Vector3 moveVec = new Vector3(forceApliedX, 0, 0);
        //--
        ball.AddForce(moveVec);
        //--
        ballMoving = true;

        if (!ballSoundStops)
        {
            FindObjectOfType<AudioManager>().Play("INROLL");
        }
    }
    public void OnPrepareShoot()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            if(handleForce)
                transform.position -= new Vector3(0, 0, speedPreShoot * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            if(handleForce)
                transform.position += new Vector3(0, 0, speedPreShoot * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            if (forceApliedX <= forceLimit && handleForce)
                forceApliedX += (forceMultipler * 6) * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            if (forceApliedX > 0 && handleForce)
                forceApliedX -= (forceMultipler * 6) * Time.deltaTime;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            onPrepareShoot = false;
            ballFocusCamera.followBall = true;
            FindObjectOfType<AudioManager>().Play("INITROLL");
        }

        if(!handleForce)
        {
            if (rightSide)
                transform.position -= new Vector3(0, 0, speedBallSides * Time.deltaTime);
            if (leftSide)
                transform.position += new Vector3(0, 0, speedBallSides * Time.deltaTime);

            if (transform.position.z > -limitValueRight && !rightSide)
            {
                rightSide = false;
                leftSide = true;
            }
            else
                leftSide = false;
            if (transform.position.z < -limitValueLeft && !leftSide)
            {
                leftSide = false;
                rightSide = true;
            }
            else
                rightSide = false;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        ballFocusCamera.followBall = false;
        ballSoundStops = true;
        FindObjectOfType<AudioManager>().Stop("INROLL");
    }
    public void ResetBall()
    {
        ballFocusCamera.followBall = false;
        ballFocusCamera.ResetCameraPos();
        gameObject.transform.position = new Vector3(initialTransfomr.x, initialTransfomr.y ,initialTransfomr.z);
        ball.angularVelocity = Vector3.zero;
        ball.velocity = Vector3.zero;
        ballMoving = false;
        ballSoundStops = true;
        forceApliedX = 0;
        onPrepareShoot = true;
        timer = 0;
    }
}
