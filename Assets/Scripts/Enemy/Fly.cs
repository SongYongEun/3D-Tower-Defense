using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fly : Enemy
{
    Transform endTransform;
    public float maxHeight;
    public float minHeight;
    bool isUp;

    private void Start()
    {
        endTransform = GameObject.Find("EndPoint").transform;
    }

    void Update()
    {
        if (Camera.main.GetComponent<CameraController>().GetCameraEvent()) return;

        if (hp > 0)
        {
            MoveEnemy();
            UpDown();
        }
        else
        {
            GameManager.instance.accessMoney += dropMoney;
            Destroy(gameObject);
        }
        

        slider.value = hp / maxHp;
    }

    void UpDown()
    {
        if (transform.position.y > maxHeight)
        {
            isUp = false;
        }

        if (transform.position.y < minHeight)
        {
            isUp = true;
        }

        if (!isUp)
        {
            transform.position -= new Vector3(0, 0.01f, 0);
        }
        else
        {
            transform.position += new Vector3(0, 0.01f, 0);
        }
    }

    protected override void MoveEnemy() 
    {
        Vector3 endPos = new Vector3(endTransform.position.x, 1.5f, endTransform.position.z);
        Vector3 dir = endPos - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime);

        if (Vector3.Distance(endPos, transform.position) < 0.2f) 
        {
            GameManager.instance.accessLife -= 1;
            Destroy(gameObject);
        }
    }
}
