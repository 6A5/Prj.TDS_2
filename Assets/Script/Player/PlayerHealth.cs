using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [Header("ºÊ±±")]
    [SerializeField] private float currentHP;

    private PlayerAttribute m_attr = null;

    private void Start()
    {
        m_attr = PlayerAttribute.Instance;
        currentHP = m_attr.maxHP * m_attr.maxHP_p / .01f;

        StartCoroutine(RecoverHealthPoint());
    }

    public void GotHit(float damage)
    {
        currentHP -= damage;
        InfoCanvas.Instance.ShowDamageText(transform.position, damage, Color.red);
        UpdateHPBar();

        if (currentHP <= 0)
        {
            WaveControl.Instance.isPlayerDead = true;
            GameMenuControl.Instance.EndGame(false);
        }
    }

    IEnumerator RecoverHealthPoint()
    {
        float currentMaxHP = m_attr.maxHP * m_attr.maxHP_p * .01f;
        currentHP += m_attr.hpRecovery;

        if (currentHP >= currentMaxHP)
        {
            currentHP = currentMaxHP;
        }

        UpdateHPBar();
        yield return new WaitForSeconds(1f);
        StartCoroutine(RecoverHealthPoint());
    }

    private void UpdateHPBar()
    {
        InfoCanvas.Instance.hpBar.fillAmount = currentHP / m_attr.maxHP * m_attr.maxHP_p * .01f;
    }
}
