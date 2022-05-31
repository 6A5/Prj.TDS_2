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
        currentHP = enemyAttr.maxHP;
    }

    /// <summary>
    /// ENEMY����ˮ`
    /// </summary>
    /// <param name="damage">�ˮ`</param>
    public void GotHit(float damage)
    {
        currentHP -= damage;

        InfoCanvas.Instance.ShowDamageText(transform.position, damage, Color.white);

        if (currentHP <= 0)
        {
            WaveControl.Instance.DeleteOnEnemyList(this.gameObject);
            Destroy(gameObject);
        }
    }

    /// <summary>
    /// ���h
    /// </summary>
    /// <param name="backForce">���h�Ѽ�</param>
    public void HitBack(float backForce)
    {
        Transform playerTrans = PlayerAttribute.Instance.gameObject.transform;

        Vector2 vectorUnit = Utils.GetJointPointTargetUnit(playerTrans.position, transform.position);
        transform.Translate(vectorUnit * -1 * 0.1f * backForce, Space.World);
    }
}
