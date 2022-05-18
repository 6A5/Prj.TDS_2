using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierNormalBullet : MonoBehaviour, IProjectileSpawn
{
    /// <summary>
    /// �ޯ��T
    /// </summary>
    SkillAttrAfterUpdate m_saau;

    //�l�u�ƭ�
    float b_speed = 0;
    float b_distance = 99;
    float b_damage = 0;

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
    /// �I���ĤH
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

    /* ���oProjectile��T ��l�ƭn�D�C��
     * �h�L���q�l�u
     * - �t��
     * - �Z��
     * - �ˮ`
     */
    public void SetProjectileAttr(int skillIndex)
    {
        m_saau = PlayerAttribute.Instance.skillAttrs[skillIndex];

        b_damage = m_saau.damage;
        b_speed = m_saau.projectileSpeed;
        b_distance = m_saau.distance;

    }
}
