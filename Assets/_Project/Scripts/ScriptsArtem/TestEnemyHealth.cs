using UnityEngine;

public class TestEnemyHealth : MonoBehaviour
{
    public int health = 100; // ���� �������� �����
    private TestEnemy enemy;  // ������ �� ��������� TestEnemy

    void Start()
    {
        enemy = GetComponent<TestEnemy>();  // �������� ������ �� TestEnemy
    }
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.D))
        {
            TakeDamage(10); 
        }
    }

    public void TakeDamage(int damage)     // ����� ��������� �����
    {
        health -= damage;
        Debug.Log("���� ������� ����. ������� ��������: " + health);
        if (health <= 0)
        {
            Die();
        }
    }

    private void Die()     // ����� ������
    {
        if (enemy != null)
        {
            enemy.Die();  // �������� ����� Die() �� TestEnemy
        }
        else
        {
            Debug.LogError("�� ������� ����� ��������� TestEnemy �� ���� �������.");
        }
    }
}
