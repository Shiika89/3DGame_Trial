using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KaihiAttack : SkillBase
{
    [SerializeField] float m_kaihiDamage;
    [SerializeField] ParticleSystem m_effect;
    PlayerMove m_playerMove;

    private void Start()
    {
        m_playerMove = FindObjectOfType<PlayerMove>();
        m_effect.Stop();
    }

    private void Update()
    {
        if (m_playerMove.m_kaihi)
        {
            m_effect.Play();
        }
        else
        {
            m_effect.Stop();
        }
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
