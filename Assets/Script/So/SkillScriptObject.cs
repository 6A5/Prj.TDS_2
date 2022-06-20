using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class SkillScriptObject : ScriptableObject
{

    // 英雄腳本物件
    [SerializeField, Tooltip("英雄")]
    private HeroScriptObject _myHSO;

    [Space(15)]
    // 技能名稱
    [SerializeField, Tooltip("名稱")]
    private string _name;

    [Space(15)]
    // 技能屬性
    [SerializeField, Tooltip("傷害")] 
    private float _damage;          
    [SerializeField, Tooltip("速度")]
    private float _projectileSpeed; 
    [SerializeField, Tooltip("數量")]
    private int   _projectileCount; 
    [SerializeField, Tooltip("冷卻")]
    private float _cooldown;        
    [SerializeField, Tooltip("前導")]
    private float _leadTime;        
    [SerializeField, Tooltip("脈衝")]
    private float _pulsingTime;     
    [SerializeField, Tooltip("範圍")]
    private float _scope;           
    [SerializeField, Tooltip("持續")]
    private float _duration;        
    [SerializeField, Tooltip("距離")]
    private float _distance;        
    [SerializeField, Tooltip("偏移")]
    private float _aimOffset;       
    [SerializeField, Tooltip("擊退")]
    private float _knockback;
    [SerializeField, Tooltip("角度")]
    private float _angle;

    [Space(15)]
    // 技能物件
    [SerializeField, Tooltip("子彈Prefab")] private GameObject _projectileObj; // 子彈Prefab

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
    public float Knockback { get => _knockback; }
    public float Angle { get => _angle; }

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
