using NkE1.Utilities;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierUltBullet : BaseBullet
{
    /// <summary>
    /// 技能資訊
    /// </summary>
    SkillAttrAfterUpdate m_saau;

    PlayerAttribute m_attr;

    //子彈數值
    float b_distance = 10;
    float b_damage = 5;
    float b_leadTime = 20;
    float b_pulsingTime = 0.1f;
    float b_scope = 1;
    float b_duration = 3;

    /// <summary>
    /// 玩家
    /// </summary>
    [SerializeField] GameObject player;


    LineRenderer m_lr;
    RaycastHit2D ray;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        m_lr = GetComponent<LineRenderer>();
        m_lr.positionCount = 2;
        StartCoroutine(LeadAnimation());
        
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
        Vector3 p2mUnitVector = Utils.GetJointPointMouseUnit(player.transform.position); // 轉到滑鼠的單位向量
        ray = Physics2D.Raycast(player.transform.position, p2mUnitVector, b_distance, ~(1 << 2 | 1 << 3));
        Debug.DrawRay(player.transform.position, p2mUnitVector * b_distance, Color.red);

        m_lr.SetPosition(0, player.transform.position);

        if (ray) // 如果射線碰到
        {
            m_lr.SetPosition(1, ray.point);
        }
        else
        {
            Vector3 maxPoint = player.transform.position + p2mUnitVector * b_distance;
            m_lr.SetPosition(1, maxPoint);
        }
    }

    /// <summary>
    /// 發射時間(前導過後)
    /// </summary>
    float firingTime = 0;

    /// <summary>
    /// 開始發射(前導後)
    /// </summary>
    bool isFiring = false;

    /// <summary>
    /// 刪除子彈
    /// </summary>
    override protected void DestroyBullet()
    {
        if (isFiring && Time.time > firingTime + b_duration)
        {
            StartCoroutine(EndAnimation());
            isFiring = false;
        }
    }

    /// <summary>
    /// 下次脈衝時間點
    /// </summary>
    float nextPulsingTime = 0;

    /// <summary>
    /// 碰撞敵人
    /// </summary>
    override protected void Hit()
    {
        if (isFiring && Time.time >= nextPulsingTime)
        {
            Vector3 hitPos = ray.point;
            Vector3 originPos = player.transform.position;
            float angle = Utils.GetAnglePointMousePosition(player.transform.position);

            if (ray) // 如果有碰撞
            {
                // 中間點
                Vector3 midPos = ((hitPos - originPos).magnitude / 2) * player.transform.right + originPos;
                // 長度
                float length = Mathf.Abs((hitPos - originPos).magnitude);

                Collider2D[] col = Physics2D.OverlapBoxAll(midPos, length * Vector2.right + b_scope * Vector2.up, angle, ~(1 << 3));
                for (int i = 0; i < col.Length; i++)
                {
                    if (col[i].gameObject.CompareTag("Enemy") && col[i].gameObject != null)
                    {
                        col[i].GetComponent<EnemyHealth>().GotHit(b_damage);
                    }
                }
            }
            else // 如果沒碰撞
            {
                // 中間點
                Vector3 midPos = (originPos + player.transform.right * b_distance * 0.5f);
                // print(midPos);

                Collider2D[] col = Physics2D.OverlapBoxAll(midPos, b_distance * Vector2.right + b_scope * Vector2.up, angle, ~(1 << 3));
                for (int i = 0; i < col.Length; i++)
                {
                    if (col[i].gameObject.CompareTag("Enemy") && col[i].gameObject != null)
                    {
                        col[i].GetComponent<EnemyHealth>().GotHit(b_damage);
                    }
                }
            }
            // 下次脈衝時間計算
            nextPulsingTime = Time.time + b_pulsingTime;
        }
    }

    /* 取得Projectile資訊 初始化要求列表
     * 士兵終極子彈
     * - 傷害
     * - 距離
     * - 持續
     * - 前導
     * - 脈衝
     * - 範圍
     */
    override public void SetProjectileAttr(int skillIndex)
    {
        m_saau = PlayerAttribute.Instance.skillAttrs[skillIndex];
        m_attr = PlayerAttribute.Instance;

        b_damage = m_saau.damage * m_attr.damage_p * 0.01f;
        b_distance = m_saau.distance;
        b_duration = m_saau.duration * m_attr.duration_p * 0.01f;
        b_leadTime = m_saau.leadTime;
        b_pulsingTime = m_saau.pulsingTime;
        b_scope = m_saau.scope * m_attr.scope_p * 0.01f;
    }
    #endregion

    IEnumerator LeadAnimation()
    {
        if (m_lr.startWidth <= 0.8f * b_scope)
        {
            m_lr.startWidth = Mathf.Lerp(m_lr.startWidth, b_scope, b_leadTime * Time.fixedDeltaTime);
        }
        if (m_lr.endWidth <= 0.97f * b_scope)
        {
            m_lr.endWidth = Mathf.Lerp(m_lr.endWidth, b_scope, b_leadTime * Time.fixedDeltaTime);
        }
        yield return new WaitForSeconds(0.05f);

        if (m_lr.endWidth > 0.97f)
        {
            isFiring = true;
            firingTime = Time.time;
            yield break;
        }
        StartCoroutine(LeadAnimation());
    }

    IEnumerator EndAnimation()
    {
        if (m_lr.startWidth >= 0.1f)
        {
            m_lr.startWidth = Mathf.Lerp(m_lr.startWidth, 0, 10 * Time.fixedDeltaTime);
        }
        if (m_lr.endWidth >= 0.1f)
        {
            m_lr.endWidth = Mathf.Lerp(m_lr.endWidth, 0, 10 * Time.fixedDeltaTime);
        }
        yield return new WaitForSeconds(0.05f);

        if (m_lr.endWidth < 0.1f)
        {
            Destroy(gameObject);
            yield break;
        }
        StartCoroutine(EndAnimation());
    }
}
