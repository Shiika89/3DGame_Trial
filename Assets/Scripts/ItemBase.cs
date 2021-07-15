using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class ItemBase : ScriptableObject
{
    [SerializeField] string m_itemName;
    [SerializeField] int id;
    public string ItemName => m_itemName;
    public int ID => id;
}
