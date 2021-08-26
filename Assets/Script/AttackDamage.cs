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
        var parent = transform.parent.gameObject;
        var chara = parent.GetComponent<Character>();

        var attack = other.GetComponent<IDamagable>();
        if (attack != null)
        {
            attack.Damage(chara.Status.attack);
        }
    }
}
