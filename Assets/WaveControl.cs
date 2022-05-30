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

    [SerializeField, Header("遊戲模式")]
    private int gameMode = 0; // 0: Survive 1: Defence

    [SerializeField, Header("最大波數")]
    private int maxWave = 20;
    private int currentWave = 0;

    [SerializeField, Header("每波開始")]
    private bool waveStart;

    [SerializeField, Header("每波怪物數量")]
    private List<WaveControlInfo.EnemiesIndex> waves = new List<WaveControlInfo.EnemiesIndex>();

    [SerializeField, Header("怪物SO, 編號為順序")]
    private EnemyScriptObject[] enemyData;

    [SerializeField, Header("怪物在場景數量")]
    private List<GameObject> enemyInScene = new List<GameObject>();

    [SerializeField, Header("怪物波數強化資訊")]
    private List<WaveControlInfo.BonusInfo> bonusInfo = new List<WaveControlInfo.BonusInfo>();

    private List<Transform> enemySpawnPoint = new List<Transform>();

    [SerializeField, Header("怪物模板")]
    private GameObject enemyTemp;

    [SerializeField, Header("UI")]
    private TextMeshProUGUI tmpWaveInfo;

    private void Awake()
    {
        _instance = this;

        GetAllSpawnPoint();
    }
    private void Start()
    {
        UpdateWaveInfo();
    }
    private void Update()
    {
        UpdateWave();

        if (Input.GetKeyDown(KeyCode.Equals))
        {
            waveStart = true;
        }
    }

    private void UpdateWaveInfo()
    {
        tmpWaveInfo.text = "Wave : " + currentWave + " / " + maxWave;
    }


    /// <summary>
    /// 抓到所有的重生點
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
    /// 生成敵人 編號 wave-index-count
    /// </summary>
    private void SpawnWaveEnemy()
    {
        if (waveStart) return;

        for (int i = 0; i < waves[currentWave].index.Count; i++) // 抓index
        {
            for (int c = 0; c < waves[currentWave].index[i].count; c++) // 抓數量
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
        if (CheckWaveClear() && currentWave < maxWave)
        {
            SpawnWaveEnemy();
            currentWave++;
            UpdateWaveInfo();
        }
    }

    /// <summary>
    /// 刪除列表中的資料
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
        [Header("怪物編號")]
        public List<EnemiesCount> index = new List<EnemiesCount>();
    }

    [System.Serializable]
    public class EnemiesCount
    {
        [Header("怪物數量")]
        public int count = 0;
    }

    [System.Serializable]
    public class BonusInfo
    {
        [Header("倍率格式 : 1.00f")]
        public float hpBonus = 1;
        public float damageBonus = 1;
        public float moveBonus = 1;
    }
}


