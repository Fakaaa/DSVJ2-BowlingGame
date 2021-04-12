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
        kegelsRemaining.text = "Kegels Remaining \n" + (kegelsinfo.kegelsGroup.kegels.Length - kegelsinfo.kegelsDown).ToString();

        if (balInfo.shootsAvaible <= 0 && (kegelsinfo.kegelsGroup.kegels.Length - kegelsinfo.kegelsDown) >= 1)
        {
            endMatch.text = "You Lose! You dont have more shoots. \n Remaining Kegels: " + (kegelsinfo.kegelsGroup.kegels.Length - kegelsinfo.kegelsDown);
        }
        else if(balInfo.shootsAvaible >= 1 && (kegelsinfo.kegelsGroup.kegels.Length - kegelsinfo.kegelsDown) <= 0)
        {
            endMatch.text = "You Win! \n Final Points: " + kegelsinfo.pointsGained;
        }
    }
}
