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

    void LateUpdate()
    {
        points.text = "Points: " + GameManager.Get().GetActualScore();
        shootsRemaining.text = "Shoots \n" + ballInfo.shootsAvaible;
        kegelsRemaining.text = "Kegels Remaining \n" + (kegelsinfo.kegelsGroup.kegels.Length - GameManager.Get().GetActualKegels()).ToString();

        if (ballInfo.shootsAvaible == 0 && (kegelsinfo.kegelsGroup.kegels.Length - GameManager.Get().GetActualKegels()) >= 1)
        {
            GameManager.Get().PlayerState(GameManager.EndState.Lose);
            GameManager.Get().EndMatch(true);
        }
        else if(ballInfo.shootsAvaible >= 0 && (kegelsinfo.kegelsGroup.kegels.Length - GameManager.Get().GetActualKegels()) <= 0)
        {
            GameManager.Get().PlayerState(GameManager.EndState.Win);
            GameManager.Get().EndMatch(true);
        }
    }
}
