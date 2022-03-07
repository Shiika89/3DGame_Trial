using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EquipmentHelp : MonoBehaviour
{
    [SerializeField] Image m_help = default;

    [SerializeField] Text m_text = default;

    public void ColorChange(Sprite sprite)
    {
        m_help.sprite = sprite;
    }

    public void SlotOut(Sprite sprite)
    {
        m_help.sprite = sprite;
        m_text.text = null;
    }

    public void EquipmentText(SelectJewel data)
    {
        m_text.text = $"攻 {data.m_itemData.Para1} 防 {data.m_itemData.Para2} ス {data.m_itemData.Para3}";
    }
}
