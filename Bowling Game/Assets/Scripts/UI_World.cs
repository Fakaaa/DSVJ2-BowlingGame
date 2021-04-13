using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UI_World : MonoBehaviour
{
    [SerializeField] Text shootsRemaining;
    [SerializeField] Text points;
    [SerializeField] Text kegelsRemaining;

    [SerializeField] Ball ballInfo;
    [SerializeField] KegelsManager kegelsinfo;

    [SerializeField] Text endMatch;

    [HideInInspector]
    public bool endGame = false;
    void Update()
    {
        points.text = "Points: " + kegelsinfo.pointsGained;
        shootsRemaining.text = "Shoots \n" + ballInfo.shootsAvaible;
        kegelsRemaining.text = "Kegels Remaining \n" + (kegelsinfo.kegelsGroup.kegels.Length - kegelsinfo.kegelsDown).ToString();

        if (ballInfo.shootsAvaible == 0 && (kegelsinfo.kegelsGroup.kegels.Length - kegelsinfo.kegelsDown) >= 1)
        {
            endMatch.text = "You Lose! You dont have more shoots. \n Remaining Kegels: " + (kegelsinfo.kegelsGroup.kegels.Length - kegelsinfo.kegelsDown);
            endGame = true;
        }
        else if(ballInfo.shootsAvaible >= 0 && (kegelsinfo.kegelsGroup.kegels.Length - kegelsinfo.kegelsDown) <= 0)
        {
            endMatch.text = "You Win! \n Final Points: " + kegelsinfo.pointsGained;
            endGame = true;
        }
    }
}
