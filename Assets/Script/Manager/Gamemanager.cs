using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/// <summary>
/// ゲーム全体を管理
/// </summary>
public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; set; }

    [Tooltip("装備画面のUI")]
    [SerializeField] GameObject m_EquipmentUI;

    [Tooltip("経過時間のUIテキスト")]
    [SerializeField] Text m_timeText;

    [Tooltip("BGMを格納")]
    [SerializeField] AudioClip[] audioClip;

    [Tooltip("敵の強さのテキスト")]
    [SerializeField] Text m_enemyLevelText;

    [Tooltip("何秒で敵の強さが上がるか")]
    [SerializeField] int m_levelUpTime;

    [Tooltip("ゲームオーバー時に出すUI")]
    [SerializeField] GameObject m_gameOver;

    AudioSource audioSource;

    [Tooltip("現在の階層")]
    [SerializeField] int m_stage = 1;
    public int Stage { get => m_stage; set => m_stage = value; }

    public bool Key { get; set; } = false;

    public bool m_timeAttack = false;
    float m_timer;

    public int NowTimer { get; private set; }
    public int MinuteTime { get; private set; }

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
        Key = false;

        StageBGM();
    }

    // Update is called once per frame
    void Update()
    {
        GameLevel();

        GameTime();

        if (m_stage == 6)
        {
            SceneManager.LoadScene("ClearScene");
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

    /// <summary>
    /// 時間経過で敵の強さを上げる
    /// </summary>
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
                //Debug.Log($"敵の強さが上がった、レベル{m_nowEnemyLv}");
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

    /// <summary>
    /// 階層数によってBGMを変える
    /// </summary>
    public void StageBGM()
    {
        if (m_stage % 5 == 0)
        {
            BGMSet(audioClip[0]);
        }
        else
        {
            BGMSet(audioClip[1]);
        }
    }

    void BGMSet(AudioClip audio)
    {
        audioSource = gameObject.GetComponent<AudioSource>();
        audioSource.clip = audio;
        audioSource.Play();
    }

    /// <summary>
    /// ゲームの経過時間を計る
    /// </summary>
    void GameTime()
    {
        m_timeText.text = $"{MinuteTime}分{NowTimer}秒";

        m_timer += Time.deltaTime;
        NowTimer = (int)m_timer;

        if (NowTimer == 60)
        {
            MinuteTime++;
            m_timer = 0;
        }
    }
}
