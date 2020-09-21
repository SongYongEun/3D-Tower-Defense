using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyData
{
    public List<int> spawnCount = new List<int>();  // 스폰될 에너미 개수
    public List<Enemy.EnemyType> enemyData = new List<Enemy.EnemyType>(); // 스폰될 에너미 타입

    public EnemyData()
    {
        Enemy.EnemyType et;
        int ec = 0;

        // 1 WAVE
        et = Enemy.EnemyType.Nomal;
        enemyData.Add(et);
        ec = 5;
        spawnCount.Add(ec);

        // 2 WAVE
        et = Enemy.EnemyType.Nomal;
        enemyData.Add(et);
        ec = 3;
        spawnCount.Add(ec);

        // 3 WAVE
        et = Enemy.EnemyType.Flying;
        enemyData.Add(et);
        ec = 3;
        spawnCount.Add(ec);

        // 4 WAVE
        et = Enemy.EnemyType.Flying;
        enemyData.Add(et);
        ec = 6;
        spawnCount.Add(ec);

        // 5 WAVE
        et = Enemy.EnemyType.Hard;
        enemyData.Add(et);
        ec = 5;
        spawnCount.Add(ec);

        // 6 WAVE
        et = Enemy.EnemyType.Hard;
        enemyData.Add(et);
        ec = 4;
        spawnCount.Add(ec);

        // 7 WAVE
        et = Enemy.EnemyType.Boss;
        enemyData.Add(et);
        ec = 1;
        spawnCount.Add(ec);
    }

    public void Print()
    {
        for(int i =0; i < enemyData.Count; ++i)
        {
            Debug.Log(string.Format("[{0}] 웨이브 유닛 타입 : [{1}]", i + 1, enemyData[i].ToString()));
            Debug.Log(string.Format("[{0}] 웨이브 스폰될 에너미 개수 : [{1}]", i + 1, spawnCount[i].ToString()));
        }
    }

    public int getWaveCount() { return enemyData.Count; } // 웨이브 개수
    public int getSpawnCount(int _waveNum) { return spawnCount[_waveNum]; }
    public int getTotalCount()
    {
        int total = 0;

        for(int i=0; i < enemyData.Count; i++)
        {
            total += spawnCount[i];
        }

        return total;
    }
    public Enemy.EnemyType getEnemyType(int _index) { return enemyData[_index]; }
}
