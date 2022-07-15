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
        // ��l��
        currentHP = enemyAttr.maxHP;
        m_spr = GetComponent<SpriteRenderer>();
        m_spr.material = new Material(enemyMat);
    }

    /// <summary>
    /// ENEMY����ˮ`
    /// </summary>
    /// <param name="damage">�ˮ`</param>
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
    /// ���h
    /// </summary>
    /// <param name="backForce">���h�Ѽ�</param>
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
