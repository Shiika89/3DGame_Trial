using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 赤の宝玉のスキル
/// </summary>
public class AttackUp : SkillBase
{
    [Tooltip("スキル発動時に攻撃力が上がる倍率")]
    [SerializeField] float m_attackBuff;

    [Tooltip("左手の剣オブジェクト")]
    [SerializeField] GameObject m_dualSword;

    [SerializeField] GameObject m_swordParticle1;
    [SerializeField] GameObject m_swordParticle2;

    float m_totalAttackUp; // 最終的な加算値


    private void Update()
    {
        SkillEffect();
    }

    public override void SkillEffect()
    {
        base.SkillEffect();

        if (IsSkillActive)
        {
            m_dualSword.SetActive(true); // 二刀流に
            m_totalAttackUp = SkillLv * m_attackBuff; // 加算値を計算
            PlayerStatus.Instance.Buff = m_totalAttackUp; 

            // エフェクトを発動
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
}
