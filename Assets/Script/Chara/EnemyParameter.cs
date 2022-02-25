using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// エネミーのパラメータを決めるためのクラス
/// レベルに応じて何種類かのステータスを用意できる
/// </summary>
[CreateAssetMenu]
public class EnemyParameter : ScriptableObject
{
    [SerializeField] List<EnemyParameterBase> enemyParameterBases = new List<EnemyParameterBase>();

    public EnemyParameterBase ParaData(int paraData) => enemyParameterBases[paraData];
    
}
