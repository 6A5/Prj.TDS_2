using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class SoldierNormalBullet : BaseBullet
{
    /// <summary>
    /// 技能資訊
    /// </summary>
    SkillAttrAfterUpdate m_saau;

    PlayerAttribute m_attr;

    //子彈數值
    float b_speed = 0;
    float b_distance = 99;
    float b_damage = 0;
    float b_knockback = 0;

    /// <summary>
    /// 出生點
    /// </summary>
    Vector3 spawnPoint;

    [SerializeField] float colliderRange = 1f;

    [SerializeField] GameObject hitVFX;

    private void Start()
    {
        spawnPoint = transform.position;
    }

    private void Update()
    {
        UpdateTransform();
        Hit();
        DestroyBullet();
    }

    #region ==========繼承==========
    /// <summary>
    /// 更新子彈位置
    /// </summary>
    protected override void UpdateTransform()
    {
        transform.Translate(Vector2.up * b_speed * Time.deltaTime);
    }

    /// <summary>
    /// 刪除子彈
    /// </summary>
    override protected void DestroyBullet()
    {
        if ((spawnPoint - transform.position).magnitude < b_distance) { return; }
        Destroy(this.gameObject);
    }

    /// <summary>
    /// 碰撞敵人
    /// </summary>
    override protected void Hit()
    {
        if (!Physics2D.OverlapCircle(transform.position, colliderRange, ~(1 << 3))) { return; }

        Collider2D target = Physics2D.OverlapCircle(transform.position, colliderRange, ~(1 << 3));
        if (target.gameObject.CompareTag("Enemy"))
        {
            target.GetComponent<EnemyHealth>().GotHit(b_damage);
            target.GetComponent<EnemyHealth>().HitBack(b_knockback);
            GameObject vfx = Instantiate(hitVFX, transform.position, Quaternion.identity, PoolList.Instance.vfxPool);
            Destroy(vfx, vfx.GetComponent<VisualEffect>().GetFloat(Shader.PropertyToID("Duration")));
            Destroy(this.gameObject);
        }
        else if (target.gameObject.CompareTag("Wall"))
        {
            Destroy(this.gameObject);
        }
    }

    /* 取得Projectile資訊 初始化要求列表
     * 士兵普通子彈
     * - 速度
     * - 距離
     * - 傷害
     */
    override public void SetProjectileAttr(int skillIndex)
    {
        m_saau = PlayerAttribute.Instance.skillAttrs[skillIndex];
        m_attr = PlayerAttribute.Instance;

        b_damage = m_saau.damage * m_attr.damage_p * 0.01f;
        b_speed = m_saau.projectileSpeed;
        b_distance = m_saau.distance;
        b_knockback = m_saau.knockback;
    }
    #endregion

    /// <summary>
    /// 顯示碰撞
    /// </summary>
    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, colliderRange);
    }
}
