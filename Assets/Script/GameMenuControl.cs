using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameMenuControl : MonoBehaviour
{
    private static GameMenuControl _instance;

    public static GameMenuControl Instance
    {
        get
        {
            return _instance;
        }
    }

    [SerializeField] private KeyCode menuKey;
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject endGameUI;
    [SerializeField] private SceneControl sc;
    [SerializeField] private Button btnTitle;
    [SerializeField] private Button btnQuit;

    public bool gamePause = false;


    private void Awake()
    {
        _instance = this;

        gamePause = false;
    }

    private void Start()
    {
        try
        {
            sc = GameObject.Find("SceneManager").GetComponent<SceneControl>();
            InitializePauseMenuButton();
        }
        catch (System.Exception)
        {
            print("�бq�D���}�l�C���A�p�G�ݭn�Ȱ����\��C");
            print("�S�����SC");
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(menuKey))
        {
            pauseMenu.SetActive(!pauseMenu.activeSelf);
            if (pauseMenu.activeSelf)
            {
                Time.timeScale = 0;
                gamePause = true;
            }
            else
            {
                Time.timeScale = 1;
                gamePause = false;
            }
            
        }
    }

    /// <summary>
    /// �Ȱ����>>�~��C��
    /// </summary>
    public void PauseMenu_Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
        gamePause = false;
    }

    public void EndGame(bool isClear)
    {
        if (isClear)
        {
            endGameUI.SetActive(true);
            endGameUI.GetComponentInChildren<TextMeshProUGUI>().text = "Clear";
        }
        else
        {
            endGameUI.SetActive(true);
            endGameUI.GetComponentInChildren<TextMeshProUGUI>().text = "Fail";
        }
    }

    /// <summary>
    /// ��l�ƫ��s
    /// </summary>
    private void InitializePauseMenuButton() 
    {
        btnTitle.onClick.AddListener(BackToTitle);
        btnQuit.onClick.AddListener(QuitGame);
    }

    private void BackToTitle() 
    {
        sc.ChangeScene("GameTitle");
    }

    private void QuitGame() 
    {
        Application.Quit();
    }
}
