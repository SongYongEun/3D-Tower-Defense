using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    protected GameObject target;

    [Header("Atrributes")]
    public int sellPrice = 5;
    public int speedUpPrice = 5;
    public int damageUpPrice = 5;
    public float range = 15f;
    public float fireRate = 1f;
    protected float damage;
    protected float fireTimer = 0f;

    [Header("Setup")]
    public GameObject rangeUI;
    public string enemyTag = "Enemy";
    public float turnSpeed = 10f;

    protected Animator ani;
    protected bool isSpeedUpgrade = false;
    protected bool isDamageUpgrade = false;

    protected virtual void UpdateTarget()
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
        else
        {
            target = null;
        }

    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }

    public void SpeedUp()
    {
        isSpeedUpgrade = true;
        fireRate *= 0.5f;
    }

    public void DamageUP()
    {
        isDamageUpgrade = true;
        damage *= 1.5f;
    }

    public bool GetIsSpeedUP() { return isSpeedUpgrade; }
    public bool GetIsDamageUP() { return isDamageUpgrade; }
}
