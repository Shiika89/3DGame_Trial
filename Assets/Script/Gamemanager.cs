using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gamemanager : MonoBehaviour
{
    [SerializeField] GameObject m_EquipmentUI;
    private bool m_UIflag = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && m_UIflag == false)
        {
            m_EquipmentUI.SetActive(true);
            m_UIflag = true;
        }
        else if (Input.GetKeyDown(KeyCode.Space) && m_UIflag == true)
        {
            m_EquipmentUI.SetActive(false);
            m_UIflag = false;
        }
    }
}
