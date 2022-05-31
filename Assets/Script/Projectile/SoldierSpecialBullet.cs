using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierSpecialBullet : BaseBullet
{
    /// <summary>
    /// �ޯ��T
    /// </summary>
    SkillAttrAfterUpdate m_saau;

    //�l�u�ƭ�
    float b_speed = 0;
    float b_distance = 99;
    float b_damage = 0;
    float b_knockback = 0;

    /// <summary>
    /// �X���I
    /// </summary>
    Vector3 spawnPoint;

    [SerializeField] float colliderRange = 1f;

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

    #region ==========�~��==========
    /// <summary>
    /// ��s�l�u��m
    /// </summary>
    protected override void UpdateTransform()
    {
        transform.Translate(Vector2.up * b_speed * Time.deltaTime);
    }

    /// <summary>
    /// �R���l�u
    /// </summary>
    override protected void DestroyBullet()
    {
        if ((spawnPoint - transform.position).magnitude < b_distance) { return; }
        Destroy(this.gameObject);
    }

    /// <summary>
    /// �I���ĤH
    /// </summary>
    override protected void Hit()
    {
        if (!Physics2D.OverlapCircle(transform.position, colliderRange, ~(1 << 3))) { return; }

        Collider2D target = Physics2D.OverlapCircle(transform.position, colliderRange, ~(1 << 3));
        if (target.gameObject.CompareTag("Enemy"))
        {
            target.GetComponent<EnemyHealth>().GotHit(b_damage);
            target.GetComponent<EnemyHealth>().HitBack(b_knockback);
            Destroy(this.gameObject);
        }
        else if (target.gameObject.CompareTag("Wall"))
        {
            Destroy(this.gameObject);
        }
    }

    /* ���oProjectile��T ��l�ƭn�D�C��
     * �h�L���q�l�u
     * - �t��
     * - �Z��
     * - �ˮ`
     */
    override public void SetProjectileAttr(int skillIndex)
    {
        m_saau = PlayerAttribute.Instance.skillAttrs[skillIndex];

        b_damage = m_saau.damage;
        b_speed = m_saau.projectileSpeed;
        b_distance = m_saau.distance;
        b_knockback = m_saau.knockback;
    }
    #endregion

    /// <summary>
    /// ��ܸI��
    /// </summary>
    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, colliderRange);
    }
}
