using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemManager : MonoBehaviour
{
    public static ItemManager Instance { get; private set; }
    private List<ItemData> m_haveitem = new List<ItemData>();
    [SerializeField] GameObject m_equipmentPanel;
    [SerializeField] GameObject m_JewelUIParent;
    public event Action<ItemData[]> OnItemGet;

    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        //AddEquipmentList();
    }

    public void ItemGet(ItemData data)
    {
        m_haveitem.Add(data);
        OnItemGet?.Invoke(m_haveitem.ToArray());
    }

    void AddEquipmentList()
    {
        if (m_haveitem.Count > 0)
        {
            foreach (var item in m_haveitem)
            {
                Instantiate(m_JewelUIParent, transform.position, transform.rotation, transform.parent);
            }
        }
    }
}
