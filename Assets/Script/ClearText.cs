using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClearText : MonoBehaviour
{
    [SerializeField] Text m_text;

    // Start is called before the first frame update
    void Start()
    {
        m_text.text = $"{Gamemanager.Instance.m_minuteTime}分{Gamemanager.Instance.m_nowTimer}秒";
    }
}
