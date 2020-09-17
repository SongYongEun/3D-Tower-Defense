using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyData
{
    private List<Enemy.EnemyType> enemyData = new List<Enemy.EnemyType>();

    public EnemyData()
    {
        Enemy.EnemyType et;

        // 1 WAVE
        et = Enemy.EnemyType.Nomal;
        enemyData.Add(et);

        // 2 WAVE
        et = Enemy.EnemyType.Flying;
        enemyData.Add(et);

        // 3 WAVE
        et = Enemy.EnemyType.Hard;
        enemyData.Add(et);

        // 4 WAVE
        et = Enemy.EnemyType.Boss;
        enemyData.Add(et);
    }

    public void Print()
    {
        for(int i =0; i < enemyData.Count; ++i)
        {
            Debug.Log(string.Format("[{0}] 웨이브 유닛 타입 : [{1}]", i + 1, enemyData[i].ToString()));
        }
    }

    public int getWaveCount() { return enemyData.Count; }
    public Enemy.EnemyType getEnemyType(int index) { return enemyData[index]; }
}
