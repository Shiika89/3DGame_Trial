using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SkillType
{
    AttackUp,
    GuardianArea,
    KaihiAttack,
}

//[Serializable]
//[CreateAssetMenu(fileName = "Skill", menuName = "CreateSkill")]
public class Skill
{
    public SkillType SkillType { get; private set; }
    public JewelRarity JewelRarity { get; set; }
    public int SkillLevel { get; set; }

    public Skill(JewelType type)
    {
        switch (type)
        {
            case JewelType.Red:
                SkillType = SkillType.AttackUp;
                SkillLevel = 1;
                break;
            case JewelType.Blue:
                SkillType = SkillType.GuardianArea;
                SkillLevel = 1;
                break;
            case JewelType.Green:
                SkillType = SkillType.KaihiAttack;
                SkillLevel = 1;
                break;
            default:
                break;
        }
    }
}
