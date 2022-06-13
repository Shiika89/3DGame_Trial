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

    [Tooltip("自分のスロットにあった装備詳細のスクリプトを入れる")]
    [SerializeField] EquipmentHelp m_help = default;

    [SerializeField] GameObject m_removeButton;

    /// <summary> 装備するアイテムのクラスを受け取るための変数 </summary>
    SelectJewel m_selectJewel = default;

    [SerializeField] Sprite m_redSprite;
    [SerializeField] Sprite m_blueSprite;
    [SerializeField] Sprite m_greenSprite;
    [SerializeField] Sprite m_toumeiSprite;

    // 受け取ったパラメータを入れる変数
    int m_attack;
    int m_deffence;
    int m_sutamina;


    /// <summary>
    /// 選択したアイテムを装備する時に呼ばれる関数
    /// </summary>
    /// <param name="data"></param>
    public void Eqipment(SelectJewel data)
    {
        SlotOut();

        SlotIn(data);
    }

    /// <summary>
    /// 装備中の宝玉を外す
    /// </summary>
    public void SlotOut()
    {
        // 既に装備スロットに装備されていたら装備から外す
        if (m_selectJewel != null)
        {
            // 装備していたステータスを下げる
            PlayerStatus.Instance.BaseAttack -= m_attack;
            PlayerStatus.Instance.Deffence -= m_deffence;
            PlayerStatus.Instance.MaxSutamina -= m_sutamina;

            // 色を戻す
            m_image.sprite = m_toumeiSprite;
            m_help.SlotOut(m_toumeiSprite);

            // 装備が外れたことをアイテム自身に伝える
            m_selectJewel.SelectOut();

            // スキルを外す
            PlayerSkillList.Instance.m_haveSkillList.Remove(m_selectJewel.m_itemData.Skill);
            PlayerSkillList.Instance.SkillSet();

            m_selectJewel = null;
        }

        m_removeButton.SetActive(false);
    }

    /// <summary>
    /// 宝玉を装備する
    /// </summary>
    /// <param name="data"></param>
    void SlotIn(SelectJewel data)
    {
        // 持っているクラスを受け取ったクラスに置き換える
        m_selectJewel = data;

        m_selectJewel.Equipment();

        m_attack = m_selectJewel.m_itemData.Attack;
        m_deffence = m_selectJewel.m_itemData.Deffence;
        m_sutamina = m_selectJewel.m_itemData.Sutamina;

        // 受け取ったアイテムのパラメータを加算する
        PlayerStatus.Instance.BaseAttack += m_attack;
        PlayerStatus.Instance.Deffence += m_deffence;
        PlayerStatus.Instance.MaxSutamina += m_sutamina;

        // スキルをセット
        PlayerSkillList.Instance.m_haveSkillList.Add(m_selectJewel.m_itemData.Skill);
        PlayerSkillList.Instance.SkillSet();

        // ジュエルの色によって装備スロットの色を変える
        switch (m_selectJewel.JewelType)
        {
            case JewelType.Red:
                m_image.sprite = m_redSprite;
                m_help.ColorChange(m_redSprite);
                break;
            case JewelType.Blue:
                m_image.sprite = m_blueSprite;
                m_help.ColorChange(m_blueSprite);
                break;
            case JewelType.Green:
                m_image.sprite = m_greenSprite;
                m_help.ColorChange(m_greenSprite);
                break;
            default:
                m_image.sprite = m_toumeiSprite;
                break;
        }

        m_help.EquipmentText(m_selectJewel);

        //Debug.Log($"装備しました こ{m_selectJewel.m_itemData.Para1} + ぼ{m_selectJewel.m_itemData.Para2} + す{m_selectJewel.m_itemData.Para3}");
    }

    /// <summary>
    /// 現在未使用
    /// </summary>
    public void GouseiOut()
    {
        PlayerStatus.Instance.BaseAttack -= m_attack;
        PlayerStatus.Instance.Deffence -= m_deffence;
        PlayerStatus.Instance.MaxSutamina -= m_sutamina;

        m_image.sprite = m_toumeiSprite;
        m_help.SlotOut(m_toumeiSprite);

        PlayerSkillList.Instance.m_haveSkillList.Remove(m_selectJewel.m_itemData.Skill);
        PlayerSkillList.Instance.SkillSet();

        // 装備が外れたことをアイテム自身に伝える
        m_selectJewel.SelectOut();
    }

    public void ActiveButton()
    {
        InventoryManager.Instance.RemoveButtin();
        m_removeButton.SetActive(true);
        InventoryManager.Instance.OnRemoveButton += InActiveButton;
    }

    void InActiveButton()
    {
        m_removeButton.SetActive(false);
    }
}
