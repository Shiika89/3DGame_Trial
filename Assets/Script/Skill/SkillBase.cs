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

    public bool IsSkillActive { get; set; }

    public virtual void SkillEffect()
    {

    }
}
