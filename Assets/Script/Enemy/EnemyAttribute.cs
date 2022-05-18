using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttribute : MonoBehaviour
{
    public EnemyScriptObject enemyData;

    [SerializeField, Tooltip("����")]
    public EnemyScriptObject.EnemyType enemyType;
    [SerializeField, Tooltip("�ͩR")]
    public float maxHP;
    [SerializeField, Tooltip("�ˮ`")]
    public float damage;
    [SerializeField, Tooltip("���t")]
    public float movementSpeed;
    [SerializeField, Tooltip("�N�o")]
    public float cooldown;

    private CircleCollider2D m_Col;
    private SpriteRenderer m_SprRend;

    private void Awake()
    {
        #region ��l��
        m_Col = GetComponent<CircleCollider2D>();
        m_SprRend = GetComponent<SpriteRenderer>();

        m_Col.radius = enemyData.colliderSize;
        m_SprRend.sprite = enemyData.enemyImg;

        enemyType = enemyData.enemyType;
        maxHP = enemyData.maxHP;
        damage = enemyData.damage;
        movementSpeed = enemyData.movementSpeed;
        cooldown = enemyData.cooldown;
        #endregion
    }

    /// <summary>
    /// �]�w���׭���
    /// �ھ����ױj�ƼĤH
    /// </summary>
    /// <param name="hpMultiple">�ͩR����</param>
    /// <param name="damageMultiple">�ˮ`����</param>
    /// <param name="movementMultiple">���ʭ���</param>
    public void SetDiffcultyBonus(float hpMultiple, float damageMultiple, float movementMultiple)
    {
        maxHP *= hpMultiple;
        damage *= damageMultiple;
        movementSpeed *= movementMultiple;
    }
}