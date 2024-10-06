using UnityEngine;

public class TestEnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;  // Префаб врага
    public Transform spawnPoint;    // Точка A для появления врага
    private GameObject currentEnemy; // Ссылка на текущего врага

    void Update()
    {
        EnemySpawn();
    }

    void EnemySpawn() // спавн врага при R
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
