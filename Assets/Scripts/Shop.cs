using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    private Transform node;
    
    public void NodeSet(Transform _node)
    {
        if(node == _node)
        {
            node.GetComponent<Node>().selectFx.SetActive(false);
            gameObject.SetActive(false);
            node = null;
            return;
        }
        if(node != null) node.GetComponent<Node>().selectFx.SetActive(false);

        node = _node; 
    }

    public void GunUnitButtonClick()
    {
        if (node == null) return;

        if(GameManager.instance.accessMoney < GameManager.instance.GunUnitSpawnMoney)
        {
            print("돈부족!");
            return;
        }

        GameManager.instance.accessMoney -= GameManager.instance.GunUnitSpawnMoney;

        GameObject turretToBuild = Instantiate(GameManager.instance.gunUnit, node.position, node.rotation);

        node.GetComponent<Node>().turretSet(turretToBuild);
        node.GetComponent<Node>().selectFx.SetActive(false);
        gameObject.SetActive(false);
    }

    public void MagicUnitButtonClick()
    {
        if (node == null) return;

        if (GameManager.instance.accessMoney < GameManager.instance.MagicUnitSpawnMoney)
        {
            print("돈부족!");
            return;
        }

        GameManager.instance.accessMoney -= GameManager.instance.MagicUnitSpawnMoney;

        GameObject turretToBuild = Instantiate(GameManager.instance.magicUnit, node.position, node.rotation);

        node.GetComponent<Node>().turretSet(turretToBuild);
        node.GetComponent<Node>().selectFx.SetActive(false);
        gameObject.SetActive(false);
    }

    public void CannonUnitButtonClick()
    {
        if (node == null) return;

        if (GameManager.instance.accessMoney < GameManager.instance.CannonUnitSpawnMoney)
        {
            print("돈부족!");
            return;
        }

        GameManager.instance.accessMoney -= GameManager.instance.CannonUnitSpawnMoney;

        GameObject turretToBuild = Instantiate(GameManager.instance.cannonUnit, node.position, node.rotation);

        node.GetComponent<Node>().turretSet(turretToBuild);
        node.GetComponent<Node>().selectFx.SetActive(false);
        gameObject.SetActive(false);
    }

    public void SwordUnitButtonClick()
    {
        if (node == null) return;

        if (GameManager.instance.accessMoney < GameManager.instance.SwordUnitSpawnMoney)
        {
            print("돈부족!");
            return;
        }

        GameManager.instance.accessMoney -= GameManager.instance.SwordUnitSpawnMoney;

        GameObject turretToBuild = Instantiate(GameManager.instance.swordUnit, node.position, node.rotation);

        node.GetComponent<Node>().turretSet(turretToBuild);
        node.GetComponent<Node>().selectFx.SetActive(false);
        gameObject.SetActive(false);
    }

    public void IceUnitButtonClick()
    {
        if (node == null) return;

        if (GameManager.instance.accessMoney < GameManager.instance.IceUnitSpawnMoney)
        {
            print("돈부족!");
            return;
        }

        GameManager.instance.accessMoney -= GameManager.instance.IceUnitSpawnMoney;

        GameObject turretToBuild = Instantiate(GameManager.instance.iceUnit, node.position, node.rotation);

        node.GetComponent<Node>().turretSet(turretToBuild);
        node.GetComponent<Node>().selectFx.SetActive(false);
        gameObject.SetActive(false);
    }

    public void CancleButtonClick()
    {
        node.GetComponent<Node>().selectFx.SetActive(false);
        node = null;
        gameObject.SetActive(false);
    }
}
