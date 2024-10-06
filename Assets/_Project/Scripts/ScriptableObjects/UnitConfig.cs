using System;
using UnityEngine;

[CreateAssetMenu(menuName = "Unit",fileName = "NewUnit")]
public class UnitConfig : ScriptableObject
{
    [SerializeField] public float _speed;
    [SerializeField] public int _powerAttack;
    [SerializeField] public float _livingTime;
}
