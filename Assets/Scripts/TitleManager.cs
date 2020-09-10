using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TitleManager : MonoBehaviour
{
    public static int selectNum;

    public Image selectImg;

    public void StageButtonClick()
    {
        if(selectNum != 0)
        {
            selectNum = 0;
            selectImg.rectTransform.localPosition = new Vector3(-475, 50, 0);
        }
        else
        {
            SceneManager.LoadScene("Stage1");
        }
    }

    public void SettingButtonClick()
    {
        if (selectNum != 1)
        {
            selectNum = 1;
            selectImg.rectTransform.localPosition = new Vector3(-475, -265, 0);
        }
        else
        {
            //SceneManager.LoadScene("Stage1");
        }
    }



}
