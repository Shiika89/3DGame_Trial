using UnityEngine;

/// <summary>
/// スタック領域のscript、Jewelの種類に応じてパラメータを付与
/// </summary>
public class ItemData
{
    /// <summary>宝玉の種類</summary>
    public JewelType JewelType { get; private set; }

    /// <summary>宝玉のレア度</summary>
    public JewelRarity JewelRarity { get; private set; }

    /// <summary>宝玉の攻撃力</summary>
    public int Attack { get; set; }

    /// <summary>宝玉の防御力</summary>
    public int Deffence { get; set; }

    /// <summary>宝玉のスタミナ</summary>
    public int Sutamina { get; set; }

    /// <summary>宝玉がインベントリに登録されてるか</summary>
    public bool Instance { get; set; }

    /// <summary>宝玉自身の番号</summary>
    public int ID { get; set; }

    /// <summary>宝玉のスキル</summary>
    public Skill Skill { get; set; }


    /// <summary>
    /// Jewelの種類、レア度によってパラメータを付与する関数
    /// </summary>
    /// <param name="type"></param>
    public ItemData(JewelType type, JewelRarity rarity, int attack, int deffence, int sutamina)
    {
        JewelType = type;
        JewelRarity = rarity;

        Attack = attack;
        Deffence = deffence;
        Sutamina = sutamina;
    }
}
