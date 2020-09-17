using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public Text moneyText;
    public Text lifeText;
    public GameObject upgradeUI;
    private int life = 10;
    private int money = 50;

    public int GunUnitSpawnMoney = 5;
    public int MagicUnitSpawnMoney = 7;

    public GameObject gunUnit;
    public GameObject magicUnit;
    public GameObject cannonUnit;

    public int accessLife { get { return life; } set { life = value; lifeText.text = value.ToString(); } }
    public int accessMoney { get { return money; } set { money = value; moneyText.text = value.ToString(); } }

    private void Awake()
    {

        if (instance != null)
        {
            Debug.LogError("빌드매니저 하나만 쓸것!");
            return;
        }

        instance = this;

        moneyText.text = money.ToString();
        lifeText.text = life.ToString();
    }
}
