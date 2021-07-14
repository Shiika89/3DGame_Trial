using UnityEngine;
public struct ItemData
{
    public JewelType JewelType { get; private set; }
    public int Para1 { get; private set; }
    public int Para2 { get; private set; }
    public int Para3 { get; private set; }

    public ItemData(JewelType type, int p1, int p2, int p3)
    {
        JewelType = type;
        Para1 = p1;
        Para2 = p2;
        Para3 = p3;
    }
    public ItemData(JewelType type)
    {
        JewelType = type;
        switch (type)
        {
            case JewelType.Red:
                Para1 = Random.Range(1, 5);
                Para2 = Random.Range(0, 3);
                Para3 = Random.Range(0, 3);
                break;
            case JewelType.Blue:
                Para1 = Random.Range(1, 5);
                Para2 = Random.Range(0, 4);
                Para3 = Random.Range(0, 3);
                break;
            case JewelType.Green:
                Para1 = Random.Range(1, 5);
                Para2 = Random.Range(0, 3);
                Para3 = Random.Range(0, 3);
                break;
            default:
                Para1 = 0;
                Para2 = 0;
                Para3 = 0;
                break;
        }
    }
}
