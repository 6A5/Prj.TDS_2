using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierNormalBullet : MonoBehaviour, IProjectileSpawn
{
    /// <summary>
    /// 技能資訊
    /// </summary>
    SkillAttrAfterUpdate m_saau;

    //子彈數值
    float b_speed = 0;
    float b_distance = 99;
    float b_damage = 0;

    /// <summary>
    /// 出生點
    /// </summary>
    Vector3 spawnPoint;

    [SerializeField] float colliderRange = 1f;

    private void Start()
    {
        spawnPoint = transform.position;
    }

    private void Update()
    {
        transform.Translate(Vector2.up * b_speed * Time.deltaTime);
        Hit();
        DestroyBullet();
    }

    void DestroyBullet()
    {
        if ((spawnPoint - transform.position).magnitude < b_distance) { return; }
        Destroy(this.gameObject);
    }

    /// <summary>
    /// 碰撞敵人
    /// </summary>
    void Hit()
    {
        if (!Physics2D.OverlapCircle(transform.position, colliderRange)) { return; }

        Collider2D target = Physics2D.OverlapCircle(transform.position, colliderRange);
        if (target.gameObject.CompareTag("Enemy"))
        {
            target.GetComponent<EnemyHealth>().GotHit(b_damage);
            Destroy(this.gameObject);
        }
        else if (target.gameObject.CompareTag("Wall"))
        {
            Destroy(this.gameObject);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, colliderRange);
    }

    /* 取得Projectile資訊 初始化要求列表
     * 士兵普通子彈
     * - 速度
     * - 距離
     * - 傷害
     */
    public void SetProjectileAttr(int skillIndex)
    {
        m_saau = PlayerAttribute.Instance.skillAttrs[skillIndex];

        b_damage = m_saau.damage;
        b_speed = m_saau.projectileSpeed;
        b_distance = m_saau.distance;

    }
}
