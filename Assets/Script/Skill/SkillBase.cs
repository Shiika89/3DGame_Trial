using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class SkillBase : MonoBehaviour
{
    [SerializeField] int m_skillLv;
    public int SkillLv { get => m_skillLv; set => m_skillLv = value; }

    [SerializeField] SkillType m_skillType;
    public SkillType SkillType { get => m_skillType; }

    [Tooltip("スキル発動中に減るスタミナの量")]
    [SerializeField] public float DecreaseSutamina;

    [SerializeField] public GameObject ParticleLv1;
    [SerializeField] public GameObject ParticleLv5;
    [SerializeField] public GameObject ParticleLv10;

    public bool IsSkillActive { get; set; }

    public virtual void SkillEffect()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1) && PlayerStatus.Instance.Sutamina > 0 && !IsSkillActive)
        {
            IsSkillActive = true;
            Debug.Log("スキル発動");
            if (SkillLv >= 1)
            {
                ParticleLv1.SetActive(true);
            }
            if (SkillLv >= 5)
            {
                ParticleLv5.SetActive(true);
            }
            if (SkillLv >= 10)
            {
                ParticleLv10.SetActive(true);
            }
        }

        if (IsSkillActive)
        {
            PlayerStatus.Instance.Sutamina -= DecreaseSutamina;
            if (PlayerStatus.Instance.Sutamina < 5 || Input.GetKeyDown(KeyCode.C))
            {
                Debug.Log("スキル終了");
                IsSkillActive = false;

                ParticleLv1.SetActive(false);
                ParticleLv5.SetActive(false);
                ParticleLv10.SetActive(false);
            }
        }
    }
}
