using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class SkillScriptObject : ScriptableObject
{

    // 英雄腳本物件
    [SerializeField] private HeroScriptObject _myHSO;

    // 技能名稱
    [SerializeField] private string _name;

    // 技能屬性
    [SerializeField] private float _damage;
    [SerializeField] private float _projectileSpeed;
    [SerializeField] private int _projectileCount;
    [SerializeField] private float _cooldown;
    [SerializeField] private float _leadTime;
    [SerializeField] private float _pulsingTime;
    [SerializeField] private float _scope;
    [SerializeField] private float _duration;
    [SerializeField] private float _distance;
    [SerializeField] private float _aimOffset;

    // 技能物件
    [SerializeField] private GameObject _projectileObj;

    public HeroScriptObject MyHSO { get => _myHSO; }

    public string Name { get => _name; }

    public float Damage { get => _damage; }
    public float ProjectileSpeed { get => _projectileSpeed; }
    public int ProjectileCount { get => _projectileCount; }
    public float Cooldown { get => _cooldown; }
    public float LeadTime { get => _leadTime; }
    public float PulsingTime { get => _pulsingTime; }
    public float Scope { get => _scope; }
    public float Duration { get => _duration; }
    public float Distance { get => _distance; }
    public float AimOffset { get => _aimOffset; }

    public GameObject ProjectileObj { get => _projectileObj; }

#if UNITY_EDITOR
    /// <summary>
    /// 初始化>>獲得HeroScriptObject
    /// </summary>
    /// <param name="myHSO">英雄腳本化物件</param>
    public void Initialise(HeroScriptObject myHSO)
    {
        _myHSO = myHSO;
    }
#endif

#if UNITY_EDITOR
    [ContextMenu("Rename to name")]
    void Rename()
    {
        //物件名子 = _name裡面輸入的數值
        this.name = _name;
        AssetDatabase.SaveAssets();
        EditorUtility.SetDirty(this);
    }
#endif

#if UNITY_EDITOR
    [ContextMenu("Deleta this")]
    void DeletaThis()
    {
        // 從英雄物件裡面的 SSO list 刪除這個物件
        _myHSO.SkillSO.Remove(this);
        // 刪除UNDO的資料已重新建立
        Undo.DestroyObjectImmediate(this);
        AssetDatabase.SaveAssets();
    }
#endif
}
