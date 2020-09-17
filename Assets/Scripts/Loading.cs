using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Loading : MonoBehaviour
{
    public static string sceneName = "Stage1";
    public Slider loadingBar;
    public Text loadingText;


    void Start()
    {
        StartCoroutine(TransitionNextScene(sceneName));
    }

    IEnumerator TransitionNextScene(string name)
    {
        AsyncOperation ao = SceneManager.LoadSceneAsync(name);

        ao.allowSceneActivation = false;

        while(!ao.isDone)
        {
            loadingBar.value = ao.progress;
            loadingText.text = (ao.progress * 100.0f).ToString() + "%";

            if(ao.progress >= 0.9f)
            {
                ao.allowSceneActivation = true;
            }

            yield return null;
        }
    }
}
