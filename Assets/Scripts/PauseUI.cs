using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseUI : MonoBehaviour
{
    public GameObject settingUI;

    public void ConinueButton()
    {
        Time.timeScale = 1.0f;
        gameObject.SetActive(false);
    }

    public void RestartButton()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void SettingButton()
    {
        settingUI.SetActive(true);
    }

    public void OKButton()
    {
        settingUI.SetActive(false);
    }

}
