using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyData", menuName = "ScriptableObjects/EnemyData", order = 2)]
public class EnemyScriptObject : ScriptableObject
{
    public enum EnemyType // �ĤH����
    {
        Colliding,   // �I����
        NonColliding // ��z��
    }

    [SerializeField, Tooltip("����")]
    public EnemyType enemyType; 
    [SerializeField, Tooltip("�ͩR")]
    public float maxHP;         
    [SerializeField, Tooltip("�ˮ`")]
    public float damage;        
    [SerializeField, Tooltip("�t��")]
    public float movementSpeed;
    [SerializeField, Tooltip("�N�o")]
    public float cooldown;
    
    [SerializeField, Tooltip("�Ϥ�")]
    public Sprite enemyImg;
    [SerializeField, Tooltip("�I���j�p")]
    public float colliderSize;

}
