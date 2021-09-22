using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ゲーム全体を管理
/// </summary>
public class Gamemanager : MonoBehaviour
{
    [Tooltip("装備画面のUI")]
    [SerializeField] GameObject m_EquipmentUI;
    public static int m_stage = 1;
    public static bool m_key = false;

    /// <summary> 装備画面のUIのオンオフ </summary>
    private bool m_UIflag = false;

    private void Start()
    {
        m_EquipmentUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //　装備画面のUIをスペースキーでオンオフに切り替え
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
