using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class EnemyParameter : ScriptableObject
{
    [SerializeField] public int maxLife;
    [SerializeField] public int attack;
    [SerializeField] public int deffence;
    [SerializeField] private float levelBaf;
    public int GetMaxLife(int level) 
    { 
        return maxLife + (int)(maxLife * levelBaf * level);
    }

    public int GetAttack(int level)
    {
        return attack + (int)(attack * levelBaf * level);
    }

    public int GetDeffence(int level)
    {
        return deffence + (int)(deffence * levelBaf * level);
    }
}
