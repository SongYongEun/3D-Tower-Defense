using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordUnit : Unit
{
    [Header("Only GunUnit")]
    public GameObject slashEffect;

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
        Vector3 rotation = Quaternion.Lerp(transform.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
        transform.rotation = Quaternion.Euler(0f, rotation.y, 0f);

        if (fireTimer <= 0f)
        {
            ani.SetTrigger("Attack");
            fireTimer = fireRate;
            gameObject.GetComponent<AudioSource>().Play();
        }

        fireTimer -= Time.deltaTime;
    }

    // 애니메이션 이벤트로 실행
    void Attack()
    {
        target.GetComponent<Enemy>().hp -= damage;

        slashEffect.GetComponent<ParticleSystem>().Stop();
        slashEffect.transform.position = target.transform.position;
        slashEffect.GetComponent<ParticleSystem>().Play();
    }
}
