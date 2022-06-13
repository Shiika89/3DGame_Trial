using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KaihiAttack : SkillBase
{
    [SerializeField] float m_baseKaihiDamage;

    [SerializeField] float m_sutaminaBuff;

    [SerializeField] float m_sutaminaLimit = 20;

    float m_totalDamege;
    PlayerMove m_playerMove;
    int m_buffTotal;

    bool m_IsKaihiSkill;

    private void Start()
    {
        m_playerMove = FindObjectOfType<PlayerMove>();
    }

    private void Update()
    {
        SkillEffect();
    }

    private void OnTriggerStay(Collider other)
    {
        if (m_playerMove.m_IsKaihi && m_IsKaihiSkill)
        {
            if (other.gameObject.tag == "Enemy")
            {
                var attack = other.GetComponent<EnemyStatus>();
                m_totalDamege = SkillLv * m_baseKaihiDamage;

                if (attack != null)
                {
                    attack.Status.currentLife -= (int)m_totalDamege;
                }
            }

            if (other.gameObject.tag == "Boss")
            {
                var attack = other.GetComponent<BossStatus>();
                m_totalDamege = SkillLv * m_baseKaihiDamage;

                if (attack != null)
                {
                    attack.Status.currentLife -= (int)m_totalDamege;
                }
            }
        }
    }

    public override void SkillEffect()
    {
        base.SkillEffect();

        if (IsSkillActive && !m_IsKaihiSkill)
        {
            m_IsKaihiSkill = true;
            m_playerMove.KaihiSpeed = m_playerMove.KaihiSpeed * 2;
            m_playerMove.KaihiTime = m_playerMove.KaihiTime / 2;

            m_buffTotal = (int)((PlayerStatus.Instance.MaxSutamina * m_sutaminaBuff) - PlayerStatus.Instance.MaxSutamina);
            PlayerStatus.Instance.MaxSutamina += m_buffTotal;
            PlayerStatus.Instance.Sutamina += m_buffTotal;
        }
        else if(!IsSkillActive && m_IsKaihiSkill)
        {
            m_IsKaihiSkill = false;
            m_playerMove.KaihiSpeed = m_playerMove.KaihiSpeed / 2;
            m_playerMove.KaihiTime = m_playerMove.KaihiTime * 2;

            PlayerStatus.Instance.MaxSutamina -= m_buffTotal;
            if (PlayerStatus.Instance.Sutamina > m_sutaminaLimit)
            {
                PlayerStatus.Instance.Sutamina -= m_buffTotal;
            }
        }
    }
}
