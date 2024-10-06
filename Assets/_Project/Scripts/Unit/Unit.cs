using System.Collections;
using UnityEngine;
using System;
using Unity.VisualScripting;
using UnityEngine.Serialization;

[RequireComponent(typeof(Rigidbody2D))]
public class Unit : MonoBehaviour
{
    
    [SerializeField] private UnitConfig _unitConfig;
    private float _timeDestroy;
    public int PowerAttack { get; private set; }
    
    public event Action<int> OnTakeDamage;
    
    void Start()
    {
        _timeDestroy = _unitConfig.LivingTime;
        PowerAttack = _unitConfig.PowerAttack;
    }

    void Update()
    {
        StartCoroutine(LifeToDie());
    }

    private void OnCollisionEnter2D(Collision2D enemy)
    {
        if (enemy.transform.TryGetComponent(out Enemy _enemy))
        {
            UnitSelectionManager.Instance.selectedUnits.Clear();
            Destroy(gameObject);
            OnTakeDamage?.Invoke(PowerAttack);
            Debug.Log("Collide!");
        }
    }

    private IEnumerator LifeToDie()
    {
        yield return new WaitForSeconds(_timeDestroy);
        Destroy(gameObject);
    }

    private void OnDestroy()
    {
        StopCoroutine(LifeToDie());
    }
}
