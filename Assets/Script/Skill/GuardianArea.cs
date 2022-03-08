using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardianArea : SkillBase
{
    [SerializeField] float m_baseAreaDamege;
    [SerializeField] float m_damegeInterval;

    float m_totalDamege;
    float m_timer;
    bool m_isGuardianSkill;
    int total;

    private void Update()
    {
        SkillEffect();
    }

    private void OnTriggerStay(Collider other)
    {
        if (IsSkillActive)
        {
            if (other.gameObject.tag == "Enemy")
            {
                var attack = other.GetComponent<EnemyStatus>();
                m_totalDamege = SkillLv * m_baseAreaDamege;

                if (attack != null)
                {
                    m_timer += Time.deltaTime;
                    if (m_timer > m_damegeInterval)
                    {
                        m_timer = 0;
                        attack.Status.currentLife -= (int)m_totalDamege;
                    }
                }
            }

            if (other.gameObject.tag == "Boss")
            {
                var attack = other.GetComponent<BossStatus>();
                m_totalDamege = SkillLv * m_baseAreaDamege;

                if (attack != null)
                {
                    m_timer += Time.deltaTime;
                    if (m_timer > m_damegeInterval)
                    {
                        m_timer = 0;
                        attack.Status.currentLife -= (int)m_totalDamege;
                    }
                }
            }
        }
    }

    public override void SkillEffect()
    {
        base.SkillEffect();

        

        if (IsSkillActive && !m_isGuardianSkill)
        {
            m_isGuardianSkill = true;

            total = (int)((PlayerStatus.Instance.Deffence * 1.5) - PlayerStatus.Instance.Deffence);
            PlayerStatus.Instance.Deffence += total;
            //m_playerMove.KaihiSpeed = m_playerMove.KaihiSpeed * 2;
            //m_playerMove.KaihiTime = m_playerMove.KaihiTime / 2;
        }
        else if (!IsSkillActive && m_isGuardianSkill)
        {
            m_isGuardianSkill = false;
            PlayerStatus.Instance.Deffence -= total;
            //m_playerMove.KaihiSpeed = m_playerMove.KaihiSpeed / 2;
            //m_playerMove.KaihiTime = m_playerMove.KaihiTime * 2;
        }
    }
}
