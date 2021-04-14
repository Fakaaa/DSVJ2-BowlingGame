using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine;


public class CheckKegels : MonoBehaviour
{
    [SerializeField] public KegelClass[] kegels;
    [SerializeField] KegelsGroup kegelsHit;
    [SerializeField] public int multiplerPoints;

    [SerializeField] public int pointsToTransfer;
    public int amountDown;
    const float maxRotation = 0.35f;
    private void Update()
    {
        amountDown = 0;
        pointsToTransfer = 0;

        if (kegelsHit.hitByBall)
        {
            FindObjectOfType<AudioManager>().Play("HIT");
            kegelsHit.hitByBall = false;
        }

        for (int i = 0; i < kegels.Length; i++)
        {
            if (kegels[i] != null)
            {
                if (!kegels[i].isDown && (kegels[i].transform.rotation.x >= maxRotation || kegels[i].transform.rotation.x <= -maxRotation ||
                    kegels[i].transform.rotation.z >= maxRotation || kegels[i].transform.rotation.z <= -maxRotation) )
                {
                    kegels[i].isDown = true;
                }
                else if(kegels[i].isDown)
                {
                    pointsToTransfer += kegels[i].pointsValue * multiplerPoints;
                    amountDown++;
                }
            }
        }
    }
}
