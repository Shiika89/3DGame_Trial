using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ダメージ計算をするためのinterface
/// </summary>
public interface IDamagable
{
    void Damage(int damage);
}
