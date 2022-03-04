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
        PlayerStatus.Instance.BaseAttack += para1;
        PlayerStatus.Instance.Deffence += para2;
        PlayerStatus.Instance.MaxSutamina += para3;

        Debug.Log($"装備しました こ{para1} + ぼ{para2} + す{para3}");
    }

    public void Eqipment(ItemData data)
    {
        PlayerStatus.Instance.BaseAttack += data.Para1;
        PlayerStatus.Instance.Deffence += data.Para2;
        PlayerStatus.Instance.MaxSutamina += data.Para3;

        Debug.Log($"装備しました こ{data.Para1} + ぼ{data.Para2} + す{data.Para3}");
    }

    [SerializeField] GameObject m_player;

    int m_para1;
    int m_para2;
    int m_para3;


    /// <summary>
    /// 選択したアイテムを装備する時に呼ばれる関数
    /// </summary>
    /// <param name="data"></param>
    public void Eqipment(SelectJewel data)
    {
        SlotOut();

        SlotIn(data);
    }

    public void SlotOut()
    {
        // 既に装備スロットに装備されていたら装備から外す
        if (m_selectJewel != null)
        {
            // 装備していたステータスを下げる
            PlayerStatus.Instance.BaseAttack -= m_para1;
            PlayerStatus.Instance.Deffence -= m_para2;
            PlayerStatus.Instance.MaxSutamina -= m_para3;

            m_image.color = Color.white;

            // 装備が外れたことをアイテム自身に伝える
            m_selectJewel.SelectOut();

            PlayerSkillList.Instance.m_haveSkillList.Remove(m_selectJewel.m_itemData.Skill);
            PlayerSkillList.Instance.SkillSet();

            m_selectJewel = null;
            Debug.Log("out");
        }
    }

    void SlotIn(SelectJewel data)
    {
        // 持っているクラスを受け取ったクラスに置き換える
        m_selectJewel = data;

        m_selectJewel.Equipment();

        // 受け取ったアイテムのパラメータを加算する
        PlayerStatus.Instance.BaseAttack += m_selectJewel.m_itemData.Para1;
        PlayerStatus.Instance.Deffence += m_selectJewel.m_itemData.Para2;
        PlayerStatus.Instance.MaxSutamina += m_selectJewel.m_itemData.Para3;

        m_para1 = m_selectJewel.m_itemData.Para1;
        m_para2 = m_selectJewel.m_itemData.Para2;
        m_para3 = m_selectJewel.m_itemData.Para3;

        PlayerSkillList.Instance.m_haveSkillList.Add(m_selectJewel.m_itemData.Skill);
        PlayerSkillList.Instance.SkillSet();

        // ジュエルの色によって装備スロットの色を変える
        switch (m_selectJewel.JewelType)
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

        m_help.EquipmentText(m_selectJewel);

        Debug.Log($"装備しました こ{m_selectJewel.m_itemData.Para1} + ぼ{m_selectJewel.m_itemData.Para2} + す{m_selectJewel.m_itemData.Para3}");
        Debug.Log("in");
    }

    public void GouseiOut()
    {
        PlayerStatus.Instance.BaseAttack -= m_para1;
        PlayerStatus.Instance.Deffence -= m_para2;
        PlayerStatus.Instance.MaxSutamina -= m_para3;

        m_image.color = Color.white;
        m_help.SlotOut();

        PlayerSkillList.Instance.m_haveSkillList.Remove(m_selectJewel.m_itemData.Skill);
        PlayerSkillList.Instance.SkillSet();

        // 装備が外れたことをアイテム自身に伝える
        m_selectJewel.SelectOut();
    }
}
