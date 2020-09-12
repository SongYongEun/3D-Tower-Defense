using UnityEngine;

public class WayPoints : MonoBehaviour
{
    // 길목 전역 사용
    public static Transform[] points;

    // 길목들을 배열에 담기
    private void Awake()
    {
        points = new Transform[transform.childCount];

        for (int i =0; i < points.Length; i++)
        {
            points[i] = transform.GetChild(i);
        }
    }
}
