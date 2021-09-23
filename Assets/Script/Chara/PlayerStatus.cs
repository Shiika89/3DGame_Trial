using System;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStatus : MonoBehaviour, IDamagable
{
    public static int m_maxLife = 100;
    public static int m_currentLife = 100;
    public static int m_attack = 15;
    public static int m_deffence = 8;
    public static float m_sutamina = 100;

    [SerializeField] GameObject m_DeathObject;
    [SerializeField] Slider m_hpSlider;
    [SerializeField] Slider m_sutaminaSlider;
    [SerializeField] GameObject m_attackRange;

    // Start is called before the first frame update
    void Start()
    {
        m_hpSlider.maxValue = m_maxLife; // HPスライダーの最大値を初期HPと同じに
        m_sutaminaSlider.maxValue = m_sutamina;
    }

    // Update is called once per frame
    void Update()
    {
        m_hpSlider.value = m_currentLife;  //　スライダーの値を現在HPと同じに
        m_sutaminaSlider.value = m_sutamina;

        if (m_sutamina < 100)
        {
            m_sutamina += 0.2f;
        }
    }

    public void Damage(int damage)
    {
        m_currentLife -= Mathf.Max(0, damage - m_deffence);
        if (m_currentLife <= 0)
        {
            GameObject death = Instantiate(m_DeathObject);
            death.transform.position = this.transform.position;
            Destroy(this.gameObject);
        }
    }
}
