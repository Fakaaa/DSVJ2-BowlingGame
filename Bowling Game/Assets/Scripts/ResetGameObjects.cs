using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetGameObjects : MonoBehaviour
{
    [SerializeField] CheckKegels kegelsGroup;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Kegel")
        {
            if (other.gameObject.activeSelf)
            {
                other.GetComponent<KegelClass>().isDown = true;
                other.gameObject.SetActive(false);
            }
        }
    }
}
