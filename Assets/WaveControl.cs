using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WaveControl : MonoBehaviour
{
    private static WaveControl _instance;
    public static WaveControl Instance
    {
        get
        {
            return _instance;
        }
    }

    [SerializeField, Header("笴栏家Α")]
    private int gameMode = 0; // 0: Survive 1: Defence

    [SerializeField, Header("程猧计")]
    private int maxWave = 20;
    private int currentWave = 0;

    [SerializeField, Header("–猧秨﹍")]
    private bool waveStart;

    [SerializeField, Header("–猧┣计秖")]
    private List<WaveControlInfo.EnemiesIndex> waves = new List<WaveControlInfo.EnemiesIndex>();

    [SerializeField, Header("┣SO, 絪腹抖")]
    private EnemyScriptObject[] enemyData;

    [SerializeField, Header("┣初春计秖")]
    private List<GameObject> enemyInScene = new List<GameObject>();

    [SerializeField, Header("┣猧计眏て戈癟")]
    private List<WaveControlInfo.BonusInfo> bonusInfo = new List<WaveControlInfo.BonusInfo>();

    private List<Transform> enemySpawnPoint = new List<Transform>();

    [SerializeField, Header("┣家狾")]
    private GameObject enemyTemp;

    [SerializeField, Header("UI")]
    private TextMeshProUGUI tmpWaveInfo;

    private bool allClear = false;

    [Header("產")]
    public bool isPlayerDead = false;

    private void Awake()
    {
        _instance = this;

        GetAllSpawnPoint();

        allClear = false;
        isPlayerDead = false;
    }
    private void Start()
    {
        UpdateWaveInfo();
        StartCoroutine(StartWave());
    }
    private void Update()
    {
        UpdateWave();

        /*
        if (Input.GetKeyDown(KeyCode.Equals))
        {
            StartCoroutine(StartWave());
        }
        */
    }

    /// <summary>
    /// 秨﹍猧计
    /// </summary>
    /// <returns></returns>
    IEnumerator StartWave()
    {
        yield return new WaitForSeconds(3f);
        waveStart = true;
    }

    private void UpdateWaveInfo()
    {
        tmpWaveInfo.text = "Wave : " + currentWave + " / " + maxWave;
    }


    /// <summary>
    /// ъ┮Τネ翴
    /// </summary>
    private void GetAllSpawnPoint()
    {
        Transform _spg = GameObject.Find("SpawnPointGroup").transform;
        for (int i = 0; i < _spg.childCount; i++)
        {
            enemySpawnPoint.Add(_spg.GetChild(i).transform);
        }
    }

    /// <summary>
    /// ネΘ寄 絪腹 wave-index-count
    /// </summary>
    private void SpawnWaveEnemy()
    {
        if (waveStart) return;

        for (int i = 0; i < waves[currentWave].index.Count; i++) // ъindex
        {
            for (int c = 0; c < waves[currentWave].index[i].count; c++) // ъ计秖
            {
                int randomPos = (int)Random.Range(0, enemySpawnPoint.Count - 1);
                Vector3 randomOffset = new Vector2(Random.Range(0, 1), Random.Range(0, 1));
                GameObject enemy = Instantiate(enemyTemp, enemySpawnPoint[randomPos].position + randomOffset * 1.5f, Quaternion.identity);
                enemy.GetComponent<EnemyAttribute>().SetEnemyData(enemyData[i]);
                enemy.name = currentWave + "-" + i + "-" + c + "- Enemy";
                enemy.SetActive(true);

                enemyInScene.Add(enemy);
            }
        }

        waveStart = true;
    }

    private bool CheckWaveClear()
    {
        if (enemyInScene.Count == 0 && waveStart)
        {
            waveStart = false;
            return true;
        }
        else
        {
            return false;
        }
    }

    private void UpdateWave()
    {

        if (!CheckWaveClear()) return;

        if (currentWave < maxWave)
        {
            SpawnWaveEnemy();
            currentWave++;
            UpdateWaveInfo();
        }

        if (currentWave == maxWave && !allClear && enemyInScene.Count == 0)
        {
            allClear = true;
            GameMenuControl.Instance.EndGame(true);
        }
    }

    /// <summary>
    /// 埃い戈
    /// </summary>
    /// <param name="enemy"></param>
    public void DeleteOnEnemyList(GameObject enemy)
    {
        if (enemyInScene.Contains(enemy))
        {
            enemyInScene.Remove(enemyInScene.Find(x => x.name == enemy.name));
        }
    }

}

namespace WaveControlInfo
{
    [System.Serializable]
    public class EnemiesIndex
    {
        [Header("┣絪腹")]
        public List<EnemiesCount> index = new List<EnemiesCount>();
    }

    [System.Serializable]
    public class EnemiesCount
    {
        [Header("┣计秖")]
        public int count = 0;
    }

    [System.Serializable]
    public class BonusInfo
    {
        [Header("瞯Α : 1.00f")]
        public float hpBonus = 1;
        public float damageBonus = 1;
        public float moveBonus = 1;
    }
}


