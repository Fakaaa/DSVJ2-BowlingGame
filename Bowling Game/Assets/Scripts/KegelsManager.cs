using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KegelsManager : MonoBehaviour
{

    [SerializeField] CheckKegels kegeslPrefaGroup;
    [SerializeField] public CheckKegels kegelsGroup;

    [SerializeField] public float timeUntilKegelDisable;

    [SerializeField] private Ball playerInfo;
    [SerializeField] private int multiplerPointsPerStrike = 1;
    void Awake()
    {
        kegelsGroup = Instantiate(kegeslPrefaGroup);
    }

    public void Reinstaciate()
    {
        if(kegelsGroup != null)
        {
            Destroy(kegelsGroup.gameObject);
            kegelsGroup = Instantiate(kegeslPrefaGroup);
        }
        else
        {
            kegelsGroup = Instantiate(kegeslPrefaGroup);
        }
    }

    void Update()
    {
        GameManager.Get().AddScore(kegelsGroup.pointsToTransfer);
        GameManager.Get().KegelsDown(kegelsGroup.amountDown);

        if (playerInfo.shootsAvaible == playerInfo.maxShoots - 1 && GameManager.Get().GetKegels() == kegelsGroup.kegels.Length)
            kegelsGroup.multiplerPoints = multiplerPointsPerStrike;


        for (int i = 0; i < kegelsGroup.kegels.Length; i++)
        {
            if (kegelsGroup.kegels[i] != null)
            {
                if (kegelsGroup.kegels[i].isDown)
                {
                    kegelsGroup.kegels[i].timerDown += Time.deltaTime;

                    if (kegelsGroup.kegels[i].timerDown >= timeUntilKegelDisable && kegelsGroup.kegels[i].gameObject.activeSelf)
                    {
                        kegelsGroup.kegels[i].gameObject.SetActive(false);
                    }
                }
            }
        }
    }
}
