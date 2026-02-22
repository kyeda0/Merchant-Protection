using UnityEngine;

[CreateAssetMenu(fileName = "EnemyData", menuName = "Scriptable Objects/EnemyData")]
public class EnemyData : ScriptableObject
{
    public float rangeVision;
    public float maxSpeed;
    public float minSpeed;
    public float maxHealth;
    public LayerMask layerMask;
    public Sprite spriteEnemy;
}
