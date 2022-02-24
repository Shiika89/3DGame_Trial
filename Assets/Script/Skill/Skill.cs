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

[Serializable]
[CreateAssetMenu(fileName = "Skill", menuName = "CreateSkill")]
public class Skill : ScriptableObject
{
    [SerializeField] public JewelType jewelType;
    [SerializeField] public SkillType skillType;
    [SerializeField] public JewelRarity jewelRarity;
    [SerializeField] public int skillLevel;
    [SerializeField] public GameObject skill;
}
