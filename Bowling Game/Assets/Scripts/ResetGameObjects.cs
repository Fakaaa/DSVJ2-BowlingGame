using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetGameObjects : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Kegel")
        {
            if(other.gameObject.activeSelf)
                other.gameObject.SetActive(false);
        }
    }
}
