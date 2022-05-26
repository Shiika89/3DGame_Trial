using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 所持中の宝玉を管理
/// </summary>
public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance { get; private set; }

    [Tooltip("生成するUIの親")]
    [SerializeField] JewerData m_JewelUIParent;


    [Tooltip("装備スロットを格納")]
    [SerializeField] EquipmentJewel[] m_equipmentJewels;
    public EquipmentJewel[] EquipmentJewels { get => m_equipmentJewels; }

    /// <summary>インベントリに表示中のアイテムのデータ</summary>
    public List<JewerData> m_jewerData { get; set; }

    public event Action OnSelectItem;
    public event Action OnOpenInventory;
    public event Action<int> OnDiscard;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        m_jewerData = new List<JewerData>();
    }

    /// <summary>
    /// アイテムを入手するたびリスト中身を消してリスト内のアイテムを表示
    /// </summary>
    public void ItemGet()
    {
        foreach (var item in ItemManager.Instance.HaveItem)
        {
            if (item.Instance) continue;

            // UIの親を生成
            var ui = Instantiate(m_JewelUIParent, transform.position, transform.rotation, transform);
            item.Instance = true;
            ui.SetData(item);　// JewerDataのSetDataを呼んでアイテムの種類を判別
            m_jewerData.Add(ui); // 判別したアイテムをリストに追加
        }
    }

    public void DiscardItem(int id)
    {
        m_jewerData[id].MyDestroy();
        m_jewerData.RemoveAt(id);
        OnDiscard?.Invoke(id);
    }

    public void SelectItem()
    {
        OnSelectItem?.Invoke();
    }
    public void OpenInventory()
    {
        OnOpenInventory?.Invoke();
    }

    public void Sort()
    {
        for (int i = 0; i < m_jewerData.Count; i++)
        {
            m_jewerData[i].transform.SetSiblingIndex(i);
        }
    }
}
