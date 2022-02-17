using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
[CreateAssetMenu(fileName = "Skill", menuName = "CreateSkill")]
public class Skill : ScriptableObject
{
    public enum SkillType
    {
        AttackUp,
        GuardianArea,
        KaihiAttack,
    }

    [SerializeField] public JewelType jewelType;
    [SerializeField] public SkillType skillType;
    [SerializeField] public JewelRarity jewelRarity;
    [SerializeField] public int skillLevel;
    [SerializeField] public GameObject skill;
}
