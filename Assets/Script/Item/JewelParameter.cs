using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Jewelのパラメータを調整出来るように作成、未実装
/// </summary>
[CreateAssetMenu]
public class JewelParameter : ScriptableObject
{
    [SerializeField] public JewelRarity rarity;
    [SerializeField] public JewelType jewelType;
    [SerializeField] public Vector2Int attack;
    [SerializeField] public Vector2Int deffence;
    [SerializeField] public Vector2Int sutamina;
}
