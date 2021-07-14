using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


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
