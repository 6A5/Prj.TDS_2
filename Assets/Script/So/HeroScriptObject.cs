using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

[CreateAssetMenu(fileName = "HeroData", menuName = "ScriptableObjects/HeroData", order = 1)]
public class HeroScriptObject : ScriptableObject
{
    [Header("非%數")]
    [Tooltip("最大生命")]
    public float maxHP;
    [Tooltip("血量回復")]
    public float hpRecovery;
    [Tooltip("移動速度")]
    public float movementSpd;
    [Tooltip("防禦")]
    public float defense;
    [Tooltip("額外投射物")]
    public int extraProjectile;
    [Tooltip("額外生命")]
    public int extraLife;

    [Header("%數")]
    [Tooltip("最大生命趴數")]
    public float maxHP_p;
    [Tooltip("移動速度趴數")]
    public float movementSpd_p;
    [Tooltip("傷害加成趴數")]
    public float damage_p;
    [Tooltip("冷卻時間趴數")]
    public float cooldown_p;
    [Tooltip("持續時間趴數")]
    public float duration_p;
    [Tooltip("範圍趴數")]
    public float scope_p;
    [Tooltip("額外掉落趴數")]
    public float extraDrop_p;
    [Tooltip("額外金幣趴數")]
    public float extraMoney_p;
    [Tooltip("額外經驗趴數")]
    public float extraXP_p;

    [Header("技能")]
    [SerializeField] private List<SkillScriptObject> _skillSO = new List<SkillScriptObject>();

    public List<SkillScriptObject> SkillSO { get => _skillSO; set => _skillSO = value; }

#if UNITY_EDITOR
    [ContextMenu("Make New SKILL")]
    void MakeNewSkill()
    {
        // 實例化新的 SSO (Skill Scriptable Object)
        SkillScriptObject skillSO = ScriptableObject.CreateInstance<SkillScriptObject>();
        skillSO.name = "New Skill";
        skillSO.Initialise(this);
        // 增加到 List 之中
        _skillSO.Add(skillSO);

        // 儲存實例到這個腳本化物件裡面
        AssetDatabase.AddObjectToAsset(skillSO, this);
        AssetDatabase.SaveAssets();

        // 標記起來 標記-"Dirty"
        EditorUtility.SetDirty(this);
        EditorUtility.SetDirty(skillSO);
    }
#endif

#if UNITY_EDITOR
    [ContextMenu("Deleta ALL")]
    void DeleteAll()
    {
        // 從最後面往回刪除 先減1 後檢查 (大概)
        for (int i = _skillSO.Count; i-- > 0;)
        {
            // 抓出最後的
            SkillScriptObject tmp = _skillSO[i];

            _skillSO.Remove(tmp);
            // 刪除UNDO的資料
            Undo.DestroyObjectImmediate(tmp);
        }
        // 儲存狀態
        AssetDatabase.SaveAssets();
    }
#endif
}
