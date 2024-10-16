using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab; // ������ �����
    public float spawnInterval = 5f; // �������� ������ ������
    public float difficultyMultiplier = 1.05f; // ���������� ��������� �� ��������
    public Transform[] spawnPoints; // ����� ������

    private float nextSpawnTime;

    void Update()
    {
        if (Time.time >= nextSpawnTime)
        {
            SpawnEnemy();
            nextSpawnTime = Time.time + spawnInterval;
            spawnInterval *= difficultyMultiplier; // ���������� ���������
        }
    }

    void SpawnEnemy()
    {
        int spawnIndex = Random.Range(0, spawnPoints.Length);
        Instantiate(enemyPrefab, spawnPoints[spawnIndex].position, Quaternion.identity); // ����� ����� � ��������� �����
    }
}