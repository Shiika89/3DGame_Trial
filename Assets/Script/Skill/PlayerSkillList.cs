using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class PlayerSkillList : MonoBehaviour
{
    int m_attackUpLevel;
    public int AttackUpLevel { get => m_attackUpLevel; set => m_attackUpLevel = value; }

    int m_guardianAreaLevel;
    public int GuardianAreaLevel { get => m_guardianAreaLevel; set => m_guardianAreaLevel = value; }

    int m_kaihiAttackLevel;
    public int KaihiAttackLevel { get => m_kaihiAttackLevel; set => m_kaihiAttackLevel = value; }
}


