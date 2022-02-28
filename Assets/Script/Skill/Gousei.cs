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
            m_slot3Text.text = $"こ{m_selectJewel1.m_itemData.Para1 + m_selectJewel2.m_itemData.Para1}ぼ{m_selectJewel1.m_itemData.Para2 + m_selectJewel2.m_itemData.Para2}す{m_selectJewel1.m_itemData.Para3 + m_selectJewel2.m_itemData.Para3}";
        }
    }

    public void SetJewel1(SelectJewel data)
    {
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

        m_slot1Text.text = $"こ{data.m_itemData.Para1}ぼ{data.m_itemData.Para2}す{data.m_itemData.Para3}";
    }

    public void SetJewel2(SelectJewel data)
    {
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

        m_slot2Text.text = $"こ{data.m_itemData.Para1}ぼ{data.m_itemData.Para2}す{data.m_itemData.Para3}";
    }

    public void GouseiJewel()
    {
        if (IsSlot1 && IsSlot2)
        {
            m_selectJewel1.m_itemData.Para1 += m_selectJewel2.m_itemData.Para1;
            m_selectJewel1.m_itemData.Para2 += m_selectJewel2.m_itemData.Para2;
            m_selectJewel1.m_itemData.Para3 += m_selectJewel2.m_itemData.Para3;
        }

        m_selectJewel2.JewelOut();
    }
}
