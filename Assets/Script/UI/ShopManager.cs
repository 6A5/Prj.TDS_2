using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    [SerializeField] List<ItemScriptObject> itemRandomList = new List<ItemScriptObject>();
    [SerializeField] List<ItemScriptObject> itemShowList = new List<ItemScriptObject>();
    [SerializeField] GameObject itemBoxOrigin;
    [SerializeField] List<GameObject> itemBoxes = new List<GameObject>();
    [SerializeField] Transform shopContainer;
    [SerializeField] int boxesPerOnePage;

    int coinRequire = 50;
    Button refreshButton;
    TextMeshProUGUI nextText;

    private void Start()
    {
        // 添加刷新按鈕
        refreshButton = this.transform.Find("btnRefresh").GetComponent<Button>();
        refreshButton.onClick.AddListener(() => RefreshButtonEvent());

        nextText = this.transform.Find("txtNext").GetComponent<TextMeshProUGUI>();
        nextText.text = "Next : " + coinRequire;

        InitializeItemBoxes();
        RandomItemShowList();

        shopContainer.gameObject.SetActive(false);
        refreshButton.gameObject.SetActive(false);
        nextText.gameObject.SetActive(false);

        // 註冊事件
        InGameUIEvents.Instance.uiSwitchEvent.AddListener(ShopUISwitch);
    }

    /// <summary>
    /// 初始化道具欄位
    /// </summary>
    void InitializeItemBoxes()
    {
        for (int i = 0; i < boxesPerOnePage; i++)
        {
            var newBox = Instantiate(itemBoxOrigin, shopContainer) as GameObject;
            newBox.SetActive(true);
            itemBoxes.Add(newBox);

            // Button boxBtn = newBox.transform.transform.Find("btnBuy").GetComponent<Button>();
            // boxBtn.onClick.AddListener(() => BuyItemAndAddToPlayer(itemShowList[i]));
            // onClick事件
        }
    }

    /// <summary>
    /// 隨機抽選三個道具
    /// </summary>
    void RandomItemShowList()
    {
        // 移除舊的資料
        itemShowList.Clear();

        for (int i = 0; i < boxesPerOnePage; i++)
        {
            // 抓出按鈕
            Button boxBtn = itemBoxes[i].transform.transform.Find("btnBuy").GetComponent<Button>();
            // 清理Event
            boxBtn.onClick.RemoveAllListeners();

            // 先隨機一次
            var choseItem = itemRandomList[Random.Range(0, itemRandomList.Count)];
            // while 隨機出來的有包含在List裡面 重新隨機
            while (itemShowList.Find(x => x.itemName == choseItem.itemName))
            {
                choseItem = itemRandomList[Random.Range(0, itemRandomList.Count)];
            }

            itemShowList.Add(choseItem);

            // 添加Event
            boxBtn.onClick.AddListener(() => BuyItemAndAddToPlayer(choseItem));

            // 更新List同時刷新UI並添加Events
            UpdateItemBoxInfo(itemBoxes[i], choseItem);
        }
    }

    void RefreshButtonEvent()
    {
        if (PlayerItem.Instance.ownedCoin < 40)
        {
            return;
        }

        RandomItemShowList();
        PlayerItem.Instance.AddCoin(-40);
    }

    /// <summary>
    /// 更新圖片
    /// </summary>
    /// <param name="box">UI物件</param>
    /// <param name="iso">要顯示的道具DATA</param>
    void UpdateItemBoxInfo(GameObject box, ItemScriptObject iso)
    {
        Image boxIcon = box.transform.Find("IconUnder").GetChild(0).GetComponent<Image>();
        boxIcon.sprite = iso.icon;

        TextMeshProUGUI boxDesc = box.transform.Find("txtDes").GetComponent<TextMeshProUGUI>();
        boxDesc.text = iso.description;
    }

    void BuyItemAndAddToPlayer(ItemScriptObject buyItem)
    {
        if (PlayerItem.Instance.ownedCoin < coinRequire)
        {
            return;
        }

        PlayerItem.Instance.AddCoin(-coinRequire);
        
        PlayerItem.Instance.itemList.Add(buyItem);
        PlayerItem.Instance.AddItemValueToAttr(buyItem);

        // 增加金錢需求
        coinRequire += 25;
        nextText.text = "Next : " + coinRequire;

        RandomItemShowList();
    }

    void ShopUISwitch(string name, bool act)
    {
        if (name != "Shop") return;
        if (act) { Time.timeScale = 0.3f; } else { Time.timeScale = 1f; }

        shopContainer.gameObject.SetActive(act);
        refreshButton.gameObject.SetActive(act);
        nextText.gameObject.SetActive(act);
    }
}