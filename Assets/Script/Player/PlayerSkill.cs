using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkill : MonoBehaviour
{
    /// <summary>
    /// 普通子彈
    /// </summary>
    public GameObject normalBullet_obj;

    /// <summary>
    /// 普通子彈傷害
    /// </summary>
    [SerializeField] float normalBullet_damage;

    /// <summary>
    /// 普通子彈速度
    /// </summary>
    [SerializeField] float normalBullet_speed;

    /// <summary>
    /// 普通子彈冷卻
    /// </summary>
    [SerializeField] float normalBullet_cooldown;
    float normalBullet_cooldown_last;

    /// <summary>
    /// 普通子彈距離
    /// </summary>
    [SerializeField] float normalBullet_range;

    /// <summary>
    /// 普通子彈生成點
    /// </summary>
    [SerializeField] Transform normalBullet_spawnPoint;

    /// <summary>
    /// 普通子彈浮動參數
    /// </summary>
    [SerializeField] float normalBullet_aimOffset;

    /// <summary>
    /// 技能清單
    /// </summary>
    [SerializeField] List<SkillScriptObject> m_skillSO;

    private void Start()
    {
        m_skillSO = PlayerAttribute.Instance.heroData.SkillSO;
        Debug.Log(m_skillSO[0].name);
    }

    private void Update()
    {
        if (Input.GetMouseButton(0) && normalBullet_cooldown_last + normalBullet_cooldown < Time.time)
        {
            Debug.Log("SHOOT!");

            GameObject bullet = Instantiate(normalBullet_obj, normalBullet_spawnPoint.position,
                transform.rotation * Quaternion.Euler(new Vector3(0,0,-90 + Random.Range(normalBullet_aimOffset, -normalBullet_aimOffset))));
            bullet.GetComponent<SoldierNormalBullet>().SetBulletState(normalBullet_speed, normalBullet_range, normalBullet_damage);

            normalBullet_cooldown_last = Time.time;
        }
    }
}
