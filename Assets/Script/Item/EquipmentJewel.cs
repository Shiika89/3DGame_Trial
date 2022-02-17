﻿using System.Collections;
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
        PlayerStatus.Instance.Attack += para1;
        PlayerStatus.Instance.Deffence += para2;
        PlayerStatus.Instance.MaxSutamina += para3;

        Debug.Log($"装備しました こ{para1} + ぼ{para2} + す{para3}");
    }

    public void Eqipment(ItemData data)
    {
        PlayerStatus.Instance.Attack += data.Para1;
        PlayerStatus.Instance.Deffence += data.Para2;
        PlayerStatus.Instance.MaxSutamina += data.Para3;

        Debug.Log($"装備しました こ{data.Para1} + ぼ{data.Para2} + す{data.Para3}");
    }

    GameObject m_skill;

    [SerializeField] GameObject m_player;

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
            PlayerStatus.Instance.Attack -= m_selectJewel.m_itemData.Para1;
            PlayerStatus.Instance.Deffence -= m_selectJewel.m_itemData.Para2;
            PlayerStatus.Instance.MaxSutamina -= m_selectJewel.m_itemData.Para3;

            Destroy(m_skill);

            // 装備が外れたことをアイテム自身に伝える
            m_selectJewel.SelectOut();
        }

        // 持っているクラスを受け取ったクラスに置き換える
        m_selectJewel = data;

        // 受け取ったアイテムのパラメータを加算する
        PlayerStatus.Instance.Attack += data.m_itemData.Para1;
        PlayerStatus.Instance.Deffence += data.m_itemData.Para2;
        PlayerStatus.Instance.MaxSutamina += data.m_itemData.Para3;

        switch (data.m_itemData.Skill.skillType)
        {
            case Skill.SkillType.AttackUp:
                PlayerStatus.Instance.AttackUpLevel += data.m_itemData.Skill.skillLevel;
                break;
            case Skill.SkillType.GuardianArea:
                PlayerStatus.Instance.GuardianAreaLevel += data.m_itemData.Skill.skillLevel;
                break;
            case Skill.SkillType.KaihiAttack:
                PlayerStatus.Instance.KaihiAttackLevel += data.m_itemData.Skill.skillLevel;
                break;
            default:
                break;
        }

        m_skill = Instantiate(data.m_itemData.Skill.skill, m_player.transform.position, Quaternion.identity);
        m_skill.transform.parent = m_player.transform;

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
