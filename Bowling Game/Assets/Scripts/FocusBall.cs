using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FocusBall : MonoBehaviour
{
    [SerializeField] GameObject ball;
    [SerializeField] Vector3 offset;
    [SerializeField] public bool followBall;

    private Vector3 initialPosCamera;
    public Vector3 toMove;

    private int maxDistanceDelta = 10;
    private void Start()
    {
        toMove = ball.transform.position - offset;
        initialPosCamera = transform.position;
    }
    void LateUpdate()
    {
        toMove = ball.transform.position - offset;

        if (followBall)
        {
            transform.position = Vector3.MoveTowards(transform.position, toMove, maxDistanceDelta * Time.deltaTime);
        }
    }
    public void ResetCameraPos()
    {
        transform.position = initialPosCamera;
    }
}
