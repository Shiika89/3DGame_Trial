using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Jewelのパラメータを調整出来るように作成、未実装
/// </summary>
[CreateAssetMenu]
public class JewelParameter : ScriptableObject
{
    [SerializeField] Vector2Int[] m_high;
    [SerializeField] Vector2Int[] m_medium;
    [SerializeField] Vector2Int[] m_low;

    public Vector2Int[] High { get => m_high; }
    public Vector2Int[] Middle { get => m_medium; }
    public Vector2Int[] Low { get => m_low; }
}
