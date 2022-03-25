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
        if (other.gameObject.tag == "Enemy")
        {
            // 当たった相手のダメージinterfaceを呼んでダメージ処理を行う
            var attack = other.GetComponent<EnemyStatus>();
            if (attack != null)
            {
                attack.Damage(PlayerStatus.Instance.Attack);
            }
        }

        if (other.gameObject.tag == "Boss")
        {
            var attack = other.GetComponent<BossStatus>();
            if (attack != null)
            {
                attack.Damage(PlayerStatus.Instance.Attack);
            }
        }
    }
}
