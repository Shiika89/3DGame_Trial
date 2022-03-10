using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KaihiAttack : SkillBase
{
    [SerializeField] float m_baseKaihiDamage;
    [SerializeField] ParticleSystem m_effect;
    [SerializeField] float m_sutaminaBuff;

    float m_totalDamege;
    PlayerMove m_playerMove;
    int m_buffTotal;

    bool m_IsKaihiSkill;

    private void Start()
    {
        m_playerMove = FindObjectOfType<PlayerMove>();
        //m_effect.Stop();
    }

    private void Update()
    {
        SkillEffect();

        //if (m_playerMove.m_kaihi)
        //{
        //    m_effect.Play();
        //}
        //else
        //{
        //    m_effect.Stop();
        //}
    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.gameObject.tag == "Enemy" && m_playerMove.m_kaihi && IsSkillActive)
    //    {
    //        var attack = other.GetComponent<EnemyStatus>();
    //        m_totalDamege = SkillLv * m_baseKaihiDamage;

    //        if (attack != null)
    //        {
    //            attack.Status.currentLife -= (int)m_totalDamege;
    //        }
    //    }
    //}

    private void OnTriggerStay(Collider other)
    {
        if (m_playerMove.m_kaihi && m_IsKaihiSkill)
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
            if (PlayerStatus.Instance.Sutamina > 20)
            {
                PlayerStatus.Instance.Sutamina -= m_buffTotal;
            }
        }
    }
}
