using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardianArea : SkillBase
{
    [SerializeField] float m_baseAreaDamege;
    [SerializeField] float m_damegeInterval;

    float m_totalDamege;
    float m_timer;

    private void Update()
    {
        SkillEffect();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Enemy" && IsSkillActive)
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
    }
}
