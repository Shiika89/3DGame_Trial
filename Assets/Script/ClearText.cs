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
        m_text.text = $"{GameManager.Instance.MinuteTime}分{GameManager.Instance.NowTimer}秒";
    }
}
