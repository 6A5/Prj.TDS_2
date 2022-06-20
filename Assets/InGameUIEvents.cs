using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InGameUIEvents : MonoBehaviour
{
    private static InGameUIEvents _instance;
    public static InGameUIEvents Instance
    {
        get
        {
            return _instance;
        }
    }

    private void Awake()
    {
        _instance = this;
    }

    public UISwitchEvent uiSwitchEvent = new UISwitchEvent();
}

[System.Serializable]
public class UISwitchEvent : UnityEvent<string, bool> { }