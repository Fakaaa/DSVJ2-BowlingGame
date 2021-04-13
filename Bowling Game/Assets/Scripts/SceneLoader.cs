using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public Animator transition;
    public float transitionTime = 1f;
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            LoadNextLevel();
        }
    }

    public void LoadNextLevel()
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }

    IEnumerator LoadLevel(int indexScene)
    {
        if (indexScene < 2)
            transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        if(indexScene < 2)
            SceneManager.LoadScene(indexScene);
    }
}
