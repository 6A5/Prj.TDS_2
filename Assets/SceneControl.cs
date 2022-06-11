using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneControl : MonoBehaviour
{
    private void Awake()
    {
        KeepThisObjectWork();
    }

    /// <summary>
    /// 保持腳本存在場景上
    /// </summary>
    private void KeepThisObjectWork()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("SceneManager");

        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
    }

    public void CloseMenu(GameObject menu)
    {
        menu.SetActive(false);
    }

    public void OpenMenu(GameObject menu)
    {
        menu.SetActive(true);
    }

    public void ChangeScene(String sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
