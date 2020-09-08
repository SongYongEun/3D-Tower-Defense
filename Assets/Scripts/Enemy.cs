﻿using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 10f;

    private Transform target;
    private int wavePointIndex = 0;

    private void Start()
    {
        target = WayPoints.points[0];
    }

    private void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

        if (Vector3.Distance(target.position, transform.position) <= 0.2f)
        {
            GetNextWayPoint();
        }
    }

    void GetNextWayPoint()
    {
        if(wavePointIndex >= WayPoints.points.Length - 1)
        {
            Destroy(gameObject);
            return;
        }
       
        wavePointIndex++;
        target = WayPoints.points[wavePointIndex];
    }
}
