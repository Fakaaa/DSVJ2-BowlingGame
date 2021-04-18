using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Ball : MonoBehaviour
{
    [SerializeField] public float ballSpeed;
    [SerializeField] Rigidbody ball;
    [SerializeField] public int forceMultipler;

    [SerializeField] FocusBall ballFocusCamera;
    [SerializeField] public bool onPrepareShoot;
    [SerializeField] float speedPreShoot;

    [SerializeField] public float forceLimit;
    [SerializeField] public bool handleForce; //Lets the player choose if want control the force that throws the ball, if false will be an automatic slider.
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

    [SerializeField] public bool shootMode;   

    private bool leftSide;
    private bool rightSide;
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
        if (onPrepareShoot && shootsAvaible > 0 && !GameManager.Get().GetIfMatchEnds() && !shootMode)
            OnPrepareShoot();

        if (!onPrepareShoot)
            timer += Time.deltaTime;
        if (timer >= timeUntilResetIfNotHit)
            Respawn();

        if(Input.GetKey(KeyCode.R))
        {
            Respawn();
        }
    }
    public void FixedUpdate()
    {

        if (!onPrepareShoot && !GameManager.Get().GetIfMatchEnds())
        {
            if (!ballMoving && shootsAvaible > 0 && !shootMode)
            {
                ballSoundStops = false;
                MoveBall();
                shootsAvaible--;
            }
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
    public void Respawn()
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
    public void ResetAllValues()
    {
        ballFocusCamera.ResetCameraPos();
        gameObject.transform.position = new Vector3(initialTransfomr.x, initialTransfomr.y, initialTransfomr.z);
        ball.angularVelocity = Vector3.zero;
        ball.velocity = Vector3.zero;
        ballFocusCamera.followBall = false;
        ballMoving = false;
        ballSoundStops = true;
        leftSide = true;
        rightSide = false;
        onPrepareShoot = true; 
        shootsAvaible = maxShoots;
        forceApliedX = 0;
        timer = 0;
    }
}
