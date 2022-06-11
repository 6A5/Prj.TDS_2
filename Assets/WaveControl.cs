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

    [SerializeField, Header("�C���Ҧ�")]
    private int gameMode = 0; // 0: Survive 1: Defence

    [SerializeField, Header("�̤j�i��")]
    private int maxWave = 20;
    private int currentWave = 0;

    [SerializeField, Header("�C�i�}�l")]
    private bool waveStart;

    [SerializeField, Header("�C�i�Ǫ��ƶq")]
    private List<WaveControlInfo.EnemiesIndex> waves = new List<WaveControlInfo.EnemiesIndex>();

    [SerializeField, Header("�Ǫ�SO, �s��������")]
    private EnemyScriptObject[] enemyData;

    [SerializeField, Header("�Ǫ��b�����ƶq")]
    private List<GameObject> enemyInScene = new List<GameObject>();

    [SerializeField, Header("�Ǫ��i�Ʊj�Ƹ�T")]
    private List<WaveControlInfo.BonusInfo> bonusInfo = new List<WaveControlInfo.BonusInfo>();

    private List<Transform> enemySpawnPoint = new List<Transform>();

    [SerializeField, Header("�Ǫ��ҪO")]
    private GameObject enemyTemp;

    [SerializeField, Header("UI")]
    private TextMeshProUGUI tmpWaveInfo;

    private bool allClear = false;

    [Header("���a���`")]
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
    /// �}�l�i��
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
    /// ���Ҧ��������I
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
    /// �ͦ��ĤH �s�� wave-index-count
    /// </summary>
    private void SpawnWaveEnemy()
    {
        if (waveStart) return;

        for (int i = 0; i < waves[currentWave].index.Count; i++) // ��index
        {
            for (int c = 0; c < waves[currentWave].index[i].count; c++) // ��ƶq
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
    /// �R���C�������
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
        [Header("�Ǫ��s��")]
        public List<EnemiesCount> index = new List<EnemiesCount>();
    }

    [System.Serializable]
    public class EnemiesCount
    {
        [Header("�Ǫ��ƶq")]
        public int count = 0;
    }

    [System.Serializable]
    public class BonusInfo
    {
        [Header("���v�榡 : 1.00f")]
        public float hpBonus = 1;
        public float damageBonus = 1;
        public float moveBonus = 1;
    }
}


