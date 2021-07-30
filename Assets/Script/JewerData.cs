using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// JewelUの親がどのJewelをアクティブにするか判断
/// </summary>
public class JewerData : MonoBehaviour
{
    [Tooltip("アイテムの種類を格納")]
    [SerializeField] GameObject[] m_viweItem;

    /// <summary>
    /// アイテムの種類によってどのJewelをアクティブにするか判定
    /// </summary>
    /// <param name="itemData"></param>
    public void SetData(ItemData itemData)
    {
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

    /// <summary>
    /// JewelUIの親自身を削除
    /// </summary>
    public void MyDestroy()
    {
        Destroy(gameObject);
    }
}
