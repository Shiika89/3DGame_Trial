using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatusText : MonoBehaviour
{
    [SerializeField] Text m_text;

    void Update()
    {
        m_text.text = $"HP           {PlayerStatus.m_currentLife}\nスタミナ {PlayerStatus.m_maxSutamina}\n攻撃力     {PlayerStatus.m_attack}\n防御力     {PlayerStatus.m_deffence}";
    }
}
