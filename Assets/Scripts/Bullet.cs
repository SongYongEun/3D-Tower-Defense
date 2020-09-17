using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private GameObject target;

    private float damage = 2;
    public float speed = 70f;
    public GameObject ImpactEffect;

    public void Seek(GameObject _target)
    {
        target = _target;
    }

    void Update()
    {
        if (Camera.main.GetComponent<CameraController>().GetCameraEvent()) return;

        if (target == null)
        {
            BulletObjectPool.ReturnObject(gameObject);
            return;
        }

        Vector3 dir = target.transform.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        if(dir.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;
        }

        transform.Translate(dir.normalized * distanceThisFrame, Space.World);
    }

    void HitTarget()
    {
        target.GetComponent<Enemy>().hp -= damage;

        GameObject effectIns = Instantiate(ImpactEffect, transform.position, transform.rotation);
        Destroy(effectIns, 2f);

        BulletObjectPool.ReturnObject(gameObject);
    }

    public void SetBulletDamage(float _damage) { damage = _damage; }
}
