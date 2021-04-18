using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootToKegels : MonoBehaviour
{
    [SerializeField] private Vector3 mousePosition;
    [SerializeField] public Camera toLookAt;

    [SerializeField] private float maxDistance;

    [SerializeField] private GameObject crossFire;
    void Update()
    {
        mousePosition = Input.mousePosition;

        Ray ray = toLookAt.ScreenPointToRay(mousePosition);
        Debug.DrawRay(ray.origin, ray.direction * maxDistance, Color.green);
        crossFire.transform.position = ray.origin + (ray.direction * (maxDistance - 3));
    }
}
