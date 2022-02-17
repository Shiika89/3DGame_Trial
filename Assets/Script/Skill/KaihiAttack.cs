using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KaihiAttack : MonoBehaviour
{
    [SerializeField] float m_kaihiDamage;
    PlayerMove m_playerMove;

    private void Start()
    {
        m_playerMove = FindObjectOfType<PlayerMove>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy" && m_playerMove.m_kaihi)
        {
            var attack = other.GetComponent<EnemyStatus>();
            if (attack != null)
            {
                attack.Status.currentLife -= (int)m_kaihiDamage;
            }
        }
    }
}
