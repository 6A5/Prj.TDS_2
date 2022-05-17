using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkill : MonoBehaviour
{
    /// <summary>
    /// ���q�l�u
    /// </summary>
    public GameObject normalBullet_obj;

    /// <summary>
    /// ���q�l�u�ˮ`
    /// </summary>
    [SerializeField] float normalBullet_damage;

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

    /// <summary>
    /// �ޯ�M��
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
