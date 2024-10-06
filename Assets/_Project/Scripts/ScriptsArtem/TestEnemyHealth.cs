using UnityEngine;

public class TestEnemyHealth : MonoBehaviour
{
    public int health = 100; // тест здоровье врага
    private TestEnemy enemy;  // Ссылка на компонент TestEnemy

    void Start()
    {
        enemy = GetComponent<TestEnemy>();  // Получаем ссылку на TestEnemy
    }
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.D))
        {
            TakeDamage(10); 
        }
    }

    public void TakeDamage(int damage)     // Метод получения урона
    {
        health -= damage;
        Debug.Log("Враг получил урон. Остаток здоровья: " + health);
        if (health <= 0)
        {
            Die();
        }
    }

    private void Die()     // Метод смерти
    {
        if (enemy != null)
        {
            enemy.Die();  // Вызываем метод Die() из TestEnemy
        }
        else
        {
            Debug.LogError("Не удалось найти компонент TestEnemy на этом объекте.");
        }
    }
}
