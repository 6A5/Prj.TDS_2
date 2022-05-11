using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Attribute : MonoBehaviour
{
    public HeroScriptObject heroData;

    // �غc�� �H��ޥΨϥ� Player_Attribute.Instance;
    private static Player_Attribute _instance = null;
    public static Player_Attribute Instance
    {
        get
        {
            return _instance;
        }
    }

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

    private void Awake()
    {
        _instance = this;

        #region ��l��
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
