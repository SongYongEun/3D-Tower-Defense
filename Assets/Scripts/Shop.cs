using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    private Transform node;

    public void NodeSet(Transform _node)
    {
        if(node != null) node.GetComponent<Node>().selectFx.SetActive(false);

        node = _node; 
    }

    public void GunUnitButtonClick()
    {
        if (node == null) return;

        if(BuildManager.instance.accessMoney < BuildManager.instance.TurretSpawnMoney)
        {
            print("돈부족!");
            return;
        }

        BuildManager.instance.accessMoney -= BuildManager.instance.TurretSpawnMoney;

        GameObject turretToBuild = BuildManager.instance.gunUnit;
        Instantiate(turretToBuild, node.position, node.rotation);

        node.GetComponent<Node>().turretSet(turretToBuild);
        node.GetComponent<Node>().selectFx.SetActive(false);
        gameObject.SetActive(false);
    }

    public void MagicUnitButtonClick()
    {
        if (node == null) return;

        if (BuildManager.instance.accessMoney < BuildManager.instance.MagicSpawnMoney)
        {
            print("돈부족!");
            return;
        }

        BuildManager.instance.accessMoney -= BuildManager.instance.MagicSpawnMoney;

        GameObject turretToBuild = BuildManager.instance.magicUnit;
        Instantiate(turretToBuild, node.position, node.rotation);

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
