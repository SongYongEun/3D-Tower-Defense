using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonEvents : MonoBehaviour
{
    public GameObject speedButton;
    public GameObject pauseButton;
    public GameObject pauseUI;

    public Sprite speed1xImg;
    public Sprite speed2xImg;

    bool isSpeed;

    public void SpeedButton()
    {
        if(!isSpeed)
        {
            Button btn = speedButton.GetComponent<Button>();
            btn.image.sprite = speed2xImg;
            Time.timeScale = 2f;
            isSpeed = true;
        }
        else
        {
            Button btn = speedButton.GetComponent<Button>();
            btn.image.sprite = speed1xImg;
            Time.timeScale = 1f;
            isSpeed = false;
        }
    }

    public void PauseButton()
    {
        Time.timeScale = 0f;
        pauseUI.SetActive(true);
    }
}
