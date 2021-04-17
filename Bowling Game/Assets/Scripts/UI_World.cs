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
    void LateUpdate()
    {
        points.text = "Points: " + GameManager.Get().GetScore();
        shootsRemaining.text = "Shoots \n" + ballInfo.shootsAvaible;
        kegelsRemaining.text = "Kegels Remaining \n" + (kegelsinfo.kegelsGroup.kegels.Length - GameManager.Get().GetKegels()).ToString();

        if (ballInfo.shootsAvaible == 0 && (kegelsinfo.kegelsGroup.kegels.Length - GameManager.Get().GetKegels()) >= 1)
        {
            GameManager.Get().PlayerState(GameManager.EndState.Lose);
            //endMatch.text = "You Lose! You dont have more shoots. \n Remaining Kegels: " + (kegelsinfo.kegelsGroup.kegels.Length - GameManager.Get().GetKegels());   
            GameManager.Get().EndMatch(true);
        }
        else if(ballInfo.shootsAvaible >= 0 && (kegelsinfo.kegelsGroup.kegels.Length - GameManager.Get().GetKegels()) <= 0)
        {
            GameManager.Get().PlayerState(GameManager.EndState.Win);
            //endMatch.text = "You Win! \n Final Points: " + GameManager.Get().GetScore();
            GameManager.Get().EndMatch(true);
        }
    }
}
