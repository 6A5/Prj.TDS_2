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
    [SerializeField] private Button btnHint;
    [SerializeField] private GameObject menuHint;
    [SerializeField] private GameObject menuCharacter;
    [SerializeField] private GameObject menuStage;

    private void Start()
    {
        sc = GameObject.Find("SceneManager").GetComponent<SceneControl>();
        InitializeTitleMenuButton();
    }

    private void InitializeTitleMenuButton()
    {
        btnStartGame.onClick.RemoveAllListeners();
        btnCharNo.onClick.RemoveAllListeners();
        btnCharOk.onClick.RemoveAllListeners();
        btnStaNo.onClick.RemoveAllListeners();
        btnStaOk.onClick.RemoveAllListeners();
        btnHint.onClick.RemoveAllListeners();

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
        // 開啟關閉提示
        btnHint.onClick.AddListener(() => SwitchUI(menuHint));
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

    /// <summary>
    /// 開啟或關閉菜單
    /// </summary>
    /// <param name="ui">指定的菜單</param>
    private void SwitchUI(GameObject ui)
    {
        ui.SetActive(!ui.activeSelf);
    }
}
