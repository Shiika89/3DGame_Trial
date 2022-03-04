using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectJewelText : MonoBehaviour
{
    public static SelectJewelText Instance { get; set; }
    [SerializeField] Text m_text = default;

    private void Awake()
    {
        Instance = this;
    }

    public void SelectText(ItemData data)
    {
        m_text.text = $"攻　{data.Para1}\n防　{data.Para2}\nス　{data.Para3}\nSkill Lv {data.Skill.SkillLevel}";
    }
}
