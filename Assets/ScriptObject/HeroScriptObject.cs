using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "HeroData", menuName = "ScriptableObjects/HeroData", order = 1)]
public class HeroScriptObject : ScriptableObject
{
    [Header("�D%��")]

    [Tooltip("�̤j�ͩR")]
    /// <summary>
    /// �̤j��q
    /// </summary>
    public float maxHP;

    [Tooltip("��q�^�_")]
    /// <summary>
    /// ��q�^�_
    /// </summary>
    public float hpRecovery;

    [Tooltip("���ʳt��")]
    /// <summary>
    /// ���ʳt��
    /// </summary>
    public float movementSpd;

    [Tooltip("���m")]
    /// <summary>
    /// ���m
    /// </summary>
    public float defense;

    [Tooltip("�B�~��g��")]
    /// <summary>
    /// �B�~��g���ƶq
    /// </summary>
    public int extraProjectile;

    [Tooltip("�B�~�ͩR")]
    /// <summary>
    /// �B�~�ͩR
    /// </summary>
    public int extraLife;

    [Header("%��")]

    [Tooltip("�̤j�ͩR�w��")]
    /// <summary>
    /// �̤j�ͩR�w��
    /// </summary>
    public float maxHP_p;

    [Tooltip("���ʳt�׭w��")]
    /// <summary>
    /// ���ʳt�׭w��
    /// </summary>
    public float movementSpd_p;

    [Tooltip("�ˮ`�[���w��")]
    /// <summary>
    /// �ˮ`�[���w��
    /// </summary>
    public float damage_p;

    [Tooltip("�N�o�ɶ��w��")]
    /// <summary>
    /// �N�o�ɶ��w��
    /// </summary>
    public float cooldown_p;

    [Tooltip("����ɶ��w��")]
    /// <summary>
    /// ����ɶ��w��
    /// </summary>
    public float duration_p;

    [Tooltip("�d��w��")]
    /// <summary>
    /// �d��w��
    /// </summary>
    public float scope_p;

    [Tooltip("�B�~�����w��")]
    /// <summary>
    /// �B�~�����w��
    /// </summary>
    public float extraDrop_p;

    [Tooltip("�B�~�����w��")]
    /// <summary>
    /// �B�~�����w��
    /// </summary>
    public float extraMoney_p;

    [Tooltip("�B�~�g��w��")]
    /// <summary>
    /// �B�~�g��w��
    /// </summary>
    public float extraXP_p;
}
