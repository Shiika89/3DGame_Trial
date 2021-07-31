using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 攻撃して相手が範囲内にいたときに呼ばれる
/// </summary>
public class AttackDamage : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        var attack = other.GetComponent<IDamagable>();
        if (attack != null)
        {
            attack.Damage(10);
        }
    }
}
