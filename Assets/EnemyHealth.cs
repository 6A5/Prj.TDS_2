using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] float healthPoint = 20;

    public void GotHit(float damage)
    {
        healthPoint -= damage;

        if (healthPoint > 0) { return; }
        Destroy(this.gameObject);
    }
}
