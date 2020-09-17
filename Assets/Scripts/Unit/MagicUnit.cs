using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DigitalRuby.LightningBolt;

public class MagicUnit : Unit
{
    [Header("Only MagicUnit")]
    public float attackDelay = 0.2f;
    private bool isAttack;
    public GameObject lazerEffect;
    private IEnumerator coroutine;

    void Start()
    {
        isSpeedUpgrade = false;
        isDamageUpgrade = false;
        damage = 1;
        ani = GetComponent<Animator>();
        if(!isAttack)
        {
            InvokeRepeating("UpdateTarget", 0f, 1f);
        }
        coroutine = attackCoroutine(damage, attackDelay);
    }

    override protected void UpdateTarget()
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
            target = nearestEnemy;
        }
   
    }

    void Update()
    {
        if (target == null)
        {
            lazerEffect.SetActive(false);
            return;
        }

        Vector3 dir = target.transform.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(transform.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
        transform.rotation = Quaternion.Euler(0f, rotation.y, 0f);

        if (fireTimer <= 0f)
        {
            isAttack = true;
            ani.SetTrigger("Attack");
            fireTimer = fireRate;
        }

        if (!isAttack)
            fireTimer -= Time.deltaTime;

    }


    // 애니메이션 이벤트로 실행
    public void LazerOn()
    {
        // 번개 이펙트 ON
        if (target == null) return;
        StartCoroutine(coroutine);
        isAttack = true;
        GameObject temp = target.gameObject;
        lazerEffect.GetComponent<LightningBoltScript>().EndObject = temp;
        lazerEffect.SetActive(true);
    }

    public void LazerOff()
    {
        StopCoroutine(coroutine);
        isAttack = false;
        lazerEffect.SetActive(false);
        lazerEffect.GetComponent<LightningBoltScript>().EndObject = null;
        target = null;
    }


    IEnumerator attackCoroutine(float _damage, float _delayTime)
    {
        while (true)
        {
            target.GetComponent<Enemy>().hp -= _damage;
            //if (target.GetComponent<Enemy>().hp <= 0)
            //{
            //    Destroy(target);
            //    target = null;
            //    StopCoroutine(coroutine);
            //}
            yield return new WaitForSeconds(_delayTime);
        }
    }
}
