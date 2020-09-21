using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBall : MonoBehaviour
{
    private float damage = 2;
    private float speed = 2;
    private Transform target; // 타겟 위치
    public float firingAngle = 45.0f;
    public float gravity = 5.8f;
    public GameObject colEffect;

    public Transform Projectile; // 발사체 위치


    //void Start()
    //{
    //    StartCoroutine(SimulateProjectile());
    //}

    public void Seek(Transform _target)
    {
        target = _target;
        StartCoroutine(SimulateProjectile());
    }


    IEnumerator SimulateProjectile()
    {
        Projectile.position = transform.position;

        float distance = Vector3.Distance(Projectile.position, target.position + Vector3.forward);

        float velocity = distance / (Mathf.Sin(2 * firingAngle * Mathf.Deg2Rad) / gravity);

        float Vx = Mathf.Sqrt(velocity) * Mathf.Cos(firingAngle * Mathf.Deg2Rad);
        float Vy = Mathf.Sqrt(velocity) * Mathf.Sin(firingAngle * Mathf.Deg2Rad);

        float flightDuration = distance / Vx;

        Projectile.rotation = Quaternion.LookRotation(target.position - Projectile.position);

        float elapseTime = 0;

        while (elapseTime < flightDuration)
        {

            Projectile.Translate(0, (Vy - (gravity * elapseTime)) * Time.deltaTime, Vx * Time.deltaTime);

            elapseTime += Time.deltaTime;

            yield return null;
        }

        StartCoroutine(ColiderActive());
    }

    IEnumerator ColiderActive()
    {
        gameObject.GetComponent<MeshRenderer>().enabled = false;
        GameObject effectIns = Instantiate(colEffect, transform.position, transform.rotation);
        Destroy(effectIns, 2f);
        yield return new WaitForSeconds(0.2f);
        gameObject.GetComponent<SphereCollider>().enabled = true;
        yield return new WaitForSeconds(0.3f);
        gameObject.GetComponent<SphereCollider>().enabled = false;
        gameObject.GetComponent<MeshRenderer>().enabled = true;
        CannonBallObjectPool.ReturnObject(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Enemy"))
        {
            other.gameObject.GetComponent<Enemy>().hp -= damage;
        }
    }

}
