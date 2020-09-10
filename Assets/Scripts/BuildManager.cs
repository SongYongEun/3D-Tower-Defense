using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;
    public Text moneyText;
    private int money = 7;

    public int TurretSpawnMoney = 5;
    public int MagicSpawnMoney = 7;

    public int accessMoney { get { return money; } set { money = value; } }

    private void Awake()
    {

        if (instance != null)
        {
            Debug.LogError("빌드매니저 하나만 쓸것!");
            return;
        }

        instance = this;
    }

    public GameObject gunUnit;
    public GameObject magicUnit;
    public GameObject turret;

}
