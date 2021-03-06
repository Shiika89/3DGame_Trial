using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// プレイヤーが所持するスキルのリスト
/// </summary>
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
            item.SkillLv = 0;
            item.gameObject.SetActive(false);
        }

        foreach (var haveSkillList in m_haveSkillList)
        {
            foreach (var skillList in m_skillList)
            {
                if (haveSkillList.SkillType == skillList.SkillType)
                {
                    skillList.SkillLv += haveSkillList.SkillLevel;
                    skillList.gameObject.SetActive(true);
                }
            }
        }
    }
}


