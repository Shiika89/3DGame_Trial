using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Itemを管理
/// </summary>
public class ItemManager : MonoBehaviour
{
    /// <summary>ItemManagerをInstanceにする</summary>
    public static ItemManager Instance { get; private set; }

    /// <summary>ItemのDataが入ってるリスト</summary>
    public List<ItemData> HaveItem = new List<ItemData>();

    /// <summary>アイテムを入手するたびに呼ばれるイベント</summary>
    public event Action OnItemGet;

    /// <summary> ドロップした宝玉のリスト </summary>
    public List<GameObject> JewelItem { get; } = new List<GameObject>();

    public List<ItemDetection> JewelText { get; set; } = new List<ItemDetection>();
    int m_textNum = 0;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        // InventoryManagerのOnDiscardイベントに登録
        InventoryManager.Instance.OnDiscard += DiscardItem;
    }

    private void Update()
    {
        if (JewelText.Count > 0)
        {
            JewelText[m_textNum].Canvas.gameObject.SetActive(true);
            JewelText[m_textNum].Flag = true;
            if (Input.GetKeyDown(KeyCode.R))
            {
                if (m_textNum < JewelText.Count - 1)
                {
                    JewelText[m_textNum].Canvas.gameObject.SetActive(false);
                    JewelText[m_textNum].Flag = false;
                    m_textNum++;
                }
                else
                {
                    JewelText[m_textNum].Canvas.gameObject.SetActive(false);
                    JewelText[m_textNum].Flag = false;
                    m_textNum = 0;
                }
            }
        }
        else
        {
            m_textNum = 0;
        }
    }

    public void ItemGet(ItemData data)
    {
        HaveItem.Add(data);
        for (int i = 0; i < HaveItem.Count; i++)
        {
            HaveItem[i].ID = i;
        }
        InventoryManager.Instance.ItemGet();
        //OnItemGet?.Invoke();
    }

    private void DiscardItem(int id)
    {
        HaveItem.RemoveAt(id);
    }

    public void DeleteJewel()
    {
        foreach (var item in JewelItem)
        {
            Destroy(item);
        }
    }

    public void ChangeIndex()
    {
        if (m_textNum > 0)
        {
            m_textNum--;
        }
    }
}
