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
    /// Jewelの種類によってパラメータを付与する関数
    /// </summary>
    /// <param name="type"></param>
    public ItemData(JewelType type)
    {
        int rarity = Random.Range(1, 10 + 1);
        if (rarity == 10)
        {
            JewelRarity = JewelRarity.SuperRare;
        }
        else if (rarity == 7 || rarity == 8 || rarity == 9)
        {
            JewelRarity = JewelRarity.Rare;
        }
        else
        {
            JewelRarity = JewelRarity.Normal;
        }

        JewelType = type;
        switch (type)
        {
            case JewelType.Red:
                switch (JewelRarity)
                {
                    case JewelRarity.Normal:
                        Attack = Random.Range(3, 5);
                        Deffence = Random.Range(0, 3);
                        Sutamina = Random.Range(-3, 1);
                        break;
                    case JewelRarity.Rare:
                        Attack = Random.Range(5, 10);
                        Deffence = Random.Range(3, 5);
                        Sutamina = Random.Range(1, 3);
                        break;
                    case JewelRarity.SuperRare:
                        Attack = Random.Range(10, 20);
                        Deffence = Random.Range(5, 10);
                        Sutamina = Random.Range(3, 6);
                        break;
                    default:
                        break;
                }
                break;
            case JewelType.Blue:
                switch (JewelRarity)
                {
                    case JewelRarity.Normal:
                        Attack = Random.Range(-3, 1);
                        Deffence = Random.Range(3, 5);
                        Sutamina = Random.Range(0, 3);
                        break;
                    case JewelRarity.Rare:
                        Attack = Random.Range(1, 3);
                        Deffence = Random.Range(5, 10);
                        Sutamina = Random.Range(3, 5);
                        break;
                    case JewelRarity.SuperRare:
                        Attack = Random.Range(3, 6);
                        Deffence = Random.Range(10, 20);
                        Sutamina = Random.Range(5, 10);
                        break;
                    default:
                        break;
                }
                break;
            case JewelType.Green:
                switch (JewelRarity)
                {
                    case JewelRarity.Normal:
                        Attack = Random.Range(0, 3);
                        Deffence = Random.Range(-3, 1);
                        Sutamina = Random.Range(3, 5);
                        break;
                    case JewelRarity.Rare:
                        Attack = Random.Range(3, 5);
                        Deffence = Random.Range(1, 3);
                        Sutamina = Random.Range(5, 10);
                        break;
                    case JewelRarity.SuperRare:
                        Attack = Random.Range(5, 10);
                        Deffence = Random.Range(3, 6);
                        Sutamina = Random.Range(10, 20);
                        break;
                    default:
                        break;
                }
                break;
            default:
                Attack = 0;
                Deffence = 0;
                Sutamina = 0;
                break;
        }
    }
}
