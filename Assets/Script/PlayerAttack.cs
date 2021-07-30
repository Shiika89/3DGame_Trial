using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 攻撃して相手が範囲内にいたときに呼ばれる
/// </summary>
public class PlayerAttack : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        var attack = other.GetComponent<IDamage>();
        if (attack != null)
        {
            attack.Damage(10);
        }
    }
}
