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
        print(currentHP);

        InfoCanvas.Instance.ShowDamageText(transform.position, damage);

        if (currentHP <= 0)
        {
            Destroy(gameObject);
        }
    }
}
