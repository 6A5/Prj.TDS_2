using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

[CreateAssetMenu(fileName = "HeroData", menuName = "ScriptableObjects/HeroData", order = 1)]
public class HeroScriptObject : ScriptableObject
{
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
    [SerializeField] private List<SkillScriptObject> _skillSO = new List<SkillScriptObject>();

    public List<SkillScriptObject> SkillSO { get => _skillSO; set => _skillSO = value; }

#if UNITY_EDITOR
    [ContextMenu("Make New SKILL")]
    void MakeNewSkill()
    {
        // ��ҤƷs�� SSO (Skill Scriptable Object)
        SkillScriptObject skillSO = ScriptableObject.CreateInstance<SkillScriptObject>();
        skillSO.name = "New Skill";
        skillSO.Initialise(this);
        // �W�[�� List ����
        _skillSO.Add(skillSO);

        // �x�s��Ҩ�o�Ӹ}���ƪ���̭�
        AssetDatabase.AddObjectToAsset(skillSO, this);
        AssetDatabase.SaveAssets();

        // �аO�_�� �аO-"Dirty"
        EditorUtility.SetDirty(this);
        EditorUtility.SetDirty(skillSO);
    }
#endif

#if UNITY_EDITOR
    [ContextMenu("Deleta ALL")]
    void DeleteAll()
    {
        // �q�̫᭱���^�R�� ����1 ���ˬd (�j��)
        for (int i = _skillSO.Count; i-- > 0;)
        {
            // ��X�̫᪺
            SkillScriptObject tmp = _skillSO[i];

            _skillSO.Remove(tmp);
            // �R��UNDO�����
            Undo.DestroyObjectImmediate(tmp);
        }
        // �x�s���A
        AssetDatabase.SaveAssets();
    }
#endif
}
