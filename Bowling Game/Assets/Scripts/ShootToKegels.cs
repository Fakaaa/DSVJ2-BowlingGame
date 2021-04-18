using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootToKegels : MonoBehaviour
{
    [SerializeField] private Vector3 mousePosition;
    [SerializeField] public Camera toLookAt;

    [SerializeField] private float maxDistance;

    [SerializeField] private GameObject crossFire;


    [SerializeField] public GameObject kegelGet;

    [SerializeField] float forceUpForPines;
    [SerializeField] int amountPinesExplode;

    [SerializeField] public Ray ray;
    [SerializeField] public Vector3 vecUp;
    [SerializeField] public RaycastHit my_Hit;

    void Update()
    {
        mousePosition = Input.mousePosition;
        vecUp = new Vector3(forceUpForPines, forceUpForPines, 0);

        ray = toLookAt.ScreenPointToRay(mousePosition);
        Debug.DrawRay(ray.origin, ray.direction * maxDistance, Color.green);
        crossFire.transform.position = ray.origin + (ray.direction * (maxDistance - 3));

        if(Input.GetMouseButtonDown(0))
        {
            if(Physics.Raycast(ray, out my_Hit, maxDistance))
            {
                Rigidbody my_RigidHit = my_Hit.collider.gameObject.GetComponent<Rigidbody>();
                my_RigidHit.AddForce(vecUp, ForceMode.Impulse);
            }
        }

    }
}
