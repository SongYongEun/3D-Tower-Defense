using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{
    public Transform enemyPrefab;

    public Transform spawnPoint;

    public float timeBetweenWaves = 5f;
    private float spawnTime = 2f;

    public Text spawnTimerText;

    private int waveIndex = 0;
    
    private void Update()
    {
        spawnTime -= Time.deltaTime;
        spawnTimerText.text = Mathf.Round(spawnTime).ToString();

        if (spawnTime <=0f)
        {
            StartCoroutine(SpawnWave());
            spawnTime = timeBetweenWaves;
        }
    }

    IEnumerator SpawnWave()
    {
        waveIndex++;

        for(int i=0; i < waveIndex; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(0.5f);
        }
    }

    void SpawnEnemy()
    {
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
    }

}
