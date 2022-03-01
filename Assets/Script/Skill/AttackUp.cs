using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackUp : SkillBase
{
    [SerializeField] float m_attackBuff;

    float m_totalAttackUp;
    bool m_isAttackUp;

    private void OnEnable()
    {
        m_isAttackUp = true;
        m_totalAttackUp = SkillLv * m_attackBuff;
        PlayerStatus.Instance.Buff = m_totalAttackUp;
    }

    private void OnDisable()
    {
        PlayerStatus.Instance.Buff = 0;
        m_isAttackUp = false;
    }
}
