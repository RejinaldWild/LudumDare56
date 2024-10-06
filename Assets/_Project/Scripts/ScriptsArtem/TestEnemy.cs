using System;
using UnityEngine;

public class TestEnemy : MonoBehaviour
{
    
    public static event Action OnEnemyDeath; // ��������� ������� ��� ������ �����
    


    public void Die()
    {
        
        if (OnEnemyDeath != null)
        {
            Debug.Log("���� �������. ������� ������ �������.");
            OnEnemyDeath.Invoke();
        }
        else
        {
            Debug.Log("�� ������� ������ ����� ����� �� ��������.");
        }

        // ���������� ������ �����
        Debug.Log("���� ������������.");
        Destroy(gameObject);
    }
}
