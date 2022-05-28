using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolList : MonoBehaviour
{
    private static PoolList _instance = null;

    public static PoolList Instance
    {
        get
        {
            return _instance;
        }
    }

    /// <summary>
    /// �ˮ`�r��
    /// </summary>
    public Transform damageTextPool;
    /// <summary>
    /// �l�u��
    /// </summary>
    public Transform projectilesPool;

    private void Awake()
    {
        _instance = this;
    }
}
