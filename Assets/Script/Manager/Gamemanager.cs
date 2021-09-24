using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/// <summary>
/// ゲーム全体を管理
/// </summary>
public class Gamemanager : MonoBehaviour
{
    [Tooltip("装備画面のUI")]
    [SerializeField] GameObject m_EquipmentUI;
    [SerializeField] Text m_timeText;
    [SerializeField] AudioClip audioClip1;
    [SerializeField] AudioClip audioClip2;
    private AudioSource audioSource;

    public static int m_stage = 1;
    public static bool m_key = false;
    public static bool m_timeAttack = false;
    public static float m_timer;

    /// <summary> 装備画面のUIのオンオフ </summary>
    private bool m_UIflag = false;

    private void Start()
    {
        m_EquipmentUI.SetActive(false);
        m_key = false;

        if (m_stage % 5 == 0)
        {
            audioSource = gameObject.GetComponent<AudioSource>();
            audioSource.clip = audioClip1;
            audioSource.Play();
        }
        else
        {
            audioSource = gameObject.GetComponent<AudioSource>();
            audioSource.clip = audioClip2;
            audioSource.Play();
        }
    }

    // Update is called once per frame
    void Update()
    {
        m_timeText.text = $"{m_timer}";

        if (m_timeAttack)
        {
            m_timer += Time.deltaTime;

            if (m_stage == 6)
            {
                SceneManager.LoadScene("ClearScene");
                m_timeAttack = false;
            }
        }

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
