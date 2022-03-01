﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gousei : MonoBehaviour
{
    static public Gousei Instance;

    [SerializeField] Image m_slot1;
    [SerializeField] Image m_slot2;
    [SerializeField] Image m_slot3;

    [SerializeField] Text m_slot1Text;
    [SerializeField] Text m_slot2Text;
    [SerializeField] Text m_slot3Text;

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
                m_slot1.color = Color.red;
                break;
            case JewelType.Blue:
                m_slot1.color = Color.blue;
                break;
            case JewelType.Green:
                m_slot1.color = Color.green;
                break;
            default:
                m_slot1.color = Color.white;
                break;
        }

        m_slot3.color = m_slot1.color;

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
                m_slot2.color = Color.red;
                break;
            case JewelType.Blue:
                m_slot2.color = Color.blue;
                break;
            case JewelType.Green:
                m_slot2.color = Color.green;
                break;
            default:
                m_slot2.color = Color.white;
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
                if (m_selectJewel1.m_itemData.Skill.SkillLevel == m_selectJewel1.m_itemData.Skill.SkillLevel)
                {
                    m_selectJewel1.m_itemData.Skill.SkillLevel++;
                }
            }
        }

        SlotReset();
    }

    void SlotReset()
    {
        m_selectJewel2.JewelOut();
        m_slot2.color = Color.white;
        IsSlot2 = false;
        m_selectJewel2 = null;

        m_slot2Text.text = null;
        TextSet(m_selectJewel1, m_slot1Text);
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