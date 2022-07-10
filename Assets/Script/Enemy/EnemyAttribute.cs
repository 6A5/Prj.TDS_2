using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttribute : MonoBehaviour
{
    public EnemyScriptObject enemyData;

    [SerializeField, Tooltip("種類")]
    public EnemyScriptObject.EnemyType enemyType;
    [SerializeField, Tooltip("生命")]
    public float maxHP;
    [SerializeField, Tooltip("傷害")]
    public float damage;
    [SerializeField, Tooltip("移速")]
    public float movementSpeed;
    [SerializeField, Tooltip("冷卻")]
    public float cooldown;
    [SerializeField, Tooltip("金錢掉落範圍")]
    public Vector2 coinDropRange;

    private CircleCollider2D m_Col;
    private SpriteRenderer m_SprRend;

    private void Awake()
    {
        #region 初始化
        m_Col = GetComponent<CircleCollider2D>();
        m_SprRend = GetComponent<SpriteRenderer>();

        m_Col.radius = enemyData.colliderSize;
        m_SprRend.sprite = enemyData.enemyImg;
        #endregion
    }

    /// <summary>
    /// 設定難度倍數
    /// 根據難度強化敵人
    /// </summary>
    /// <param name="hpMultiple">生命倍數</param>
    /// <param name="damageMultiple">傷害倍數</param>
    /// <param name="movementMultiple">移動倍數</param>
    public void InitialEnemyAttr(float hpMultiple, float damageMultiple, float movementMultiple)
    {
        enemyType = enemyData.enemyType;
        maxHP = enemyData.maxHP;
        damage = enemyData.damage;
        movementSpeed = enemyData.movementSpeed;
        cooldown = enemyData.cooldown;
        coinDropRange = enemyData.coinDropRange;

        maxHP *= hpMultiple;
        damage *= damageMultiple;
        movementSpeed *= movementMultiple;
    }

    public void SetEnemyData(EnemyScriptObject a)
    {
        enemyData = a;
    }
}
