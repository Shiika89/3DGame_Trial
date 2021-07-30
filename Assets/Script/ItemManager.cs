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
    private List<ItemData> m_haveitem = new List<ItemData>();
    public event Action<ItemData[]> OnItemGet;

    private void Awake()
    {
        Instance = this;
    }

    public void ItemGet(ItemData data)
    {
        m_haveitem.Add(data);
        OnItemGet?.Invoke(m_haveitem.ToArray());
    }
}
