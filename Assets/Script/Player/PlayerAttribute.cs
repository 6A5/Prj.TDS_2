using Mono.Cecil;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif


public class PlayerAttribute : MonoBehaviour
{
    public HeroScriptObject heroData;

    // �غc�� �H��ޥΨϥ� Player_Attribute.Instance;
    private static PlayerAttribute _instance = null;
    public static PlayerAttribute Instance
    {
        get
        {
            return _instance;
        }
    }

    // �ʺA

    [Header("�D%��")]
    [Tooltip("�̤j�ͩR")]
    public float maxHP;
    [Tooltip("��q�^�_")]
    public float hpRecovery;
    [Tooltip("���ʳt��")]
    public float movementSpd;
    [Tooltip("���m")]
    public float defense;
    [Tooltip("�B�~��g��")]
    public int extraProjectile;
    [Tooltip("�B�~�ͩR")]
    public int extraLife;

    [Header("%��")]
    [Tooltip("�̤j�ͩR�w��")]
    public float maxHP_p;
    [Tooltip("���ʳt�׭w��")]
    public float movementSpd_p;
    [Tooltip("�ˮ`�[���w��")]
    public float damage_p;
    [Tooltip("�N�o�ɶ��w��")]
    public float cooldown_p;
    [Tooltip("����ɶ��w��")]
    public float duration_p;
    [Tooltip("�d��w��")]
    public float scope_p;
    [Tooltip("�B�~�����w��")]
    public float extraDrop_p;
    [Tooltip("�B�~�����w��")]
    public float extraMoney_p;
    [Tooltip("�B�~�g��w��")]
    public float extraXP_p;

    [Header("�ޯ�")]
    public List<SkillAttrAfterUpdate> skillAttrs = new List<SkillAttrAfterUpdate>();

    private void Awake()
    {
        _instance = this;

        initialize();
    }

    private void Start()
    {
        /*
        for (int i = 0; i < heroData.SkillSO.Count; i++)
        {
            SkillScriptObject so = heroData.SkillSO[i];
        }
        */
    }

    #region ��sAttr


    #endregion

    /// <summary>
    /// ��l��
    /// </summary>
    public void initialize()
    {
        maxHP = heroData.maxHP;
        hpRecovery = heroData.hpRecovery;
        movementSpd = heroData.movementSpd;
        defense = heroData.defense;
        extraProjectile = heroData.extraProjectile;
        extraLife = heroData.extraLife;

        maxHP_p = heroData.maxHP_p;
        movementSpd_p = heroData.movementSpd_p;
        damage_p = heroData.damage_p;
        cooldown_p = heroData.cooldown_p;
        duration_p = heroData.duration_p;
        scope_p = heroData.scope_p;
        extraDrop_p = heroData.extraDrop_p;
        extraMoney_p = heroData.extraMoney_p;
        extraXP_p = heroData.extraXP_p;

        for (int i = 0; i < heroData.SkillSO.Count; i++)
        {
            SkillScriptObject sso = heroData.SkillSO[i];

            skillAttrs.Add(new SkillAttrAfterUpdate());
            skillAttrs[i].damage = sso.Damage;
            skillAttrs[i].projectileSpeed = sso.ProjectileSpeed;
            skillAttrs[i].projectileCount = sso.ProjectileCount;
            skillAttrs[i].cooldown = sso.Cooldown;
            skillAttrs[i].leadTime = sso.LeadTime;
            skillAttrs[i].pulsingTime = sso.PulsingTime;
            skillAttrs[i].scope = sso.Scope;
            skillAttrs[i].duration = sso.Duration;
            skillAttrs[i].distance = sso.Distance;
            skillAttrs[i].aimOffset = sso.AimOffset;
            skillAttrs[i].projectileObj = sso.ProjectileObj;
        }
    }
}

[System.Serializable]
public class SkillAttrAfterUpdate
{
    public float damage;
    public float projectileSpeed;
    public int   projectileCount;
    public float cooldown;
    public float leadTime;
    public float pulsingTime;
    public float scope;
    public float duration;
    public float distance;
    public float aimOffset;
    public GameObject projectileObj;
}

[CustomEditor(typeof(PlayerAttribute))]
public class SOTestingButton : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        PlayerAttribute pa = (PlayerAttribute)target;

        if (GUILayout.Button("_ResetAttrsFromSO_"))
        {
            pa.initialize();
        }
    }
}