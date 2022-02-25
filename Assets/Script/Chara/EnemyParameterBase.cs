using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class EnemyParameterBase
{
    [SerializeField] string EnemyLevel;

    [SerializeField] int level;
    public int Level { get => level; }

    [SerializeField] int maxLife;
    public int MaxLife { get => maxLife; }

    [SerializeField] int attack;
    public int Attack { get => attack; }

    [SerializeField] int deffence;
    public int Deffence { get => deffence; }
}
