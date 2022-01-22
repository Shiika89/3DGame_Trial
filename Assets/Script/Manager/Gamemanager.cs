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
    public static Gamemanager Instance { get; set; }

    [Tooltip("装備画面のUI")]
    [SerializeField] GameObject m_EquipmentUI;
    [SerializeField] Text m_timeText;
    [SerializeField] AudioClip audioClip1;
    [SerializeField] AudioClip audioClip2;
    private AudioSource audioSource;

    public int m_stage = 1;
    public bool m_key = false;
    public bool m_timeAttack = false;
    float m_timer;
    public int m_nowTimer;
    public int m_minuteTime;

    /// <summary> 装備画面のUIのオンオフ </summary>
    public bool m_UIflag = false;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        m_EquipmentUI.GetComponent<RectTransform>().localPosition = new Vector2(700,0);
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
        m_timeText.text = $"{m_minuteTime}分{m_nowTimer}秒";

        if (m_timeAttack)
        {
            m_timer += Time.deltaTime;
            m_nowTimer = (int)m_timer;
            if (m_nowTimer == 60)
            {
                m_minuteTime++;
                m_timer = 0;
            }

            if (m_stage == 6)
            {
                SceneManager.LoadScene("ClearScene");
                m_timeAttack = false;
            }
        }

        //　装備画面のUIをスペースキーでオンオフに切り替え
        if (Input.GetKeyDown(KeyCode.Space) && m_UIflag == false)
        {
            InventoryManager.Instance.OpenInventory();
            m_EquipmentUI.GetComponent<RectTransform>().localPosition = Vector2.zero;
            m_UIflag = true;
        }
        else if (Input.GetKeyDown(KeyCode.Space) && m_UIflag == true)
        {
            InventoryManager.Instance.SelectItem();
            m_EquipmentUI.GetComponent<RectTransform>().localPosition = new Vector2(700, 0);
            m_UIflag = false;
        }
    }
}
