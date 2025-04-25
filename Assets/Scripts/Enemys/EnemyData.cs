using UnityEngine;

[CreateAssetMenu(fileName = "EnemyData", menuName = "ScriptableObject/EnemyData", order = 0)]
public class EnemyData : ScriptableObject
{
    public string enemyName;
    public int maxHp;
    public float moveSpeed;
}
