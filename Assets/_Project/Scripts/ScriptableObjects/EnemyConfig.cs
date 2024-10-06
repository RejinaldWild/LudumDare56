using UnityEngine;

[CreateAssetMenu(menuName = "Enemy",fileName = "NewEnemy")]
public class EnemyConfig : ScriptableObject
{
    [field:SerializeField] public int Health { get; private set; }
}
