using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackUp : SkillBase
{
    [SerializeField] float m_attackBuff;
    [SerializeField] GameObject m_dualSword;

    float m_totalAttackUp;
    public bool IsAttackUp { get; set; }

    bool hatudou;
    [SerializeField] float time;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1) && PlayerStatus.Instance.Sutamina > 20 && !IsSkillActive)
        {
            IsSkillActive = true;
            Debug.Log("a");
            m_dualSword.SetActive(true);
            m_totalAttackUp = SkillLv * m_attackBuff;
            PlayerStatus.Instance.Buff = m_totalAttackUp;
        }

        if (IsSkillActive)
        {
            PlayerStatus.Instance.Sutamina -= 1;
            if (PlayerStatus.Instance.Sutamina < 5)
            {
                Debug.Log("b");
                IsSkillActive = false;
                m_dualSword.SetActive(false);
                m_totalAttackUp = 0;
                PlayerStatus.Instance.Buff = m_totalAttackUp;
            }
        }
    }

    //private void OnEnable()
    //{
    //    IsAttackUp = true;
    //    m_dualSword.SetActive(true);
    //    m_totalAttackUp += SkillLv * m_attackBuff;
    //    PlayerStatus.Instance.Buff = m_totalAttackUp;
    //}

    //private void OnDisable()
    //{
    //    m_dualSword.SetActive(false);
    //    m_totalAttackUp = 0;
    //    PlayerStatus.Instance.Buff = m_totalAttackUp;
    //    IsAttackUp = false;
    //}
}
