using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private EnemyConfig _enemyConfig;
    [SerializeField] private UnitConfig _unitConfig;
    
    private int _health;
    
    void Start()
    {
        _health = _enemyConfig.Health;
    }

    private void OnCollisionEnter2D(Collision2D unit)
    {
        if (_health > 0)
        {
            _health -= _unitConfig.PowerAttack;
            
        }
        else
        {
            Destroy(gameObject);
        }
        
        Debug.Log(_health);
    }

    private void TakenDamage(int takenDamage)
    {
        if (_health <= 0)
        {
            Destroy(gameObject);
        }
        else
        {
            _health -= takenDamage;
        }
        
        Debug.Log(_health);
    }
}
