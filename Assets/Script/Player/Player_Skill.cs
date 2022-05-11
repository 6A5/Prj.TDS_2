using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Skill : MonoBehaviour
{
    /// <summary>
    /// ���q�l�u
    /// </summary>
    public GameObject normalBullet_obj;

    [SerializeField] float normalBullet_dagage;

    /// <summary>
    /// ���q�l�u�t��
    /// </summary>
    [SerializeField] float normalBullet_speed;

    /// <summary>
    /// ���q�l�u�N�o
    /// </summary>
    [SerializeField] float normalBullet_cooldown;
    float normalBullet_cooldown_last;

    /// <summary>
    /// ���q�l�u�Z��
    /// </summary>
    [SerializeField] float normalBullet_range;

    /// <summary>
    /// ���q�l�u�ͦ��I
    /// </summary>
    [SerializeField] Transform normalBullet_spawnPoint;

    /// <summary>
    /// ���q�l�u�B�ʰѼ�
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
