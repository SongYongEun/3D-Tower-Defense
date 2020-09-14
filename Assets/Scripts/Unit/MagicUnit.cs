using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DigitalRuby.LightningBolt;

public class MagicUnit : MonoBehaviour
{
    private Transform target;

    [Header("Atrributes")]

    public float range = 15f;
    public float fireRate = 1f;
    private float fireTimer = 0f;

    [Header("Setup")]

    public string enemyTag = "Enemy";
    public float turnSpeed = 10f;

    public GameObject lazerEffect;

    Animator ani;

    void Start()
    {
        ani = GetComponent<Animator>();
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }

    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestsDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < shortestsDistance)
            {
                shortestsDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        if (nearestEnemy != null && shortestsDistance <= range)
        {
            target = nearestEnemy.transform;
        }
   
    }

    void Update()
    {
        if (target == null)
        {
            lazerEffect.SetActive(false);
            return;
        }

        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(transform.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
        transform.rotation = Quaternion.Euler(0f, rotation.y, 0f);

        if (fireTimer <= 0f)
        {
            ani.SetTrigger("Attack");
            fireTimer = 1f / fireRate;
        }

        fireTimer -= Time.deltaTime;

    }


    // 애니메이션 이벤트로 실행
    public void LazerOn()
    {
        // 번개 이펙트 ON
        if (target == null) return;
        GameObject temp = target.gameObject;
        lazerEffect.GetComponent<LightningBoltScript>().EndObject = temp;
        lazerEffect.SetActive(true);
    }

    public void LazerOff()
    {
        lazerEffect.GetComponent<LightningBoltScript>().EndObject = null;
        lazerEffect.SetActive(false);
        fireTimer = 1f / fireRate;
        target = null;
    }


    IEnumerator attackCoroutine(float _damage, float _delayTime)
    {
        
        yield return new WaitForSeconds(_delayTime);
    }


    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
