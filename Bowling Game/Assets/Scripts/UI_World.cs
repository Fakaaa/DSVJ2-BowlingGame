using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UI_World : MonoBehaviour
{
    [SerializeField] Text shootsRemaining;
    [SerializeField] Text points;
    [SerializeField] Text kegelsRemaining;

    [SerializeField] Ball balInfo;
    [SerializeField] KegelsManager kegelsinfo;

    [SerializeField] Text endMatch;
    void Update()
    {
        points.text = "Points: " + kegelsinfo.pointsGained;
        shootsRemaining.text = "Shoots \n" + balInfo.shootsAvaible;
        kegelsRemaining.text = "Kegels Down \n" + kegelsinfo.kegelsDown;
    }
}
