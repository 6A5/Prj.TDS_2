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

    // 篶Α まノㄏノ Player_Attribute.Instance;
    private static PlayerAttribute _instance = null;
    public static PlayerAttribute Instance
    {
        get
        {
            return _instance;
        }
    }

    // 笆篈

    [Header("獶%计")]
    [Tooltip("程ネ㏑")]
    public float maxHP;
    [Tooltip("﹀秖確")]
    public float hpRecovery;
    [Tooltip("簿笆硉")]
    public float movementSpd;
    [Tooltip("ň縨")]
    public float defense;
    [Tooltip("肂щ甮")]
    public int extraProjectile;
    [Tooltip("肂ネ㏑")]
    public int extraLife;

    [Header("%计")]
    [Tooltip("程ネ㏑瓀计")]
    public float maxHP_p;
    [Tooltip("簿笆硉瓀计")]
    public float movementSpd_p;
    [Tooltip("端甡Θ瓀计")]
    public float damage_p;
    [Tooltip("玱丁瓀计")]
    public float cooldown_p;
    [Tooltip("尿丁瓀计")]
    public float duration_p;
    [Tooltip("絛瞅瓀计")]
    public float scope_p;
    [Tooltip("肂奔辅瓀计")]
    public float extraDrop_p;
    [Tooltip("肂刽瓀计")]
    public float extraMoney_p;
    [Tooltip("肂竒喷瓀计")]
    public float extraXP_p;

    [Header("м")]
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

    #region 穝Attr


    #endregion

    /// <summary>
    /// ﹍て
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