using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("빌드매니저 하나만 쓸것!");
            return;
        }

        instance = this;
    }

    public GameObject standaradTurretPrefab;

    private void Start()
    {
        turretToBuild = standaradTurretPrefab;
    }

    private GameObject turretToBuild;

    public GameObject GetTurretToBuild()
    {
        return turretToBuild;
    }
}
