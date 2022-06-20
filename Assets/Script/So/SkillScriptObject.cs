using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class SkillScriptObject : ScriptableObject
{

    // �^���}������
    [SerializeField, Tooltip("�^��")]
    private HeroScriptObject _myHSO;

    [Space(15)]
    // �ޯ�W��
    [SerializeField, Tooltip("�W��")]
    private string _name;

    [Space(15)]
    // �ޯ��ݩ�
    [SerializeField, Tooltip("�ˮ`")] 
    private float _damage;          
    [SerializeField, Tooltip("�t��")]
    private float _projectileSpeed; 
    [SerializeField, Tooltip("�ƶq")]
    private int   _projectileCount; 
    [SerializeField, Tooltip("�N�o")]
    private float _cooldown;        
    [SerializeField, Tooltip("�e��")]
    private float _leadTime;        
    [SerializeField, Tooltip("�߽�")]
    private float _pulsingTime;     
    [SerializeField, Tooltip("�d��")]
    private float _scope;           
    [SerializeField, Tooltip("����")]
    private float _duration;        
    [SerializeField, Tooltip("�Z��")]
    private float _distance;        
    [SerializeField, Tooltip("����")]
    private float _aimOffset;       
    [SerializeField, Tooltip("���h")]
    private float _knockback;
    [SerializeField, Tooltip("����")]
    private float _angle;

    [Space(15)]
    // �ޯફ��
    [SerializeField, Tooltip("�l�uPrefab")] private GameObject _projectileObj; // �l�uPrefab

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
