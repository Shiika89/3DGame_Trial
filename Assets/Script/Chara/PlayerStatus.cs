using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStatus : MonoBehaviour, IDamagable
{
    public static PlayerStatus Instance { get; set; }
    [Tooltip("プレイヤーの最大体力")]
    [SerializeField] int m_maxLife = 300;
    public int MaxLife { get => m_maxLife; }

    /// <summary> 現在のスタミナ </summary>
    int m_currentLife = 300;
    public int CurrentLife { get => m_currentLife; set => m_currentLife = value; }

    /// <summary> スキル発動時に上がる攻撃力の倍率 </summary>
    float m_buff = default;
    public float Buff { get => m_buff; set => m_buff = value; }

    [Tooltip("プレイヤーの攻撃力")]
    [SerializeField] int m_attack = 500;
    public int Attack { get => m_attack + (int)(m_attack * m_buff);}

    /// <summary> プレイヤーの基礎攻撃力 </summary>
    public int BaseAttack { get => m_attack; set => m_attack = value; }

    [Tooltip("プレイヤーの防御力")]
    [SerializeField] int m_deffence = 35;
    public int Deffence { get => m_deffence; set => m_deffence = value; }

    [Tooltip("プレイヤーの最大スタミナ")]
    [SerializeField] float m_maxSutamina = 100;
    public float MaxSutamina { get => m_maxSutamina; set => m_maxSutamina = value; }

    /// <summary> 現在のスタミナ </summary>
    float m_sutamina;
    public float Sutamina { get => m_sutamina; set => m_sutamina = value; }

    [Tooltip("スタミナの自動回復する量")]
    [SerializeField] float m_sutaminaHeal;

    [Tooltip("プレイヤーがやられたときに出すオブジェクト")]
    [SerializeField] GameObject m_DeathObject;

    [SerializeField] Slider m_hpSlider;
    [SerializeField] Slider m_sutaminaSlider;
    [SerializeField] GameObject m_attackRange;
    [SerializeField] PlayerMove m_playerMove;

    private void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        m_hpSlider.maxValue = m_maxLife; // HPスライダーの最大値を初期HPと同じに
        
        m_sutamina = m_maxSutamina;
    }

    // Update is called once per frame
    void Update()
    {
        m_sutaminaSlider.maxValue = m_maxSutamina;
        m_hpSlider.value = m_currentLife;  //　スライダーの値を現在HPと同じに
        m_sutaminaSlider.value = m_sutamina;

        if (m_sutamina < m_maxSutamina)
        {
            m_sutamina += m_sutaminaHeal;
        }
    }

    public void Damage(int damage)
    {
        // 回避中はダメージをくらわない
        if (m_playerMove.m_IsKaihi) return;

        // ダメージがマイナスにならないように
        m_currentLife -= Mathf.Max(0, damage - m_deffence);

        if (m_currentLife <= 0)
        {
            GameObject death = Instantiate(m_DeathObject);
            death.transform.position = this.transform.position;
            Destroy(this.gameObject);
        }
    }
}
