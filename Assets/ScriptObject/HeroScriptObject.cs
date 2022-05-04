using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "HeroData", menuName = "ScriptableObjects/HeroData", order = 1)]
public class HeroScriptObject : ScriptableObject
{
    [Header("獶%计")]

    [Tooltip("程ネ㏑")]
    /// <summary>
    /// 程﹀秖
    /// </summary>
    public float maxHP;

    [Tooltip("﹀秖確")]
    /// <summary>
    /// ﹀秖確
    /// </summary>
    public float hpRecovery;

    [Tooltip("簿笆硉")]
    /// <summary>
    /// 簿笆硉
    /// </summary>
    public float movementSpd;

    [Tooltip("ň縨")]
    /// <summary>
    /// ň縨
    /// </summary>
    public float defense;

    [Tooltip("肂щ甮")]
    /// <summary>
    /// 肂щ甮计秖
    /// </summary>
    public int extraProjectile;

    [Tooltip("肂ネ㏑")]
    /// <summary>
    /// 肂ネ㏑
    /// </summary>
    public int extraLife;

    [Header("%计")]

    [Tooltip("程ネ㏑瓀计")]
    /// <summary>
    /// 程ネ㏑瓀计
    /// </summary>
    public float maxHP_p;

    [Tooltip("簿笆硉瓀计")]
    /// <summary>
    /// 簿笆硉瓀计
    /// </summary>
    public float movementSpd_p;

    [Tooltip("端甡Θ瓀计")]
    /// <summary>
    /// 端甡Θ瓀计
    /// </summary>
    public float damage_p;

    [Tooltip("玱丁瓀计")]
    /// <summary>
    /// 玱丁瓀计
    /// </summary>
    public float cooldown_p;

    [Tooltip("尿丁瓀计")]
    /// <summary>
    /// 尿丁瓀计
    /// </summary>
    public float duration_p;

    [Tooltip("絛瞅瓀计")]
    /// <summary>
    /// 絛瞅瓀计
    /// </summary>
    public float scope_p;

    [Tooltip("肂奔辅瓀计")]
    /// <summary>
    /// 肂奔辅瓀计
    /// </summary>
    public float extraDrop_p;

    [Tooltip("肂刽瓀计")]
    /// <summary>
    /// 肂刽瓀计
    /// </summary>
    public float extraMoney_p;

    [Tooltip("肂竒喷瓀计")]
    /// <summary>
    /// 肂竒喷瓀计
    /// </summary>
    public float extraXP_p;
}
