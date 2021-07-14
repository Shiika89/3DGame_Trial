using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JewerData : MonoBehaviour
{
    [SerializeField] GameObject[] m_viweItem;
    ItemData m_data;
    public void SetData(ItemData itemData)
    {
        m_data = itemData;
        switch (itemData.JewelType)
        {
            case JewelType.Red:
                m_viweItem[0].SetActive(true);
                break;
            case JewelType.Blue:
                m_viweItem[1].SetActive(true);
                break;
            case JewelType.Green:
                m_viweItem[2].SetActive(true);
                break;
            default:
                break;
        }
    }
    public void MyDestroy()
    {
        Destroy(gameObject);
    }
}
