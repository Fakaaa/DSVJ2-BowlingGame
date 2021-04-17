using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_End : MonoBehaviour
{
    [SerializeField] public Text points;
    [SerializeField] public Text kegelsDown;
    [SerializeField] public Text endState;

    void Update()
    {
        points.text = "Points: " + GameManager.Get().GetFinalScore();
        kegelsDown.text = "Kegels Down: " + GameManager.Get().GetFinalKegels();
        switch (GameManager.Get().GetState())
        {
            case GameManager.EndState.Win:
                endState.text = "You Win!";
                break;
            case GameManager.EndState.Lose:
                endState.text = "You Lose!";
                break;
        }
    }
}
