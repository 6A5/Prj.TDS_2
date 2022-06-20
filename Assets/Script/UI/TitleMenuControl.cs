using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitleMenuControl : MonoBehaviour
{
    private SceneControl sc;
    [SerializeField] private Button btnStartGame;
    [SerializeField] private Button btnCharOk;
    [SerializeField] private Button btnCharNo;
    [SerializeField] private Button btnStaOk;
    [SerializeField] private Button btnStaNo;
    [SerializeField] private GameObject menuCharacter;
    [SerializeField] private GameObject menuStage;

    private void Start()
    {
        sc = GameObject.Find("SceneManager").GetComponent<SceneControl>();
        InitializeTitleMenuButton();
    }

    private void InitializeTitleMenuButton()
    {
        // 打開選角菜單
        btnStartGame.onClick.AddListener(() => OpenAndCloseUI(menuCharacter));
        // 關閉選角菜單
        btnCharNo.onClick.AddListener(() => OpenAndCloseUI(close: menuCharacter));
        // 關閉選角打開選關
        btnCharOk.onClick.AddListener(() => OpenAndCloseUI(menuStage, menuCharacter));
        // 關閉選關打開選角
        btnStaNo.onClick.AddListener(() => OpenAndCloseUI(menuCharacter, menuStage));
        // 確認選關
        btnStaOk.onClick.AddListener(() => sc.ChangeScene("GameTesting"));
    }

    /// <summary>
    /// 打開和關閉菜單
    /// </summary>
    /// <param name="open">要開的UI</param>
    /// <param name="close">要關的UI</param>
    private void OpenAndCloseUI(GameObject open = null, GameObject close = null)
    {
        if(open != null) open.SetActive(true);
        if(close != null) close.SetActive(false);
    }

    
}
