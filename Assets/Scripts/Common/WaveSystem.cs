using UnityEngine;
using System.Collections;

public class WaveSystem : MonoBehaviour
{
    [SerializeField] private Wave[] waves;
    [SerializeField] private EnemySpawner enemySpawner;
    private int currentWaveIndex = -1;

    private int waveTerm = 5;
    private bool isWaitingForNextWave = false;

    public int CurrentWave => currentWaveIndex + 1;
    public int MaxMove => waves.Length;

    private void Update()
    {
        CheckStartWave();
    }

    private void CheckStartWave()
    {
        if (!isWaitingForNextWave && enemySpawner.EnemyList.Count == 0 && currentWaveIndex < waves.Length - 1)
        {
            StartCoroutine(WaitAndStartNextWave());
        }
    }

    private IEnumerator WaitAndStartNextWave()
    {
        isWaitingForNextWave = true;
        Debug.Log("a");
        yield return new WaitForSeconds(waveTerm);
        Debug.Log("b");

        StartWave();
        isWaitingForNextWave = false;
    }

    private void StartWave()
    {
        currentWaveIndex++;
        enemySpawner.CheckSpawnEnemy(waves[currentWaveIndex]);
    }
}


[System.Serializable]
public struct Wave
{
    public float spawnTime;
    public int maxEnemyCount;
    public GameObject[] enemyPrefabs;
}
