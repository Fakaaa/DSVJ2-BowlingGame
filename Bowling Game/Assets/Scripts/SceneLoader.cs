using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public Animator transition;
    public float transitionTime = 1f;

    public int actualScene;
    void Update()
    {
        //if (Input.GetMouseButtonDown(0) && !transition.GetBool("NextScene"))
        //{
        //    LoadNextLevel();
        //}
        actualScene = SceneManager.GetActiveScene().buildIndex;
    }

    public void LoadNextLevelCustom(int levelIndex)
    {
        if(levelIndex <= SceneManager.sceneCountInBuildSettings && levelIndex >= 0)
            StartCoroutine(LoadLevel(levelIndex));

        if(levelIndex == 0) // Main menu
        {
            GameManager.Get().SetResetAll(true);
            GameManager.Get().EndMatch(false);
        }
    }
    public void LoadNextLevel()
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }

    IEnumerator LoadLevel(int indexScene)
    {
        transition.SetBool("NextScene", true);

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(indexScene);

        transition.SetBool("NextScene", false);
    }
}
