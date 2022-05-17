using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkill : MonoBehaviour
{


    /// <summary>
    /// ���q�l�u�N�o�p�ɾ�
    /// </summary>
    float normalBullet_cooldown_last;
    /// <summary>
    /// ���q�l�u�ͦ��I
    /// </summary>
    [SerializeField] Transform normalBullet_spawnPoint;


    /// <summary>
    /// �ޯ�M��
    /// </summary>
    List<SkillAttrAfterUpdate> m_saau;

    private void Start()
    {
        m_saau = PlayerAttribute.Instance.skillAttrs;
    }

    private void Update()
    {
        if (Input.GetMouseButton(0) && normalBullet_cooldown_last + m_saau[0].cooldown < Time.time)
        {
            Debug.Log("SHOOT!");

            GameObject bullet = Instantiate(m_saau[0].projectileObj, normalBullet_spawnPoint.position,
                transform.rotation * Quaternion.Euler(new Vector3(0,0,-90 + Random.Range(m_saau[0].aimOffset, -m_saau[0].aimOffset))));

            bullet.GetComponent<IProjectileSpawn>().SetProjectileAttr(0);

            normalBullet_cooldown_last = Time.time;
        }
    }
}
