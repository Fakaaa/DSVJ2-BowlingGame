using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public enum EndState
    {
        Win,
        Lose
    }
    [SerializeField] private EndState state;
    [SerializeField] private bool endMatch;
    [SerializeField] private bool resetAll;

    [SerializeField] private int playerScore;
    [SerializeField] private int kegelsDownInGame;

    [SerializeField] private int auxScore;
    [SerializeField] private int auxKegels;

    [SerializeField] private int scoreMultipler;

    [SerializeField] public bool onMainMenu;            //Scene  Index = 0
    [SerializeField] public bool onMainGameMode;        //Scene  Index = 1
    [SerializeField] public bool onEndScene;            //Scene  Index = 2
    [SerializeField] public bool onSecondGameMode;      //Scene  Index = 3

    [SerializeField] private Ball player;
    [SerializeField] private KegelsManager kegels;
    
    [SerializeField] private SceneLoader scenesRef;
    public static GameManager instance;
    public static GameManager Get()
    {
        return instance;
    }
    private void Awake()
    {
        if(instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
    }
    public void Update()
    {
        scenesRef = FindObjectOfType<SceneLoader>();
        CheckActualScene(scenesRef.actualScene);

        if(endMatch && (onMainGameMode || onSecondGameMode))
        {
            auxScore = playerScore;
            auxKegels = kegelsDownInGame;
            Cursor.visible = true;
            scenesRef.LoadNextLevelCustom(2);
        }
        if (onMainGameMode && resetAll)
        {
            ResetAll();
        }
    }
    public void ResetAll()
    {
        endMatch = false;
        player = FindObjectOfType<Ball>();
        kegels = FindObjectOfType<KegelsManager>();
        player.ResetAllValues();
        kegels.Reinstaciate();
        resetAll = false;
    }
    public void CheckActualScene(int indexScene)
    {
        switch (indexScene)
        {
            case 0:
                onMainMenu = true; onMainGameMode = false; onEndScene = false; onSecondGameMode = false;
                break;
            case 1:
                onMainMenu = false; onMainGameMode = true; onEndScene = false; onSecondGameMode = false;
                break;
            case 2:
                onMainMenu = false; onMainGameMode = false; onEndScene = true; onSecondGameMode = false;
                break;
            case 3:
                onMainMenu = false; onMainGameMode = false; onEndScene = false; onSecondGameMode = true;
                break;
        }
    }
    public void AddScore(int score)
    {
        playerScore = score * scoreMultipler;
    }
    public void KegelsDown(int kegels)
    {
        kegelsDownInGame = kegels;
    }
    public void EndMatch(bool end)
    {
        endMatch = end;
    }
    public void SetResetAll(bool value)
    {
        resetAll = value;
    }
    public void PlayerState(EndState stateIn)
    {
        state = stateIn;
    }
    public int GetActualScore()
    {
        return playerScore;
    }
    public int GetActualKegels()
    {
        return kegelsDownInGame;
    }
    public int GetFinalScore()
    {
        return auxScore;
    }
    public int GetFinalKegels()
    {
        return auxKegels;
    }
    public EndState GetState()
    {
        return state;
    }
    public bool GetIfMatchEnds()
    {
        return endMatch;
    }
}
