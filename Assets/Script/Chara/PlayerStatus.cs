using System;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStatus : MonoBehaviour, IDamagable
{
    public static int m_maxLife = 100;
    public static int m_currentLife = 100;
    public static int m_attack = 15;
    public static int m_deffence = 8;
    [SerializeField] GameObject m_DeathObject;
    [SerializeField] GameObject m_HPUI;
    [SerializeField] GameObject m_attackRange;
    Slider m_slinder;

    // Start is called before the first frame update
    void Start()
    {
        m_slinder = m_HPUI.transform.Find("HPBar").GetComponent<Slider>();
        m_slinder.maxValue = m_maxLife; // HPスライダーの最大値を初期HPと同じに
    }

    // Update is called once per frame
    void Update()
    {
        m_slinder.value = m_currentLife;  //　スライダーの値を現在HPと同じに
    }

    public void Damage(int damage)
    {
        m_currentLife -= Mathf.Max(0, damage - m_deffence);
        m_slinder.value -= Mathf.Max(0, damage - m_deffence);
        if (m_currentLife <= 0)
        {
            Debug.Log("my health is less than or equal to 0");
            GameObject death = Instantiate(m_DeathObject);
            death.transform.position = this.transform.position;
            Destroy(this.gameObject);
        }
    }
}
