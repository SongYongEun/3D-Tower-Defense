using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunUnit : Unit
{
    [Header("Only GunUnit")]
    public GameObject bulletPrefab;
    public Transform firePoint;

    // Start is called before the first frame update
    void Start()
    {
        isSpeedUpgrade = false;
        isDamageUpgrade = false;
        damage = 4f;
        ani = GetComponent<Animator>();
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
            return;

        Vector3 dir = target.transform.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(transform.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
        transform.rotation = Quaternion.Euler(0f, rotation.y, 0f);

        if (fireTimer <= 0f)
        {
            ani.SetTrigger("Fire");
            fireTimer = fireRate;
        }

        fireTimer -= Time.deltaTime;
    }

    // 애니메이션 이벤트로 실행
    void Shoot()
    {
        //Instantiate(muzzleEffect, firePoint.position, Quaternion.identity);
        GameObject bulletGO = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Bullet bullet = bulletGO.GetComponent<Bullet>();
        bullet.SetBulletDamage(damage);

        if (bullet != null)
        {
            bullet.Seek(target);
        }
    }
}
