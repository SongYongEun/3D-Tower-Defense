using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    public Color hoverColor;
    public Vector3 positionOffset;

    private GameObject turret;

    private Renderer rend;
    private Color startColor;
    private Color notBuildColor;

    private void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
        notBuildColor = Color.red;
    }

    private void OnMouseDown()
    {
        if(turret != null)
        {
            print("Can't build there!");
            return;
        }

        GameObject turretToBuild = BuildManager.instance.GetTurretToBuild();
        turret = Instantiate(turretToBuild, transform.position + positionOffset, transform.rotation);
        rend.material.color = notBuildColor;
    }

    private void OnMouseEnter()
    {
        if (turret != null) rend.material.color = notBuildColor;
        else rend.material.color = hoverColor;
    }

    void OnMouseExit()
    {
        rend.material.color = startColor;
    }
}
