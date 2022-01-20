using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatusText : MonoBehaviour
{
    [SerializeField] Text m_text;

    void Update()
    {
        m_text.text = $"HP           {PlayerStatus.Instance.CurrentLife}\nスタミナ {PlayerStatus.Instance.MaxSutamina}\n攻撃力     {PlayerStatus.Instance.Attack}\n防御力     {PlayerStatus.Instance.Deffence}";
    }
}
