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
    [SerializeField] public float timeUntilResetIfNotHit;
    [SerializeField] public float timer;

    public float forceApliedX = 0;
    public bool ballMoving;
    public bool ballSoundStops;
    private Vector3 initialTransfomr;
    private void Start()
    {
        initialTransfomr = gameObject.transform.position;
        ballMoving = false;
        ballSoundStops = true;
    }
    public void Update()
    {
        if (onPrepareShoot)
            OnPrepareShoot();

        if (!onPrepareShoot)
            timer += Time.deltaTime;
        if (timer >= timeUntilResetIfNotHit)
            ResetBall();
    }
    public void FixedUpdate()
    {

        if (!onPrepareShoot)
        {
            if (!ballMoving)
            {
                ballSoundStops = false;
                MoveBall();
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
