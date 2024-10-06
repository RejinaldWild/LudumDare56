using System;
using System.Collections.Generic;
using UnityEngine;

public class TestEnemySpawner : MonoBehaviour
{
    public GameObject[] enemyPrefabs;  // ������ �����
    public Transform[] spawnPoints;
    //public Transform spawnPoint;    // ����� A ��� ��������� �����
    private GameObject currentEnemy; // ������ �� �������� �����
    public float spawnRadius = 2.0f;
    [SerializeField] public float spawnInterval = 3.0f;

    private List<GameObject> enemies = new List<GameObject>();  // ������ ������

    // ��������� ������� ��������� ���������� ������
    public static event Action OnEnemyCountChanged;

    public static event Action<TestEnemy> OnEnemySpawned;

    private void Start()
    {
        InvokeRepeating(nameof(SpawnEnemy), 0f, spawnInterval);
    }

    public void SpawnEnemy()
    {
        int randomIndex = UnityEngine.Random.Range(0, spawnPoints.Length);
        Transform spawnPoint = spawnPoints[randomIndex];

        Vector2 randomPosition = UnityEngine.Random.insideUnitCircle * spawnRadius;
        Vector3 spawnPosition = spawnPoint.position + new Vector3(randomPosition.x, randomPosition.y, 0f);

        int randomEnemyIndex = UnityEngine.Random.Range(0, enemyPrefabs.Length);
        GameObject newEnemy = Instantiate(enemyPrefabs[randomEnemyIndex], spawnPosition, Quaternion.identity);
        enemies.Add(newEnemy);

        TestEnemy enemyComponent = newEnemy.GetComponent<TestEnemy>();
        if (enemyComponent != null)
        {
            OnEnemySpawned?.Invoke(enemyComponent);  // �������� ������� � ������� �����
        }

        // �������� ������� ��������� ���������� ������
        OnEnemyCountChanged?.Invoke();
    }

    public void RemoveEnemy(GameObject enemy)
    {
        enemies.Remove(enemy);

        // �������� ������� ��������� ���������� ������ ��� �������� �����
        OnEnemyCountChanged?.Invoke();
    }

    // ����� ��� ��������� ���������� ������
    public int GetEnemyCount()
    {
        return enemies.Count;
    }
}
