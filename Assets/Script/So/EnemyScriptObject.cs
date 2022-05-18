using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyData", menuName = "ScriptableObjects/EnemyData", order = 2)]
public class EnemyScriptObject : ScriptableObject
{
    public enum EnemyType // 敵人種類
    {
        Colliding,   // 碰撞型
        NonColliding // 穿透型
    }

    [SerializeField, Tooltip("種類")]
    public EnemyType enemyType; 
    [SerializeField, Tooltip("生命")]
    public float maxHP;         
    [SerializeField, Tooltip("傷害")]
    public float damage;        
    [SerializeField, Tooltip("速度")]
    public float movementSpeed;
    [SerializeField, Tooltip("冷卻")]
    public float cooldown;
    
    [SerializeField, Tooltip("圖片")]
    public Sprite enemyImg;
    [SerializeField, Tooltip("碰撞大小")]
    public float colliderSize;

}
