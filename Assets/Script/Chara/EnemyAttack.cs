using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// エネミーが攻撃するためのクラス
/// </summary>
public class EnemyAttack : MonoBehaviour
{
    /// <summary>
    /// 攻撃した時にプレイヤーが入っていれば自分とプレイヤーのステータスを持ってきて
    /// 自分の攻撃力を参照してダメージ関数を呼ぶ
    /// </summary>
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            var parent = transform.parent.gameObject;
            var chara = parent.GetComponent<EnemyStatus>();

            var attack = other.GetComponent<PlayerStatus>();
            if (attack != null)
            {
                attack.Damage(chara.Status.attack);
            }
        }
        
    }
}
