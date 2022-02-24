using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackUp : SkillBase
{
    [SerializeField] float m_attackBuff;

    float m_attackUp;
    bool m_isAttackUp;

    public override void SkillEffect()
    {
        
    }
    private void OnDisable()
    {
        PlayerStatus.Instance.Buff = 0;
        m_isAttackUp = false;
    }
    private void OnEnable()
    {
        m_isAttackUp = true;
        PlayerStatus.Instance.Buff = m_attackBuff;
    }
}
