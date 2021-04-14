﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KegelsManager : MonoBehaviour
{

    [SerializeField] CheckKegels kegeslPrefaGroup;
    [SerializeField] public CheckKegels kegelsGroup;

    [SerializeField] public int kegelsDown;
    [SerializeField] public float timeUntilKegelDisable;

    [SerializeField] public int pointsGained;

    [SerializeField] private Ball playerInfo;
    [SerializeField] private int multiplerPointsPerStrike;
    void Awake()
    {
        kegelsGroup = Instantiate(kegeslPrefaGroup);
    }

    void Update()
    {
        kegelsDown = kegelsGroup.amountDown;
        pointsGained = kegelsGroup.pointsToTransfer;

        if (playerInfo.shootsAvaible == playerInfo.maxShoots - 1 && kegelsDown == kegelsGroup.kegels.Length)
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
