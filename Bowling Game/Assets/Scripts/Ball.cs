using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    private void Start()
    {
        ballMoving = false;
    }
    public void MoveBall()
    {
        Vector3 moveVec = new Vector3(forceApliedX, 0, 0);
        //--
        ball.AddForce(moveVec);
        //--
        ballMoving = true;
    }
    public void FixedUpdate()
    {
        if (onPrepareShoot)
            OnPrepareShoot();
        else
        {
            if (!ballMoving)
            {
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
            if(forceApliedX <= forceLimit && handleForce)
                forceApliedX += forceMultipler * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            if(forceApliedX > 0 && handleForce)
                forceApliedX -= forceMultipler * Time.deltaTime;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            onPrepareShoot = false;
            ballFocusCamera.followBall = true;
        }
    }
}
