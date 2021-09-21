using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 
/// </summary>
public class InventoryManager : MonoBehaviour
{
    [Tooltip("生成するUIの親")]
    [SerializeField] JewerData m_JewelUIParent;
    /// <summary>インベントリに表示中のアイテムのデータ</summary>
    List<JewerData> m_jewerData;

    private void Start()
    {
        ItemManager.Instance.OnItemGet += ItemGet;
        m_jewerData = new List<JewerData>();
    }

    /// <summary>
    /// アイテムを入手するたびリスト中身を消してリスト内のアイテムを表示
    /// </summary>
    private void ItemGet()
    {
        foreach (var item in m_jewerData)
        {
            //　オブジェクト自身にデストロイする関数を作っておいて呼ぶ
            item.MyDestroy();
        }
        m_jewerData.Clear();　//　リストの中身を消してリセットする

        foreach (var item in ItemManager.Instance.HaveItem)
        {
            // UIの親を生成
            var ui = Instantiate(m_JewelUIParent, transform.position, transform.rotation, transform);
            ui.SetData(item);　// JewerDataのSetDataを呼んでアイテムの種類を判別
            m_jewerData.Add(ui); // 判別したアイテムをリストに追加
        }
    }
}
