using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardianArea : SkillBase
{
    [Tooltip("ダメージの基本値")]
    [SerializeField] float m_baseAreaDamege;

    [Tooltip("ダメージが発生するインターバル")]
    [SerializeField] float m_damegeInterval;

    [Tooltip("発動時に上がる防御力の倍率")]
    [SerializeField] float m_DeffenceBuff;

    float m_totalDamege; // 最終的なダメージ
    float m_timer;
    bool m_isGuardianSkill;
    int m_buffTotal; // 最終的な防御力加算値

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

            m_buffTotal = (int)((PlayerStatus.Instance.Deffence * m_DeffenceBuff) - PlayerStatus.Instance.Deffence);
            PlayerStatus.Instance.Deffence += m_buffTotal;
        }
        else if (!IsSkillActive && m_isGuardianSkill)
        {
            m_isGuardianSkill = false;
            PlayerStatus.Instance.Deffence -= m_buffTotal;
        }
    }
}
