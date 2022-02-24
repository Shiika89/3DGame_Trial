using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerSkillList : MonoBehaviour
{
    public static PlayerSkillList Instance { get; set; }

    [SerializeField] List<SkillBase> m_skillList = new List<SkillBase>();


    /// <summary> 現在装備しているスキルのリスト /// </summary>
    public List<Skill> m_haveSkillList { get; set; } = new List<Skill>();


    private void Awake()
    {
        Instance = this;
    }

    public void SkillSet()
    {
        foreach (var item in m_skillList)
        {
            item.IsSkillActive = false;
            item.SkillLv = 0;
            item.gameObject.SetActive(false);
        }

        foreach (var haveSkillList in m_haveSkillList)
        {
            foreach (var skillList in m_skillList)
            {
                if (haveSkillList.skillType == skillList.SkillType)
                {
                    skillList.IsSkillActive = true;
                    skillList.SkillLv += haveSkillList.skillLevel;
                    skillList.gameObject.SetActive(true);
                }
            }
        }
    }
}


