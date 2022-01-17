using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 装備したアイテムのパラメータを反映するクラス、装備スロットに付ける
/// </summary>
public class EquipmentJewel : MonoBehaviour
{
    [Tooltip("自分のスロットのイメージを登録")]
    [SerializeField] Image m_image;

    [SerializeField] EquipmentHelp m_help = default;

    /// <summary> 装備するアイテムのクラスを受け取るための変数 </summary>
    SelectJewel m_selectJewel = default;

    public void Eqipment(int para1, int para2, int para3)
    {
        PlayerStatus.m_attack += para1;
        PlayerStatus.m_deffence += para2;
        PlayerStatus.m_maxSutamina += para3;

        Debug.Log($"装備しました こ{para1} + ぼ{para2} + す{para3}");
    }

    public void Eqipment(ItemData data)
    {
        PlayerStatus.m_attack += data.Para1;
        PlayerStatus.m_deffence += data.Para2;
        PlayerStatus.m_maxSutamina += data.Para3;

        Debug.Log($"装備しました こ{data.Para1} + ぼ{data.Para2} + す{data.Para3}");
    }

    /// <summary>
    /// 選択したアイテムを装備する時に呼ばれる関数
    /// </summary>
    /// <param name="data"></param>
    public void Eqipment(SelectJewel data)
    {
        // 既に装備スロットに装備されていたら装備から外す
        if (m_selectJewel != null)
        {
            // 装備していたステータスを下げる
            PlayerStatus.m_attack -= m_selectJewel.m_itemData.Para1;
            PlayerStatus.m_deffence -= m_selectJewel.m_itemData.Para2;
            PlayerStatus.m_maxSutamina -= m_selectJewel.m_itemData.Para3;

            // 装備が外れたことをアイテム自身に伝える
            m_selectJewel.SelectOut();
        }

        // 持っているクラスを受け取ったクラスに置き換える
        m_selectJewel = data;

        // 受け取ったアイテムのパラメータを加算する
        PlayerStatus.m_attack += data.m_itemData.Para1;
        PlayerStatus.m_deffence += data.m_itemData.Para2;
        PlayerStatus.m_maxSutamina += data.m_itemData.Para3;

        // ジュエルの色によって装備スロットの色を変える
        switch (data.JewelType)
        {
            case JewelType.Red:
                m_image.color = Color.red;
                break;
            case JewelType.Blue:
                m_image.color = Color.blue;
                break;
            case JewelType.Green:
                m_image.color = Color.green;
                break;
            default:
                m_image.color = Color.white;
                break;
        }

        m_help.ColorChange(m_image);

        m_help.EquipmentText(data);

        Debug.Log($"装備しました こ{data.m_itemData.Para1} + ぼ{data.m_itemData.Para2} + す{data.m_itemData.Para3}");
    }
}
