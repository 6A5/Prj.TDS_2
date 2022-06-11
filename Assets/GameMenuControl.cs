using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

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

    public bool gamePause = false;


    private void Awake()
    {
        _instance = this;

        gamePause = false;
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
    /// 暫停選單>>繼續遊戲
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
}
