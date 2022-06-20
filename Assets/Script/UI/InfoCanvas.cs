using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class InfoCanvas : MonoBehaviour
{
    [SerializeField] float jumpTime; // 文字漂浮時間
    [SerializeField] float jumpHeight; // 文字漂浮高度
    [SerializeField] float playerInfoDist; // 角色血量距離 

    private static InfoCanvas _instance = null;

    [SerializeField] TextMeshProUGUI damageText;
    [SerializeField] GameObject player;

    public Transform playerInfo;
    // 血條圖
    public Image hpBar;
    // 技能CD圖
    public Image spSkill;
    public Image throwSkill;
    public Image ultSkill;


    public static InfoCanvas Instance
    {
        get
        {
            return _instance;
        }
    }

    private void Awake()
    {
        _instance = this;

        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        playerInfo.position = player.transform.position + new Vector3(0, playerInfoDist, 0);
    }

    /// <summary>
    /// 跳出傷害字型
    /// </summary>
    /// <param name="pos">位置</param>
    /// <param name="damage">傷害</param>
    /// <param name="color">顏色名稱</param>
    public void ShowDamageText(Vector3 pos, float damage, Color color)
    {
        TextMeshProUGUI txt = Instantiate(damageText, pos, Quaternion.identity, PoolList.Instance.damageTextPool);
        txt.text = damage.ToString();
        txt.color = color;

        float x = Random.Range(-.5f, .5f);
        txt.gameObject.transform.DOJump(txt.gameObject.transform.position + new Vector3(x, jumpHeight, 0), 1, 1, jumpTime - 0.01f);
        txt.gameObject.transform.DOScale(Vector3.one * 2f, jumpTime).OnComplete(() => DestroyText(txt));

    }

    private void DestroyText(TextMeshProUGUI txt) 
    {
        Destroy(txt.gameObject);
    }

}
