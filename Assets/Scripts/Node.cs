using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    public Color hoverColor;
    public Vector3 positionOffset;
    public GameObject Shop;

    private GameObject turret;
    public GameObject selectFx;

    private void OnMouseDown()
    {
        if(turret != null)
        {
            print("Can't build there!");
            return;
        }

        Shop.SetActive(true);
        selectFx.SetActive(true);
        Shop.GetComponent<Shop>().NodeSet(transform);
    }

    public void turretSet(GameObject _turret)
    {
        turret = _turret;
    }

}
