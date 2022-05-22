using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using DG.Tweening;

public class InfoCanvas : MonoBehaviour
{
    // 文字漂浮時間
    [SerializeField] float jumpTime;
    // 文字漂浮高度
    [SerializeField] float jumpHeight;

    private static InfoCanvas _instance = null;

    [SerializeField] TextMeshProUGUI damageText;


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
    }

    public void ShowDamageText(Vector3 pos, float damage)
    {
        TextMeshProUGUI txt = Instantiate(damageText, pos, Quaternion.identity, transform);
        txt.text = damage.ToString();

        float x = Random.Range(-.5f, .5f);
        txt.gameObject.transform.DOJump(txt.gameObject.transform.position + new Vector3(x, jumpHeight, 0), 1, 1, jumpTime);
        txt.gameObject.transform.DOScale(Vector3.one * 2f, jumpTime);

        Destroy(txt.gameObject, jumpTime+0.05f);
    }
}
