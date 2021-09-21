using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
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
