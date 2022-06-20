using NkE1.Utilities;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    private EnemyAttribute enemyAttr;
    private float currentHP;

    private void Awake()
    {
        enemyAttr = GetComponent<EnemyAttribute>();
    }

    private void Start()
    {
        // 初始化
        currentHP = enemyAttr.maxHP;
    }

    /// <summary>
    /// ENEMY受到傷害
    /// </summary>
    /// <param name="damage">傷害</param>
    public void GotHit(float damage)
    {
        currentHP -= damage;

        InfoCanvas.Instance.ShowDamageText(transform.position, damage, Color.white);

        if (currentHP <= 0)
        {
            WaveControl.Instance.DeleteOnEnemyList(this.gameObject);
            PlayerItem.Instance.AddCoin((int)Random.Range(enemyAttr.coinDropRange.x, enemyAttr.coinDropRange.y));
            Destroy(gameObject);
        }
    }

    /// <summary>
    /// 擊退
    /// </summary>
    /// <param name="backForce">擊退參數</param>
    public void HitBack(float backForce)
    {
        Transform playerTrans = PlayerAttribute.Instance.gameObject.transform;

        Vector2 vectorUnit = Utils.GetJointPointTargetUnit(playerTrans.position, transform.position);
        transform.Translate(vectorUnit * -1 * 0.1f * backForce, Space.World);
    }
}
