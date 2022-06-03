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
        m_text.text = $"{Gamemanager.Instance.MinuteTime}分{Gamemanager.Instance.NowTimer}秒";
    }
}
