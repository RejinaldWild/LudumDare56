using UnityEngine;

public class TestEnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;  // ������ �����
    public Transform spawnPoint;    // ����� A ��� ��������� �����
    private GameObject currentEnemy; // ������ �� �������� �����

    void Update()
    {
        EnemySpawn();
    }

    void EnemySpawn() // ����� ����� ��� R
    {
        if (Input.GetKeyDown(KeyCode.R))
        {

            if (currentEnemy == null)
            {
                currentEnemy = Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
            }
        }
    }    
}
