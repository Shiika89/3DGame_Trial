using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatusText : MonoBehaviour
{
    [SerializeField] Text m_text;

    void Update()
    {
        m_text.text = $"{PlayerStatus.Instance.CurrentLife}\n{PlayerStatus.Instance.MaxSutamina}\n{PlayerStatus.Instance.Attack}\n{PlayerStatus.Instance.Deffence}";
    }
}
