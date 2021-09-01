using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class StageData : ScriptableObject
{
    [SerializeField] Vector2Int[] m_mapData;
    [SerializeField] int m_satageSize = 5;

    public Vector2Int[] MapData { get => m_mapData; }
    public int StageSize { get => m_satageSize; }
}
