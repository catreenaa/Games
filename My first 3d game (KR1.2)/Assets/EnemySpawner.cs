using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab; // Префаб врага
    public float spawnInterval = 5f; // Интервал спавна врагов
    public float difficultyMultiplier = 1.05f; // Увеличение сложности со временем
    public Transform[] spawnPoints; // Точки спавна

    private float nextSpawnTime;

    void Update()
    {
        if (Time.time >= nextSpawnTime)
        {
            SpawnEnemy();
            nextSpawnTime = Time.time + spawnInterval;
            spawnInterval *= difficultyMultiplier; // Увеличение сложности
        }
    }

    void SpawnEnemy()
    {
        int spawnIndex = Random.Range(0, spawnPoints.Length);
        Instantiate(enemyPrefab, spawnPoints[spawnIndex].position, Quaternion.identity); // Спавн врага в случайной точке
    }
}