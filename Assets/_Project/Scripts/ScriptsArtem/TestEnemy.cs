using System;
using UnityEngine;

public class TestEnemy : MonoBehaviour
{
    
    public static event Action OnEnemyDeath; // Объявляем событие для смерти врага
    


    public void Die()
    {
        
        if (OnEnemyDeath != null)
        {
            Debug.Log("Враг умирает. Событие смерти вызвано.");
            OnEnemyDeath.Invoke();
        }
        else
        {
            Debug.Log("На событие смерти врага никто не подписан.");
        }

        // Уничтожаем объект врага
        Debug.Log("Враг уничтожается.");
        Destroy(gameObject);
    }
}
