using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 生成するマップのデータを作るためのスクリプタブルオブジェクトクラス
/// </summary>
[CreateAssetMenu]
public class StageData : ScriptableObject
{
    /// <summary> floorの種類と向きを決めるための変数/// </summary>
    [SerializeField] Vector2Int[] m_mapData;

    /// <summary> マップの大きさを決めるための変数/// </summary>
    [SerializeField] int m_satageSize = 5;

    public Vector2Int[] MapData { get => m_mapData; }
    public int StageSize { get => m_satageSize; }
}
