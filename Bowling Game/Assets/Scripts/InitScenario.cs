using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitScenario : MonoBehaviour
{
    [SerializeField] GameObject floor;

    [HideInInspector]
    public GameObject scenario;
    void Awake()
    {
        scenario = Instantiate(floor);
    }
}
