using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossEnemy : Enemy
{
    private float Timer = 0;

    private void Start()
    {
        AudioManager.instance.AddEffectAudio(gameObject.GetComponent<AudioSource>());

        target = WayPoints.points[0];

        StartCoroutine(SoundPlay());
    }
    void Update()
    {
        if (Camera.main.GetComponent<CameraController>().GetCameraEvent()) return;

        if (hp > 0)
        {
            MoveEnemy();
        }
        else
        {
            AudioManager.instance.EraseAudio(gameObject.GetComponent<AudioSource>());

            GameManager.instance.accessMoney += dropMoney;
            Destroy(gameObject);
        }

        slider.value = hp / maxHp;
    }

    IEnumerator SoundPlay()
    {
        yield return new WaitForSeconds(1.0f);
        gameObject.GetComponent<AudioSource>().Play();
    }
}
