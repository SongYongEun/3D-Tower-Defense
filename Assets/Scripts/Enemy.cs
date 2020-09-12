using UnityEngine;

public class Enemy : MonoBehaviour
{
    public enum EnemyType
    {
        Normal,
        Flying,
        Hard,
        Boss
    }

    [SerializeField]
    public float hp = 10f;
    public float speed = 10f;
    private EnemyType et;

    private Transform target;
    private int wavePointIndex = 0;

    private void Start()
    {
        // 첫번째 시작점 설정
        target = WayPoints.points[0];
    }

    private void Update()
    {
        MoveEnemy();
    }

    // 에너미 움직임 함수
    void MoveEnemy()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

        if (Vector3.Distance(target.position, transform.position) <= 0.2f)
        {
            GetNextWayPoint();
        }
    }

    // 다음 포인트로 이동
    void GetNextWayPoint()
    {
        // 마지막 포인트일경우 삭제
        if(wavePointIndex >= WayPoints.points.Length - 1)
        {
            // HP 감소 함수 추가해야함
            Debug.Log("ADD HP Minus Function");
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
}
