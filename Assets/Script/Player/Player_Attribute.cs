using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Attribute : MonoBehaviour
{
    public HeroScriptObject heroData;

    // 篶Α まノㄏノ Player_Attribute.Instance;
    private static Player_Attribute _instance = null;
    public static Player_Attribute Instance
    {
        get
        {
            return _instance;
        }
    }

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

    private void Awake()
    {
        _instance = this;

        #region ﹍て
        maxHP           = heroData.maxHP;
        hpRecovery      = heroData.hpRecovery;
        movementSpd     = heroData.movementSpd;
        defense         = heroData.defense;
        extraProjectile = heroData.extraProjectile;
        extraLife       = heroData.extraLife;

        maxHP_p         = heroData.maxHP_p;
        movementSpd_p   = heroData.movementSpd_p;
        damage_p        = heroData.damage_p;
        cooldown_p      = heroData.cooldown_p;
        duration_p      = heroData.duration_p;
        scope_p         = heroData.scope_p;
        extraDrop_p     = heroData.extraDrop_p;
        extraMoney_p    = heroData.extraMoney_p;
        extraXP_p       = heroData.extraXP_p;
        #endregion
    }

    private void Start()
    {

    }

}
