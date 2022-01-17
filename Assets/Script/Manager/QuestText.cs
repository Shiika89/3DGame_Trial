using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestText : MonoBehaviour
{
    [SerializeField] Text m_questText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!Gamemanager.Instance.m_key)
        {
            m_questText.text = "鍵を探そう！";
        }
        else
        {
            m_questText.text = "階段を目指そう！";
        }
    }
}
