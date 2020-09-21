using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndUI : MonoBehaviour
{
    public static EndUI instance;

    private void Awake()
    {
        if (instance == null) instance = this;
    }

    public GameObject clear;
    public GameObject lose;

    public void RetryButton()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void NextButton()
    {
        Time.timeScale = 1.0f;
        string nextSceneName = "Stage" + SceneManager.GetActiveScene().buildIndex;
        Loading.sceneName = nextSceneName;
        SceneManager.LoadScene("LoadingScene");
    }

    public void MainButton()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("MainScene");
    }
}
