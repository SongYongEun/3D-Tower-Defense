using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Upgrade : MonoBehaviour
{
    public Button speedUPButton;
    public Button damageUPButton;
    public Button cellButton;

    private Transform node;
    private Unit turret;

    public void NodeSet(Transform _node)
    {
        speedUPButton.interactable = true;
        damageUPButton.interactable = true;

        node = _node;
        turret = node.gameObject.GetComponent<Node>().GetTurret().GetComponent<Unit>();
        transform.position = new Vector3(node.position.x, 2f, node.position.z);

        speedUPButton.GetComponentInChildren<Text>().text = turret.speedUpPrice.ToString();
        damageUPButton.GetComponentInChildren<Text>().text = turret.damageUpPrice.ToString();
        cellButton.GetComponentInChildren<Text>().text = turret.sellPrice.ToString();

        if (turret.GetIsSpeedUP())
        {
            speedUPButton.interactable = false;
        }

        if (turret.GetIsDamageUP())
        {
            damageUPButton.interactable = false;
        }
    }

    public void SpeedUpButton()
    {
        if (GameManager.instance.accessMoney < turret.speedUpPrice)
        {
            print("돈부족!");
            return;
        }

        GameManager.instance.accessMoney -= turret.speedUpPrice;
        turret.SpeedUp();
        node = null;
        turret = null;
        gameObject.SetActive(false);
    }

    public void DamageUpButton()
    {
        if (GameManager.instance.accessMoney < turret.damageUpPrice)
        {
            print("돈부족!");
            return;
        }

        GameManager.instance.accessMoney -= turret.damageUpPrice;
        turret.DamageUP();
        node = null;
        turret = null;
        gameObject.SetActive(false);
    }

    public void SellButton()
    {
        GameManager.instance.accessMoney += turret.sellPrice;
        AudioManager.instance.EraseAudio(turret.gameObject.GetComponent<AudioSource>());
        Destroy(turret.gameObject);
        node = null;
        turret = null;
        gameObject.SetActive(false);
    }
}
