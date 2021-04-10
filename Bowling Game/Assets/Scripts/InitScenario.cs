using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitScenario : MonoBehaviour
{
    [SerializeField] GameObject prefabKegels;
    [SerializeField] GameObject floor;

    [HideInInspector]
    public GameObject kegelsGroup;
    [HideInInspector]
    public GameObject scenario;
    void Awake()
    {
        kegelsGroup = Instantiate(prefabKegels);
        scenario = Instantiate(floor);
    }
}
