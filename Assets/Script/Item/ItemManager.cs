using System;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Itemを管理
/// </summary>
public class ItemManager : MonoBehaviour
{
    /// <summary>ItemManagerをInstanceにする</summary>
    public static ItemManager Instance { get; private set; }
    /// <summary>ItemのDataが入ってるリスト</summary>
    static List<ItemData> m_haveItem = default;
    /// <summary>アイテムを入手するたびに呼ばれるイベント</summary>
    public event Action OnItemGet;
    
    /// <summary>m_haveItemをプロパティ化</summary>
    public List<ItemData> HaveItem { get => m_haveItem; }

    private void Awake()
    {
        if (m_haveItem == null)
        {
            m_haveItem = new List<ItemData>();
        }
        Instance = this;
    }
    private void Start()
    {
        InventoryManager.Instance.OnDiscard += DiscardItem;
    }

    public void ItemGet(ItemData data)
    {
        m_haveItem.Add(data);
        for (int i = 0; i < m_haveItem.Count; i++)
        {
            m_haveItem[i].ID = i;
        }
        OnItemGet?.Invoke();
    }

    private void DiscardItem(int id)
    {
        m_haveItem.RemoveAt(id);
    }
}
