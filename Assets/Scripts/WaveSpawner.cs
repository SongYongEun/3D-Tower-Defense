using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WaveSpawner : MonoBehaviour
{
    // 생성할 에너미 프리팹들
    [Header("Enemy Prefabs")]
    public Transform normalEnemyPrefab;
    public Transform hardEnemyPrefab;
    public Transform flyEnemyPrefab;
    public Transform bossEnemyPrefab;

    [Header("Atrributes")]
    public Transform spawnPoint;
    private bool startSpawn = false;
    public float timeBetweenWaves = 5f;
    private float spawnTime = 2f;
    
    [Header("UI Set")]
    public Text waveText;

    private int waveIndex = 0;
    private JsonManager jm;
    private EnemyData ed;

    private void Start()
    {
        jm = JsonManager.instance.GetComponent<JsonManager>();

        if(Loading.sceneName == "Stage1")
        {
             ed = jm.LoadJsonFile<EnemyData>(Application.dataPath + "/JsonData/", "1-StageData");
        }
        else if (Loading.sceneName == "Stage2")
        {
            ed = jm.LoadJsonFile<EnemyData>(Application.dataPath + "/JsonData/", "2-StageData");
        }
        else if (Loading.sceneName == "Stage3")
        {
            ed = jm.LoadJsonFile<EnemyData>(Application.dataPath + "/JsonData/", "3-StageData");
        }
    }

    private void Update()
    {
        if (waveIndex < ed.getWaveCount())
        {
            waveText.text = (waveIndex+1).ToString();

            if (spawnTime <= 0f)
            {
                StartCoroutine(SpawnWave());
                spawnTime = timeBetweenWaves;
                startSpawn = true;
            }

            if(!startSpawn)
                spawnTime -= Time.deltaTime;
        }
    }

    IEnumerator SpawnWave()
    {

        for(int i=0; i < ed.getSpawnCount(waveIndex); i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(1f);
        }

        startSpawn = false;
        yield return new WaitForSeconds(3f);
        waveIndex++;
    }

    void SpawnEnemy()
    {
        ed.getEnemyType(waveIndex);

        switch (ed.getEnemyType(waveIndex))
        {
            case Enemy.EnemyType.Nomal:
                Instantiate(normalEnemyPrefab, spawnPoint.position, spawnPoint.rotation);
                break;
            case Enemy.EnemyType.Flying:
                Instantiate(flyEnemyPrefab, new Vector3(spawnPoint.position.x , 1.1f, spawnPoint.position.z), spawnPoint.rotation);
                break;
            case Enemy.EnemyType.Hard:
                Instantiate(hardEnemyPrefab, spawnPoint.position, spawnPoint.rotation);
                break;
            case Enemy.EnemyType.Boss:
                Instantiate(bossEnemyPrefab, spawnPoint.position, spawnPoint.rotation);
                break;
        }

        if(waveIndex == ed.getWaveCount() -1)
        {
            Camera.main.GetComponent<CameraController>().SetCameraEvent(true);
        }
    }

}
