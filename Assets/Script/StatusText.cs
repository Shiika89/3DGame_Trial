using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatusText : MonoBehaviour
{
    [SerializeField] Character m_character;
    [SerializeField] Text m_text;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        m_text.text = $"HP           {m_character.Status.maxLife}\n攻撃力     {m_character.Status.attack}\n防御力     {m_character.Status.deffence}";
    }
}
