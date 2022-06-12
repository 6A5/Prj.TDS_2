using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class InfoCanvas : MonoBehaviour
{
    [SerializeField] float jumpTime; // ��r�}�B�ɶ�
    [SerializeField] float jumpHeight; // ��r�}�B����
    [SerializeField] float playerInfoDist; // �����q�Z�� 

    private static InfoCanvas _instance = null;

    [SerializeField] TextMeshProUGUI damageText;
    [SerializeField] GameObject player;

    public Transform playerInfo;
    // �����
    public Image hpBar;
    // �ޯ�CD��
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
    /// ���X�ˮ`�r��
    /// </summary>
    /// <param name="pos">��m</param>
    /// <param name="damage">�ˮ`</param>
    /// <param name="color">�C��W��</param>
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
