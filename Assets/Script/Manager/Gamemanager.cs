﻿using System.Collections;
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
    [SerializeField] Text m_enemyLevelText;
    [SerializeField] int m_levelUpTime;
    [SerializeField] GameObject m_gameOver;

    private AudioSource audioSource;

    public int m_stage = 1;
    public bool m_key = false;
    public bool m_timeAttack = false;
    float m_timer;
    public int m_nowTimer;
    public int m_minuteTime;

    float m_enemyStatusTimer;
    [SerializeField] int[] m_enemyLevel;
    public int[] EnemyLevel { get => m_enemyLevel;}
    public int m_nowEnemyLv { get; private set; } = 1;
    

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
        GameLevel();

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
            Time.timeScale = 0;
        }
        

        if (PlayerStatus.Instance.CurrentLife <= 0)
        {
            m_gameOver.SetActive(true);
        }
    }

    void GameLevel()
    {
        m_enemyStatusTimer += Time.deltaTime;

        for (int i = m_nowEnemyLv; i < m_enemyLevel.Length; i++)
        {
            if (m_enemyStatusTimer > m_levelUpTime)
            {
                m_nowEnemyLv++;
                m_enemyStatusTimer = 0;
                m_enemyLevelText.text = $"Lv{m_nowEnemyLv}";
                Debug.Log($"敵の強さが上がった、レベル{m_nowEnemyLv}");
            }
        }
    }

    /// <summary>
    /// ボタンでメニュー画面を閉じるための関数
    /// </summary>
    public void EquipmentUIOff()
    {
        if (m_UIflag == true)
        {
            Time.timeScale = 1;
            PanelChange.Instance.ActiveFalse();

            InventoryManager.Instance.SelectItem();
            m_EquipmentUI.GetComponent<RectTransform>().localPosition = new Vector2(700, 0);
            m_UIflag = false;
        }
    }
}
