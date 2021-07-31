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
    private List<ItemData> m_haveItem = new List<ItemData>();
    /// <summary>アイテムを入手するたびに呼ばれるイベント</summary>
    public event Action OnItemGet;
    /// <summary>m_haveItemをプロパティ化</summary>
    public List<ItemData> HaveItem { get => m_haveItem; }

    private void Awake()
    {
        Instance = this;
    }

    public void ItemGet(ItemData data)
    {
        m_haveItem.Add(data);
        OnItemGet?.Invoke();
    }
}
