using System;
using UnityEngine;

[CreateAssetMenu(menuName = "Unit",fileName = "NewUnit")]
public class UnitConfig : ScriptableObject
{
    [field:SerializeField] public float Speed { get; private set; }
    [field:SerializeField] public int PowerAttack { get; private set; }
    [field:SerializeField] public float LivingTime { get; private set; }
}
