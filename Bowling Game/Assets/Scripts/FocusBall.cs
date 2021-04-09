using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FocusBall : MonoBehaviour
{
    [SerializeField] GameObject ball;
    [SerializeField] Vector3 offset;
    [SerializeField] public bool followBall;

    private float timer;
    public Vector3 toMove;
    private void Start()
    {
        toMove = ball.transform.position - offset;
    }
    void LateUpdate()
    {
        toMove = ball.transform.position - offset;

        if (followBall)
        {
            transform.position = Vector3.MoveTowards(transform.position, toMove, 10 * Time.deltaTime);
        }
    }
}
