using System.Collections;
using UnityEngine;
using UnityEngine.UI;

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
    public Text spawnTimerText;
    public Text waveText;

    private int waveIndex = 0;
    private JsonManager jm;
    private EnemyData ed;

    private void Start()
    {
        jm = JsonManager.instance.GetComponent<JsonManager>();

        ed = jm.LoadJsonFile<EnemyData>(Application.dataPath + "/JsonData/", "1-StageData");
    }

    private void Update()
    {
        if (waveIndex < ed.getWaveCount())
        {
            spawnTimerText.text = Mathf.Round(spawnTime).ToString();
            waveText.text = waveIndex.ToString();

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
        waveIndex++;

        for(int i=0; i < waveIndex; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(1f);
        }

        startSpawn = false;
    }

    void SpawnEnemy()
    {
        ed.getEnemyType(waveIndex - 1);

        switch (ed.getEnemyType(waveIndex-1))
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
    }

}
