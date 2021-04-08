using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] float ballSpeed;
    [SerializeField] Rigidbody ball;
    [SerializeField] int forceMultipler;
    [SerializeField] private float actualForce;

    private bool throwBall = false;
    private float forceAplied = 0;
    public void MoveBall()
    {
        Vector3 moveVec = new Vector3(forceAplied, 0, 0);
        //--
        ball.AddForce(moveVec);
    }
    public void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            forceAplied += forceMultipler * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            forceAplied -= forceMultipler * Time.deltaTime;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            MoveBall();
        }
        actualForce = forceAplied;
    }
}
