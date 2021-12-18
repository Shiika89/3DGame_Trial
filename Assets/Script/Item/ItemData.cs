using UnityEngine;

/// <summary>
/// スタック領域のscript、Jewelの種類に応じてパラメータを付与
/// </summary>
public class ItemData
{
    /// <summary>ItemJewelのenumで設定したJewelの種類</summary>
    public JewelType JewelType { get; private set; }
    public JewelRarity JewelRarity { get; private set; }
    public int Para1 { get; private set; }
    public int Para2 { get; private set; }
    public int Para3 { get; private set; }
    public int paraAdd { get; private set; }
    public bool Instance { get; set; } 
    public int ID { get; set; }
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
                        Para1 = Random.Range(3, 7);
                        Para2 = Random.Range(0, 2);
                        Para3 = Random.Range(-3, 0);
                        break;
                    case JewelRarity.Rare:
                        Para1 = Random.Range(4, 9);
                        Para2 = Random.Range(2, 6);
                        Para3 = Random.Range(0, 3);
                        break;
                    case JewelRarity.SuperRare:
                        Para1 = Random.Range(3, 10);
                        Para2 = Random.Range(0, 1);
                        Para3 = Random.Range(-1, -3);
                        break;
                    default:
                        break;
                }
                break;
            case JewelType.Blue:
                switch (JewelRarity)
                {
                    case JewelRarity.Normal:
                        Para1 = Random.Range(3, 7);
                        Para2 = Random.Range(0, 2);
                        Para3 = Random.Range(-3, 0);
                        break;
                    case JewelRarity.Rare:
                        Para1 = Random.Range(4, 9);
                        Para2 = Random.Range(2, 6);
                        Para3 = Random.Range(0, 3);
                        break;
                    case JewelRarity.SuperRare:
                        Para1 = Random.Range(3, 10);
                        Para2 = Random.Range(0, 1);
                        Para3 = Random.Range(-1, -3);
                        break;
                    default:
                        break;
                }
                break;
            case JewelType.Green:
                switch (JewelRarity)
                {
                    case JewelRarity.Normal:
                        Para1 = Random.Range(3, 7);
                        Para2 = Random.Range(0, 2);
                        Para3 = Random.Range(-3, 0);
                        break;
                    case JewelRarity.Rare:
                        Para1 = Random.Range(4, 9);
                        Para2 = Random.Range(2, 6);
                        Para3 = Random.Range(0, 3);
                        break;
                    case JewelRarity.SuperRare:
                        Para1 = Random.Range(3, 10);
                        Para2 = Random.Range(0, 1);
                        Para3 = Random.Range(-1, -3);
                        break;
                    default:
                        break;
                }
                break;
            default:
                Para1 = 0;
                Para2 = 0;
                Para3 = 0;
                break;
        }
    }
}
