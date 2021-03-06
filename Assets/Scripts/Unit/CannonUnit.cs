﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonUnit : Unit
{
    [Header("Only CannonUnit")]
    public GameObject cannonPrefab;
    public GameObject shootEffect;
    public Transform cannonPoint;

    // Start is called before the first frame update
    void Start()
    {
        AudioManager.instance.AddEffectAudio(gameObject.GetComponent<AudioSource>());
        isSpeedUpgrade = false;
        isDamageUpgrade = false;
        damage = 4f;
        ani = GetComponent<Animator>();
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        if (Camera.main.GetComponent<CameraController>().GetCameraEvent()) return;

        if (target == null)
            return;

        Vector3 dir = target.transform.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        lookRotation = Quaternion.Euler(lookRotation.eulerAngles.x, lookRotation.eulerAngles.y + 90, lookRotation.eulerAngles.z);
        Vector3 rotation = Quaternion.Lerp(transform.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
        transform.rotation = Quaternion.Euler(0f, rotation.y, 0f);

        if (fireTimer <= 0f)
        {
            CannonShoot();
            fireTimer = fireRate;
        }

        fireTimer -= Time.deltaTime;
    }

    void CannonShoot()
    {
        gameObject.GetComponent<AudioSource>().Play();
        shootEffect.GetComponent<ParticleSystem>().Stop();
        shootEffect.GetComponent<ParticleSystem>().Play();
        GameObject cannonGO = CannonBallObjectPool.GetObject();
        cannonGO.transform.position = cannonPoint.position;
        CannonBall cannonBall = cannonGO.GetComponent<CannonBall>();
        //cannonBall.SetBulletDamage(damage);

        if (cannonBall != null)
        {
            cannonBall.Seek(target.transform);
        }
    }
}
