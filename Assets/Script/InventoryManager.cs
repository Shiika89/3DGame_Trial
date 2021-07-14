using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    [SerializeField] JewerData m_JewelUIParent;
    List<JewerData> m_jewerData;

    private void Start()
    {
        ItemManager.Instance.OnItemGet += ItemGet;
        m_jewerData = new List<JewerData>();
    }

    public void ItemGet(ItemData[] itemDatas)
    {
        foreach (var item in m_jewerData)
        {
            //　リストの中身を消してリセットする
            //　オブジェクト自身にデストロイする関数を作っておいて呼ぶ
            item.MyDestroy();
        }
        m_jewerData.Clear();

        foreach (var item in itemDatas)
        {
            //Instantiate(m_JewelUIParent, transform.position, transform.rotation, transform);
            var ui = Instantiate(m_JewelUIParent, transform.position, transform.rotation, transform);
            ui.SetData(item);
            m_jewerData.Add(ui);
        }
    }
}
