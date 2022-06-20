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
        // ���}�﨤���
        btnStartGame.onClick.AddListener(() => OpenAndCloseUI(menuCharacter));
        // �����﨤���
        btnCharNo.onClick.AddListener(() => OpenAndCloseUI(close: menuCharacter));
        // �����﨤���}����
        btnCharOk.onClick.AddListener(() => OpenAndCloseUI(menuStage, menuCharacter));
        // �����������}�﨤
        btnStaNo.onClick.AddListener(() => OpenAndCloseUI(menuCharacter, menuStage));
        // �T�{����
        btnStaOk.onClick.AddListener(() => sc.ChangeScene("GameTesting"));
    }

    /// <summary>
    /// ���}�M�������
    /// </summary>
    /// <param name="open">�n�}��UI</param>
    /// <param name="close">�n����UI</param>
    private void OpenAndCloseUI(GameObject open = null, GameObject close = null)
    {
        if(open != null) open.SetActive(true);
        if(close != null) close.SetActive(false);
    }

    
}
