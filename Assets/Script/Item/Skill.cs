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
        AvoidanceAttack,
    }


}
