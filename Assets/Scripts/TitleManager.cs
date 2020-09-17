using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class TitleManager : MonoBehaviour
{
    public static int selectNum;

    public Image selectImg;
    public GameObject StageUI;

    public void StageButtonClick()
    {
        if(selectNum != 0)
        {
            selectNum = 0;
            selectImg.rectTransform.localPosition = new Vector3(-475, 50, 0);
        }
        else
        {
            StageUI.SetActive(true);
            //SceneManager.LoadScene("Stage1");
        }
    }

    public void ExitButtonClick()
    {
        if (selectNum != 1)
        {
            selectNum = 1;
            selectImg.rectTransform.localPosition = new Vector3(-475, -265, 0);
        }
        else
        {
            Application.Quit();
            Debug.Log("나가기");
        }
    }

    public void StageClick()
    {
        string ButtonName = EventSystem.current.currentSelectedGameObject.name;

        Debug.Log(ButtonName);
        Loading.sceneName = ButtonName;
        SceneManager.LoadScene("LoadingScene");
    }


}
