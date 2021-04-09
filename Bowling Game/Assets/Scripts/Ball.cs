using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] float ballSpeed;
    [SerializeField] Rigidbody ball;
    [SerializeField] int forceMultipler;
    [SerializeField] private float actualForce;

    [SerializeField] FocusBall ballFocusCamera;
    [SerializeField] public bool onPrepareShoot;

    public float forceApliedX = 0;
    private float forceApliedZ = 0;
    public void PreMoveBall()
    {
        Vector3 moveVec = new Vector3(0, 0, forceApliedZ);
        //--
        ball.AddForce(moveVec);
    }
    public void MoveBall()
    {
        Vector3 moveVec = new Vector3(forceApliedX, 0, 0);
        //--
        ball.AddForce(moveVec);
    }
    public void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            forceApliedX += forceMultipler * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            forceApliedX -= forceMultipler * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            forceApliedZ += 100 * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            forceApliedZ -= 100 * Time.deltaTime;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            onPrepareShoot = false;
            ballFocusCamera.followBall = true;
            if(!onPrepareShoot)
                MoveBall();
        }
        PreMoveBall();
        actualForce = forceApliedX;
    }
}
