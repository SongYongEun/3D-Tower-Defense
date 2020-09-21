using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public enum EnemyType
    {
        Nomal,
        Flying,
        Hard,
        Boss
    }
    public float maxHp = 10f;
    public float hp = 10f;
    public float speed = 10f;
    public int dropMoney = 5;
    public Slider slider;

    private EnemyType et;

    protected Transform target;

    private int wavePointIndex = 0;

    private void Start()
    {
        // 첫번째 시작점 설정
        target = WayPoints.points[0];
    }

    private void Update()
    {
        if (Camera.main.GetComponent<CameraController>().GetCameraEvent()) return;

        if (hp > 0)
        {
            MoveEnemy();
        }
        else
        {
            GameManager.instance.accessMoney += dropMoney;
            Destroy(gameObject);
        }

        slider.value = hp / maxHp;
    }

    // 에너미 움직임 함수
    virtual protected void MoveEnemy()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

        if (Vector3.Distance(target.position, transform.position) <= 0.2f)
        {
            GetNextWayPoint();
        }

        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(transform.rotation, lookRotation, Time.deltaTime * 5).eulerAngles;
        transform.rotation = Quaternion.Euler(0f, rotation.y, 0f);
    }

    // 다음 포인트로 이동
    void GetNextWayPoint()
    {
        // 마지막 포인트일경우 삭제
        if(wavePointIndex >= WayPoints.points.Length - 1)
        {
            GameManager.instance.accessLife -= 1;
            Destroy(gameObject);
            return;
        }
       
        wavePointIndex++;
        target = WayPoints.points[wavePointIndex];
    }

    public void Init(EnemyType _et, float _hp, float _speed)
    {
        et = _et;
        hp = _hp;
        speed = _speed;
    }

    public IEnumerator Slow(float time)
    {
        speed *= 0.5f;

        yield return new WaitForSeconds(time);

        speed *= 2.0f;
    }

}
