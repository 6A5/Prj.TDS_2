using NkE1.Utilities;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public Material enemyMat;

    private EnemyAttribute enemyAttr;
    private float currentHP;
    private SpriteRenderer m_spr;

    [SerializeField] AudioClip hitSound;

    private void Awake()
    {
        enemyAttr = GetComponent<EnemyAttribute>();
    }

    private void Start()
    {
        // 初始化
        currentHP = enemyAttr.maxHP;
        m_spr = GetComponent<SpriteRenderer>();
        m_spr.material = new Material(enemyMat);
    }

    /// <summary>
    /// ENEMY受到傷害
    /// </summary>
    /// <param name="damage">傷害</param>
    public void GotHit(float damage)
    {
        currentHP -= damage;
        var showDamage = Utils.RoundToDecimalPlaces(damage, 2);
        InfoCanvas.Instance.ShowDamageText(transform.position, showDamage, Color.white);
        StartCoroutine(ShowGotHitEffect());

        if (currentHP <= 0)
        {
            WaveControl.Instance.DeleteOnEnemyList(this.gameObject);
            PlayerItem.Instance.AddCoin((int)Random.Range(enemyAttr.coinDropRange.x, enemyAttr.coinDropRange.y));
            Destroy(gameObject);
        }

        SoundEffectManager.Instance.PlaySound(hitSound);
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

    IEnumerator ShowGotHitEffect()
    {
        m_spr.material.SetFloat(Shader.PropertyToID("_Power"), 1.5f);
        yield return new WaitForSeconds(0.05f);
        m_spr.material.SetFloat(Shader.PropertyToID("_Power"), 0);
    }
}
