using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class PlayerSkill : MonoBehaviour
{

    /// <summary>
    /// �l�u�ͦ��I
    /// </summary>
    [SerializeField] Transform[] bulletSpawnPoint = new Transform[4];

    /// <summary>
    /// �l�u�N�o
    /// </summary>
    [SerializeField] float[] bulletCooldownLast = new float[4];


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
        if (!GameMenuControl.Instance.gamePause && !WaveControl.Instance.isPlayerDead)
        {
            NormalSkill();
            SpecialSkill();
            ThrowableSkill();
            UltSkill();
        }

        UpdateSkillCooldownUI();
    }

    private void UpdateSkillCooldownUI()
    {
        InfoCanvas.Instance.spSkill.fillAmount = ((Time.time - bulletCooldownLast[1]) / m_saau[1].cooldown);
        InfoCanvas.Instance.throwSkill.fillAmount = ((Time.time - bulletCooldownLast[2]) / m_saau[2].cooldown);
        InfoCanvas.Instance.ultSkill.fillAmount = ((Time.time - bulletCooldownLast[3]) / m_saau[3].cooldown);
    }

    private void NormalSkill()
    {
        int index = 0;

        if (Input.GetMouseButton(0) && bulletCooldownLast[index] + m_saau[index].cooldown < Time.time)
        {
            SpawnProjectile(index);
            // float offset = Random.Range(m_saau[index].aimOffset, -m_saau[index].aimOffset);
            // Quaternion rotate = transform.rotation * Quaternion.Euler(new Vector3(0, 0, -90 + offset));
            // 
            // GameObject bullet1 = Instantiate(m_saau[index].projectileObj, bulletSpawnPoint[index].position, rotate);
            // 
            // bullet1.GetComponent<IProjectileSpawn>().SetProjectileAttr(index);
            // 
            // normalBullet_cooldown_last = Time.time;
        }
    }

    private void SpecialSkill()
    {
        int index = 1;

        if (Input.GetMouseButton(1) && bulletCooldownLast[index] + m_saau[index].cooldown < Time.time)
        {
            SpawnProjectile(index);
        }
    }

    private void ThrowableSkill()
    {
        int index = 2;

        if (Input.GetKey(KeyCode.Q) && bulletCooldownLast[index] + m_saau[index].cooldown < Time.time)
        {
            SpawnProjectile(index);
        }
    }

    private void UltSkill()
    {
        int index = 3;

        if (Input.GetKey(KeyCode.R) && bulletCooldownLast[index] + m_saau[index].cooldown < Time.time)
        {
            SpawnProjectile(index);
        }
    }

    private void SpawnProjectile(int index)
    {
        #region �p�⤽�����O
        /* if (count > 1)
         * angle / count = step
         * 
         * �V�k��O�t���סA�V��������
         * first ==> Quaternion.Euler(new Vector3(0, 0, -90 + angle / 2))
         * for i = 0 ; i < count; i++
         *   rotate = new Vector3(0, 0, -90 + angle / 2 - i * step)
         */
        #endregion

        float count = m_saau[index].projectileCount; // �l�u�ƶq
        float angle = m_saau[index].angle; // �X������
        if (count > 1) // ��o�h��
        {
            float step = angle / count;
            for (int i = 0; i < count; i++)
            {
                float offset = Random.Range(m_saau[index].aimOffset, -m_saau[index].aimOffset); // ����
                // �⦡ >>> ���I<-90> + ����Ĥ@�I<angle/2> - �ĴX���l�u<i> * �C�樤��<step> + ����<offset>
                Quaternion rotate = transform.rotation * Quaternion.Euler(new Vector3(0, 0, -90 + angle / 2 - i * step + offset)); // ����

                GameObject bullet = Instantiate(m_saau[index].projectileObj, bulletSpawnPoint[index].position, rotate, PoolList.Instance.projectilesPool);
                bullet.GetComponent<IProjectileSpawn>().SetProjectileAttr(index);
            }
        }
        else if (count == 1) // ��o����
        {
            float offset = Random.Range(m_saau[index].aimOffset, -m_saau[index].aimOffset);
            Quaternion rotate = transform.rotation * Quaternion.Euler(new Vector3(0, 0, -90 + offset));

            GameObject bullet = Instantiate(m_saau[index].projectileObj, bulletSpawnPoint[index].position, rotate, PoolList.Instance.projectilesPool);

            bullet.GetComponent<IProjectileSpawn>().SetProjectileAttr(index);
        }

        bulletCooldownLast[index] = Time.time;
    }
}
