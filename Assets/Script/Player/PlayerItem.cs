using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerItem : MonoBehaviour
{
    private static PlayerItem _instance = null;
    public static PlayerItem Instance
    {
        get
        {
            return _instance;
        }
    }

    public List<ItemScriptObject> itemList = new List<ItemScriptObject>();

    // 玩家金幣
    public int ownedCoin = 0;
    [SerializeField] TextMeshProUGUI coinText;

    PlayerAttribute m_attr;
    List<SkillAttrAfterUpdate> m_saau;

    private void Start()
    {
        _instance = this;
        itemList.Clear();

        m_attr = PlayerAttribute.Instance;
        m_saau = PlayerAttribute.Instance.skillAttrs;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            for (int i = 0; i < itemList.Count; i++)
            {
                // AddItemValueToAttr(itemList[i]);
            }
        }
    }

    public void AddCoin(int getCoin)
    {
        ownedCoin += getCoin;
        coinText.text = "Coin : " + ownedCoin.ToString();
    }

    // 取得道具時執行 更新能力
    public void AddItemValueToAttr(ItemScriptObject iso)
    {
        for (int j = 0; j < iso.ItemValue.Count; j++)
        {
            var iV = iso.ItemValue[j];
            switch (iso.ItemValue[j].itemAttr)
            {
                case AttrList.Attr.MaxHP:
                    m_attr.maxHP += iV.itemAttrValue;
                    break;
                case AttrList.Attr.HpRecovery:
                    m_attr.hpRecovery += iV.itemAttrValue;
                    break;
                case AttrList.Attr.MoveSpeed:
                    m_attr.movementSpd += iV.itemAttrValue;
                    break;
                case AttrList.Attr.Defense:
                    m_attr.defense += iV.itemAttrValue;
                    break;
                case AttrList.Attr.ExtraProjectile:
                    m_attr.extraProjectile += (int)iV.itemAttrValue;
                    break;
                case AttrList.Attr.ExtraLife:
                    m_attr.extraLife += (int)iV.itemAttrValue;
                    break;
                case AttrList.Attr.MaxHpPercent:
                    m_attr.maxHP_p += iV.itemAttrValue;
                    break;
                case AttrList.Attr.MoveSpeedPercent:
                    m_attr.movementSpd_p += iV.itemAttrValue;
                    break;
                case AttrList.Attr.DamagePercent:
                    m_attr.damage_p += iV.itemAttrValue;
                    break;
                case AttrList.Attr.CooldownPercent:
                    m_attr.cooldown_p += iV.itemAttrValue;
                    break;
                case AttrList.Attr.DurationPercent:
                    m_attr.duration_p += iV.itemAttrValue;
                    break;
                case AttrList.Attr.ScopePercent:
                    m_attr.scope_p += iV.itemAttrValue;
                    break;
                case AttrList.Attr.ExtraDropPercent:
                    m_attr.extraDrop_p += iV.itemAttrValue;
                    break;
                case AttrList.Attr.ExtraMoneyPercent:
                    m_attr.extraMoney_p += iV.itemAttrValue;
                    break;
                case AttrList.Attr.ExtraXPPercent:
                    m_attr.extraXP_p += iV.itemAttrValue;
                    break;
                case AttrList.Attr.Damage:
                    m_saau[iV.itemSkillIndex].damage += iV.itemAttrValue;
                    break;
                case AttrList.Attr.ProjectileSpeed:
                    m_saau[iV.itemSkillIndex].projectileSpeed += iV.itemAttrValue;
                    break;
                case AttrList.Attr.ProjectileCount:
                    m_saau[iV.itemSkillIndex].projectileCount += (int)iV.itemAttrValue;
                    break;
                case AttrList.Attr.CoolDown:
                    m_saau[iV.itemSkillIndex].cooldown += iV.itemAttrValue;
                    break;
                case AttrList.Attr.LeadTime:
                    m_saau[iV.itemSkillIndex].leadTime += iV.itemAttrValue;
                    break;
                case AttrList.Attr.PulsingTime:
                    m_saau[iV.itemSkillIndex].pulsingTime += iV.itemAttrValue;
                    break;
                case AttrList.Attr.Scope:
                    m_saau[iV.itemSkillIndex].scope += iV.itemAttrValue;
                    break;
                case AttrList.Attr.Duration:
                    m_saau[iV.itemSkillIndex].duration += iV.itemAttrValue;
                    break;
                case AttrList.Attr.Distance:
                    m_saau[iV.itemSkillIndex].distance += iV.itemAttrValue;
                    break;
                case AttrList.Attr.AimOffset:
                    m_saau[iV.itemSkillIndex].aimOffset += iV.itemAttrValue;
                    break;
                case AttrList.Attr.Knockback:
                    m_saau[iV.itemSkillIndex].knockback += iV.itemAttrValue;
                    break;
                case AttrList.Attr.Angle:
                    m_saau[iV.itemSkillIndex].angle += iV.itemAttrValue;
                    break;
                default:
                    break;
            }
        }
    }
}
