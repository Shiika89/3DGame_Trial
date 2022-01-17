using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageText : MonoBehaviour
{
    [SerializeField] Text m_stageText;

    // Start is called before the first frame update
    void Start()
    {
        m_stageText.text = $"STAGE  {Gamemanager.Instance.m_stage}";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
