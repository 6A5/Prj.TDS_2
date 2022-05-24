using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierThrowableBullet : BaseBullet
{
    /// <summary>
    /// �ޯ��T
    /// </summary>
    SkillAttrAfterUpdate m_saau;

    //�l�u�ƭ�
    float b_speed = 0;
    float b_distance = 2;
    float b_damage = 0;
    float b_scope = 0;
    float b_duration = 0;
    float b_pulsingTime = 0;

    /// <summary>
    /// �X���I
    /// </summary>
    Vector3 spawnPoint;

    [SerializeField] float colliderRange = 1f;

    bool isExploding = false;

    private void Start()
    {
        spawnPoint = transform.position;
    }

    private void Update()
    {
        UpdateTransform();
        Hit();
        DestroyBullet();

        print(Time.time);
    }

    [SerializeField] Sprite explodeImage;
    #region ==========�~��==========

    /// <summary>
    /// ��s�l�u��m
    /// </summary>
    protected override void UpdateTransform()
    {
        if (isExploding) { return; }
        transform.Translate(Vector2.up * b_speed * Time.deltaTime);
    }

    /// <summary>
    /// �R���l�u
    /// </summary>
    override protected void DestroyBullet()
    {
        if (isExploding)
        {
            if (Time.time >= explodingTime + b_duration)
            {
                Destroy(this.gameObject);
            }
        }
        else if((spawnPoint - transform.position).magnitude >= b_distance)
        {
            CreateExplodeArea();
        }
    }

    /// <summary>
    /// �I���ĤH
    /// </summary>
    override protected void Hit()
    {
        if (isExploding && Time.time >= nextPulsingTime)
        {
            Collider2D[] targets = Physics2D.OverlapCircleAll(transform.position, b_scope);
            for (int i = 0; i < targets.Length; i++)
            {
                if (targets[i].gameObject != null && targets[i].gameObject.CompareTag("Enemy"))
                {
                    targets[i].GetComponent<EnemyHealth>().GotHit(b_damage);
                }
            }
            nextPulsingTime = Time.time + b_pulsingTime;
        }
        else
        {
            if (!Physics2D.OverlapCircle(transform.position, colliderRange) || isExploding) { return; }

            Collider2D target = Physics2D.OverlapCircle(transform.position, colliderRange);
            if (target.gameObject.CompareTag("Enemy"))
            {
                CreateExplodeArea();
            }
            else if (target.gameObject.CompareTag("Wall"))
            {
                CreateExplodeArea();
            }
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
        b_scope = m_saau.scope;
        b_duration = m_saau.duration;
        b_pulsingTime = m_saau.pulsingTime;
    }
    #endregion

    /// <summary>
    /// �z���ɶ�����
    /// </summary>
    float explodingTime = 0;
    /// <summary>
    /// �U���߽Įɶ�
    /// </summary>
    float nextPulsingTime = 0;

    private void CreateExplodeArea()
    {
        SpriteRenderer m_spr = GetComponent<SpriteRenderer>();
        m_spr.sprite = explodeImage;
        m_spr.color = new Color32(35, 168, 192, 50);
        m_spr.transform.localScale = Vector3.one * b_scope;

        explodingTime = Time.time;
        isExploding = true;
    }

    /// <summary>
    /// ��ܸI��
    /// </summary>
    private void OnDrawGizmosSelected()
    {
        if (isExploding)
        {
            Gizmos.DrawWireSphere(transform.position, b_scope);
        }
        Gizmos.DrawWireSphere(transform.position, colliderRange);
    }
}
