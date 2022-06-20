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
        // �K�[��s���s
        refreshButton = this.transform.Find("btnRefresh").GetComponent<Button>();
        refreshButton.onClick.AddListener(() => RefreshButtonEvent());

        nextText = this.transform.Find("txtNext").GetComponent<TextMeshProUGUI>();
        nextText.text = "Next : " + coinRequire;

        InitializeItemBoxes();
        RandomItemShowList();

        shopContainer.gameObject.SetActive(false);
        refreshButton.gameObject.SetActive(false);
        nextText.gameObject.SetActive(false);

        // ���U�ƥ�
        InGameUIEvents.Instance.uiSwitchEvent.AddListener(ShopUISwitch);
    }

    /// <summary>
    /// ��l�ƹD�����
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
            // onClick�ƥ�
        }
    }

    /// <summary>
    /// �H�����T�ӹD��
    /// </summary>
    void RandomItemShowList()
    {
        // �����ª����
        itemShowList.Clear();

        for (int i = 0; i < boxesPerOnePage; i++)
        {
            // ��X���s
            Button boxBtn = itemBoxes[i].transform.transform.Find("btnBuy").GetComponent<Button>();
            // �M�zEvent
            boxBtn.onClick.RemoveAllListeners();

            // ���H���@��
            var choseItem = itemRandomList[Random.Range(0, itemRandomList.Count)];
            // while �H���X�Ӫ����]�t�bList�̭� ���s�H��
            while (itemShowList.Find(x => x.itemName == choseItem.itemName))
            {
                choseItem = itemRandomList[Random.Range(0, itemRandomList.Count)];
            }

            itemShowList.Add(choseItem);

            // �K�[Event
            boxBtn.onClick.AddListener(() => BuyItemAndAddToPlayer(choseItem));

            // ��sList�P�ɨ�sUI�òK�[Events
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
    /// ��s�Ϥ�
    /// </summary>
    /// <param name="box">UI����</param>
    /// <param name="iso">�n��ܪ��D��DATA</param>
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

        // �W�[�����ݨD
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