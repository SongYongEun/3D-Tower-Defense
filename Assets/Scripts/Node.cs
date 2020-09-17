using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    public Color hoverColor;
    public Vector3 positionOffset;
    public GameObject Shop;
    public GameObject Upgrade;

    private GameObject turret;
    public GameObject selectFx;

    private void OnMouseDown()
    {
        GameManager.instance.gameObject.GetComponent<AudioSource>().Play();
        if(turret != null)
        {
            print("들어옴");
            Upgrade.SetActive(true);
            Upgrade.GetComponent<Upgrade>().NodeSet(transform);
        }
        else
        {
            Shop.SetActive(true);
            selectFx.SetActive(true);
            Shop.GetComponent<Shop>().NodeSet(transform);
        }
    }

    public void turretSet(GameObject _turret)
    {
        turret = _turret;
    }

    public GameObject GetTurret() { return turret; }

}
