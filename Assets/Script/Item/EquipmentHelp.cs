using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 装備中の宝玉のパラメータを表示する
/// </summary>
public class EquipmentHelp : MonoBehaviour
{
    [Tooltip("宝玉のイメージを入れる")]
    [SerializeField] Image m_help = default;

    [Tooltip("宝玉のパラメータを入れるテキスト")]
    [SerializeField] Text m_text = default;

    /// <summary>
    /// 宝玉が装備した時に呼ばれて装備した宝玉と同じ色に変える
    /// </summary>
    /// <param name="sprite"></param>
    public void ColorChange(Sprite sprite)
    {
        m_help.sprite = sprite;
    }

    /// <summary>
    /// 装備から外れたら中身を空っぽにする
    /// </summary>
    /// <param name="sprite"></param>
    public void SlotOut(Sprite sprite)
    {
        m_help.sprite = sprite;
        m_text.text = null;
    }

    /// <summary>
    /// テキスト変える
    /// </summary>
    /// <param name="data"></param>
    public void EquipmentText(SelectJewel data)
    {
        m_text.text = $"攻:{data.m_itemData.Para1} 防:{data.m_itemData.Para2} ス:{data.m_itemData.Para3}";
    }
}
