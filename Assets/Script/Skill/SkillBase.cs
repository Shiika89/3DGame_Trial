using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

/// <summary>
/// スキルのベース
/// </summary>
[Serializable]
public class SkillBase : MonoBehaviour
{
    [SerializeField] int m_skillLv;
    public int SkillLv { get => m_skillLv; set => m_skillLv = value; }

    [SerializeField] SkillType m_skillType;
    public SkillType SkillType { get => m_skillType; }

    [Tooltip("スキル発動中に減るスタミナの量")]
    [SerializeField] float m_decreaseSutamina;

    [Tooltip("エフェクトが変わるレベル")]
    [SerializeField] int[] m_efectLv;

    [Tooltip("レベル毎のパーティクル")]
    [SerializeField] GameObject[] m_particleLv;

    public bool IsSkillActive { get; set; }

    public virtual void SkillEffect()
    {
        if (Input.GetKeyDown(KeyCode.F) && PlayerStatus.Instance.Sutamina > 0 && !IsSkillActive)
        {
            IsSkillActive = true;
            //Debug.Log("スキル発動");
            if (SkillLv >= m_efectLv[0])
            {
                m_particleLv[0].SetActive(true);
            }
            if (SkillLv >= m_efectLv[1])
            {
                m_particleLv[1].SetActive(true);
            }
            if (SkillLv >= m_efectLv[2])
            {
                m_particleLv[2].SetActive(true);
            }
        }

        if (IsSkillActive)
        {
            PlayerStatus.Instance.Sutamina -= m_decreaseSutamina;
            if (PlayerStatus.Instance.Sutamina <= 0 || Input.GetKeyDown(KeyCode.C))
            {
                //Debug.Log("スキル終了");
                IsSkillActive = false;

                m_particleLv[0].SetActive(false);
                m_particleLv[1].SetActive(false);
                m_particleLv[2].SetActive(false);
            }
        }
    }
}
