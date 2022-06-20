using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemData", menuName = "ScriptableObjects/ItemData", order = 3)]
public class ItemScriptObject : ScriptableObject
{
    public string itemName;
    public Sprite icon;
    public string description;

    /*
     Attr
     Value
     SkillIndex
     */
    [System.Serializable]
    public struct ItemData
    {
        public AttrList.Attr itemAttr;
        public float itemAttrValue;
        public int itemSkillIndex;
    }

    public List<ItemData> ItemValue = new List<ItemData>();
}
