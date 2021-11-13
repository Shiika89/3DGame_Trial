using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EquipmentJewel : MonoBehaviour
{
    [SerializeField] Image m_image;

    public void Eqipment(int para1, int para2, int para3)
    {
        PlayerStatus.m_attack += para1;
        PlayerStatus.m_deffence += para2;
        PlayerStatus.m_maxSutamina += para3;

        Debug.Log($"装備しました こ{para1} + ぼ{para2} + す{para3}");
    }

    public void Eqipment(ItemData data)
    {
        PlayerStatus.m_attack += data.Para1;
        PlayerStatus.m_deffence += data.Para2;
        PlayerStatus.m_maxSutamina += data.Para3;

        Debug.Log($"装備しました こ{data.Para1} + ぼ{data.Para2} + す{data.Para3}");
    }

    public void Eqipment(SelectJewel data)
    {
        PlayerStatus.m_attack += data.m_itemData.Para1;
        PlayerStatus.m_deffence += data.m_itemData.Para2;
        PlayerStatus.m_maxSutamina += data.m_itemData.Para3;

        switch (data.JewelType)
        {
            case JewelType.Red:
                m_image.color = Color.red;
                break;
            case JewelType.Blue:
                m_image.color = Color.blue;
                break;
            case JewelType.Green:
                m_image.color = Color.green;
                break;
            default:
                break;
        }

        Debug.Log($"装備しました こ{data.m_itemData.Para1} + ぼ{data.m_itemData.Para2} + す{data.m_itemData.Para3}");
    }
}
