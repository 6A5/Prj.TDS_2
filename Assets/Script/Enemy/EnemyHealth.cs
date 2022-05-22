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
    /// ENEMY¨ü¨ì¶Ë®`
    /// </summary>
    /// <param name="damage">¶Ë®`</param>
    public void GotHit(float damage)
    {
        currentHP -= damage;

        InfoCanvas.Instance.ShowDamageText(transform.position, damage, Color.white);

        if (currentHP <= 0)
        {
            Destroy(gameObject);
        }
    }
}
