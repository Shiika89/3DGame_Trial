using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct ItemData
{
    public JewelType JewelType { get; private set; }
    public int ID { get; private set; }
    public int Para1 { get; private set; }
    public int Para2 { get; private set; }
    public int Para3 { get; private set; }

    public ItemData(JewelType type,int id,int p1,int p2,int p3)
    {
        JewelType = type;
        ID = id;
        Para1 = p1;
        Para2 = p2;
        Para3 = p3;
    }
}
[CreateAssetMenu]
public class ItemList : ScriptableObject
{
    [SerializeField] ItemBase[] m_items;
    List<ItemData> m_itemDatas = new List<ItemData>();

    public ItemBase GetItem(int id)
    {
        return m_items.Where(item => item.ID == id).FirstOrDefault();
    }
    public void ItemGet(ItemData itemData)
    {
        m_itemDatas.Add(itemData);
    }
}
