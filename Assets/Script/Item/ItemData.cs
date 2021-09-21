using UnityEngine;

/// <summary>
/// スタック領域のscript、Jewelの種類に応じてパラメータを付与
/// </summary>
public struct ItemData
{
    /// <summary>ItemJewelのenumで設定したJewelの種類</summary>
    public JewelType JewelType { get; private set; }
    public int Para1 { get; private set; }
    public int Para2 { get; private set; }

    /// <summary>
    /// Jewelの種類によってパラメータを付与する関数
    /// </summary>
    /// <param name="type"></param>
    public ItemData(JewelType type)
    {
        JewelType = type;
        switch (type)
        {
            case JewelType.Red:
                Para1 = Random.Range(3, 5);
                Para2 = Random.Range(0, -2);
                break;
            case JewelType.Blue:
                Para1 = Random.Range(0, -2);
                Para2 = Random.Range(3, 5);
                break;
            case JewelType.Green:
                Para1 = Random.Range(2, 3);
                Para2 = Random.Range(2, 3);
                break;
            default:
                Para1 = 0;
                Para2 = 0;
                break;
        }
    }
}
