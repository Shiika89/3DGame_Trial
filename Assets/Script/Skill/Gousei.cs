using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gousei : MonoBehaviour
{
    static public Gousei Instance;

    [SerializeField] Image m_slot1;
    [SerializeField] Image m_slot2;
    [SerializeField] Image m_slot3;

    [SerializeField] Sprite m_redSprite;
    [SerializeField] Sprite m_blueSprite;
    [SerializeField] Sprite m_greenSprite;
    [SerializeField] Sprite m_toumeiSprite;

    [SerializeField] Text m_slot1Text;
    [SerializeField] Text m_slot2Text;
    [SerializeField] Text m_slot3Text;

    [SerializeField] EquipmentJewel[] m_eqipList;

    public bool IsSlot1 { get; set; }
    public bool IsSlot2 { get; set; }

    SelectJewel m_selectJewel1;
    SelectJewel m_selectJewel2;

    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        if (IsSlot1 && IsSlot2)
        {
            var data1 = m_selectJewel1.m_itemData;
            var data2 = m_selectJewel2.m_itemData;

            m_slot3Text.text = $"攻{data1.Para1 + data2.Para1}防{data1.Para2 + data2.Para2}ス{data1.Para3 + data2.Para3}";

            if (data1.Skill.SkillType == data2.Skill.SkillType)
            {
                if (data1.Skill.SkillLevel == data2.Skill.SkillLevel)
                {
                    m_slot3Text.text += $"\nSkill Lv { data1.Skill.SkillLevel + 1}";
                }
                else
                {
                    m_slot3Text.text += $"\nSkill Lv { data1.Skill.SkillLevel}";
                }
            }
            else
            {
                m_slot3Text.text += $"\nSkill Lv { data1.Skill.SkillLevel}";
            }
        }
        else
        {
            m_slot3Text.text = null;
        }
    }

    public void SetJewel1(SelectJewel data)
    {
        SlotChange(m_selectJewel1);

        m_selectJewel1 = data;

        switch (data.JewelType)
        {
            case JewelType.Red:
                m_slot1.sprite = m_redSprite;
                break;
            case JewelType.Blue:
                m_slot1.sprite = m_blueSprite;
                break;
            case JewelType.Green:
                m_slot1.sprite = m_greenSprite;
                break;
            default:
                m_slot1.sprite = m_toumeiSprite;
                break;
        }

        m_slot3.sprite = m_redSprite;

        TextSet(m_selectJewel1, m_slot1Text);
        //m_slot1Text.text = $"攻{data.m_itemData.Para1}防{data.m_itemData.Para2}ス{data.m_itemData.Para3}\nSkill Lv {m_selectJewel1.m_itemData.Skill.SkillLevel}";
    }

    public void SetJewel2(SelectJewel data)
    {
        SlotChange(m_selectJewel2);

        m_selectJewel2 = data;

        switch (data.JewelType)
        {
            case JewelType.Red:
                m_slot2.sprite = m_redSprite;
                break;
            case JewelType.Blue:
                m_slot2.sprite = m_blueSprite;
                break;
            case JewelType.Green:
                m_slot2.sprite = m_greenSprite;
                break;
            default:
                m_slot2.sprite = m_toumeiSprite;
                break;
        }

        TextSet(m_selectJewel2, m_slot2Text);

        //m_slot2Text.text = $"攻{data.m_itemData.Para1}防{data.m_itemData.Para2}ス{data.m_itemData.Para3}\nSkill Lv {m_selectJewel2.m_itemData.Skill.SkillLevel}";
    }

    public void GouseiJewel()
    {
        if (IsSlot1 && IsSlot2)
        {
            m_selectJewel1.m_itemData.Para1 += m_selectJewel2.m_itemData.Para1;
            m_selectJewel1.m_itemData.Para2 += m_selectJewel2.m_itemData.Para2;
            m_selectJewel1.m_itemData.Para3 += m_selectJewel2.m_itemData.Para3;

            if (m_selectJewel1.m_itemData.Skill.SkillType == m_selectJewel2.m_itemData.Skill.SkillType)
            {
                if (m_selectJewel1.m_itemData.Skill.SkillLevel == m_selectJewel2.m_itemData.Skill.SkillLevel)
                {
                    m_selectJewel1.m_itemData.Skill.SkillLevel++;
                }
            }
        }

        SlotReset1();
        SlotReset2();
        m_slot3.sprite = m_toumeiSprite;
    }

    void SlotReset1()
    {
        m_selectJewel1.IsGouseiSelect = false;

        if (m_selectJewel1.IsSlot1)
        {
            m_selectJewel1.Select1();
        }
        else if (m_selectJewel1.IsSlot2)
        {
            m_selectJewel1.Select2();
        }
        else if (m_selectJewel1.IsSlot3)
        {
            m_selectJewel1.Select3();
        }

        m_slot1.sprite = m_toumeiSprite;
        IsSlot1 = false;
        m_selectJewel1 = null;
        

        m_slot1Text.text = null;
    }

    void SlotReset2()
    {
        if (m_selectJewel2.IsSlot1)
        {
            m_eqipList[0].GouseiOut();
            Debug.Log("1");
        }
        else if (m_selectJewel2.IsSlot2)
        {
            m_eqipList[1].GouseiOut();
            Debug.Log("2");
        }
        else if (m_selectJewel2.IsSlot3)
        {
            m_eqipList[2].GouseiOut();
        }

        m_selectJewel2.JewelOut();
        m_slot2.sprite = m_toumeiSprite;
        IsSlot2 = false;
        m_selectJewel2 = null;

        m_slot2Text.text = null;
        //TextSet(m_selectJewel1, m_slot1Text);
        //m_slot1Text.text = $"攻{m_selectJewel1.m_itemData.Para1}防{m_selectJewel1.m_itemData.Para2}ス{m_selectJewel1.m_itemData.Para3}\nSkill Lv {m_selectJewel1.m_itemData.Skill.SkillLevel}";
    }

    void SlotChange(SelectJewel selectJewel)
    {
        if (selectJewel != null)
        {
            selectJewel.IsGouseiSelect = false;
        }
    }

    void TextSet(SelectJewel selectJewel, Text text)
    {
        var data = selectJewel.m_itemData;
        text.text = $"攻{data.Para1}防{data.Para2}ス{data.Para3}\nSkill Lv {data.Skill.SkillLevel}";
    }


}
