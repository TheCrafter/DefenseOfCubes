using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{
    [SerializeField] Enemy enemyPrefab;
    [SerializeField] Transform spawnPoint;
    [SerializeField] float timeBetweenWaves = 5f;
    [SerializeField] float timeBetweenEnemySpawns = 0.2f;
    [SerializeField] Text waveCountdownText;

    private float countdown = 2f; // seconds
    private int waveIndex = 0;

    private void Update()
    {
        if (countdown <= 0f)
        {
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
        }

        countdown -= Time.deltaTime;
        countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);

        waveCountdownText.text = string.Format("{0:00.00}", countdown);
    }

    private IEnumerator SpawnWave()
    {
        waveIndex++;
        for (int i = 0; i < waveIndex; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(timeBetweenEnemySpawns);
        }
    }

    private void SpawnEnemy()
    {
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
    }
}
