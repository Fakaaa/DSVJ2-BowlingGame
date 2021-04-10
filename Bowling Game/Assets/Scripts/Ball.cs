using System.Collections;
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

    public float forceApliedX = 0;
    public bool ballMoving;
    public bool ballSoundStops;
    private void Start()
    {
        ballMoving = false;
        ballSoundStops = true;
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
            //FindObjectOfType<AudioManager>().Stop("INITROLL");
            FindObjectOfType<AudioManager>().Play("INROLL");
        }
    }
    public void FixedUpdate()
    {
        if (onPrepareShoot)
            OnPrepareShoot();
        else
        {
            if (!ballMoving)
            {
                ballSoundStops = false;
                MoveBall();
            }
            actualForce = forceApliedX;
        }
    }
    public void OnPrepareShoot()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position -= new Vector3(0, 0, speedPreShoot * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += new Vector3(0, 0, speedPreShoot * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            if (forceApliedX <= forceLimit && handleForce)
                forceApliedX += forceMultipler * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            if (forceApliedX > 0 && handleForce)
                forceApliedX -= forceMultipler * Time.deltaTime;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            onPrepareShoot = false;
            ballFocusCamera.followBall = true;
            FindObjectOfType<AudioManager>().Play("INITROLL");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        ballFocusCamera.followBall = false;
        ballSoundStops = true;
        FindObjectOfType<AudioManager>().Stop("INROLL");
    }
}
