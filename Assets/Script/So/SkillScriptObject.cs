using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class SkillScriptObject : ScriptableObject
{

    // �^���}������
    [SerializeField] private HeroScriptObject _myHSO;

    // �ޯ�W��
    [SerializeField] private string _name;

    // �ޯ��ݩ�
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

    // �ޯફ��
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
    /// ��l��>>��oHeroScriptObject
    /// </summary>
    /// <param name="myHSO">�^���}���ƪ���</param>
    public void Initialise(HeroScriptObject myHSO)
    {
        _myHSO = myHSO;
    }
#endif

#if UNITY_EDITOR
    [ContextMenu("Rename to name")]
    void Rename()
    {
        //����W�l = _name�̭���J���ƭ�
        this.name = _name;
        AssetDatabase.SaveAssets();
        EditorUtility.SetDirty(this);
    }
#endif

#if UNITY_EDITOR
    [ContextMenu("Deleta this")]
    void DeletaThis()
    {
        // �q�^������̭��� SSO list �R���o�Ӫ���
        _myHSO.SkillSO.Remove(this);
        // �R��UNDO����Ƥw���s�إ�
        Undo.DestroyObjectImmediate(this);
        AssetDatabase.SaveAssets();
    }
#endif
}
