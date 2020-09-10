using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LazerMake : MonoBehaviour
{
    private LineRenderer lr;
    public Transform gun;
    public Vector3 menu1;
    public Vector3 menu2;

    // Start is called before the first frame update
    void Awake()
    {
        lr = GetComponent<LineRenderer>();
        lr.SetPosition(0, gun.position);
    }

    // Update is called once per frame
    void Update()
    {
        lr.SetPosition(0, gun.position);

        if(TitleManager.selectNum == 0)
            lr.SetPosition(1, menu1);
        else
            lr.SetPosition(1, menu2);
    }


}
