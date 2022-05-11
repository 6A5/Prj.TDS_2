using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Skill : MonoBehaviour
{
    /// <summary>
    /// 普通子彈
    /// </summary>
    public GameObject normalBullet_obj;

    [SerializeField] float normalBullet_dagage;

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

    private void Start()
    {
        Debug.Log(Player_Attribute.Instance.heroData.name);
    }

    private void Update()
    {
        if (Input.GetMouseButton(0) && normalBullet_cooldown_last + normalBullet_cooldown < Time.time)
        {
            Debug.Log("SHOOT!");
            GameObject bullet = Instantiate(normalBullet_obj, normalBullet_spawnPoint.position,
                transform.rotation * Quaternion.Euler(new Vector3(0,0,-90 + Random.Range(normalBullet_aimOffset, -normalBullet_aimOffset))));
            bullet.GetComponent<Soldier_Normal_bullet>().SetBulletState(normalBullet_speed, normalBullet_range, normalBullet_dagage);
            normalBullet_cooldown_last = Time.time;
        }
    }
}

public class SkillConstruct
{

}
