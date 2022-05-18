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
    public List<ItemData> HaveItem = new List<ItemData>();

    /// <summary>アイテムを入手するたびに呼ばれるイベント</summary>
    public event Action OnItemGet;

    /// <summary> ドロップした宝玉のリスト </summary>
    public List<GameObject> JewelItem { get; } = new List<GameObject>();

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        // InventoryManagerのOnDiscardイベントに登録
        InventoryManager.Instance.OnDiscard += DiscardItem;
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
}
