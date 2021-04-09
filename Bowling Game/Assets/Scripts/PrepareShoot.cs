using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PrepareShoot : MonoBehaviour
{
    [SerializeField] Slider sliderUI;
    [SerializeField] Ball ballForce;
    private void Update()
    {
        sliderUI.value = ballForce.forceApliedX;
    }
}
