using System.Collections;
using System.Collections.Generic;
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
        print(currentHP);

        if (currentHP <= 0)
        {
            Destroy(gameObject);
        }
    }
}
