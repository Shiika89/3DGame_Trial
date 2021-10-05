using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttack : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            var parent = transform.parent.gameObject;
            var chara = parent.GetComponent<BossStatus>();

            var attack = other.GetComponent<PlayerStatus>();
            if (attack != null)
            {
                attack.Damage(chara.m_attack);
            }
        }

    }
}
