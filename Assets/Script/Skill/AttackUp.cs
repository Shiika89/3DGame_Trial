using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackUp : SkillBase
{
    [SerializeField] float m_attackBuff;
    [SerializeField] GameObject m_dualSword;
    //[SerializeField] float m_speed;

    [SerializeField] GameObject m_swordParticle1;
    [SerializeField] GameObject m_swordParticle2;

    //[SerializeField] GameObject m_lvUpParticle;

    float m_totalAttackUp;

    //public bool IsAttackUp { get; set; }

    //bool hatudou;
    //[SerializeField] float time;

    private void Update()
    {
        SkillEffect();
    }

    public override void SkillEffect()
    {
        base.SkillEffect();

        if (IsSkillActive)
        {
            m_dualSword.SetActive(true);
            m_totalAttackUp = SkillLv * m_attackBuff;
            PlayerStatus.Instance.Buff = m_totalAttackUp;

            m_swordParticle1.SetActive(true);
            m_swordParticle2.SetActive(true);
        }
        else
        {
            m_dualSword.SetActive(false);
            m_totalAttackUp = 0;
            PlayerStatus.Instance.Buff = m_totalAttackUp;

            m_swordParticle1.SetActive(false);
            m_swordParticle2.SetActive(false);
        }
    }

    //private void OnEnable()
    //{
    //    IsAttackUp = true;
    //    m_dualSword.SetActive(true);
    //    m_totalAttackUp += SkillLv * m_attackBuff;
    //    PlayerStatus.Instance.Buff = m_totalAttackUp;
    //}

    //private void OnDisable()
    //{
    //    m_dualSword.SetActive(false);
    //    m_totalAttackUp = 0;
    //    PlayerStatus.Instance.Buff = m_totalAttackUp;
    //    IsAttackUp = false;
    //}
}
