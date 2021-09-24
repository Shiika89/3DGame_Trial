using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossStatus : MonoBehaviour, IDamagable
{
    [SerializeField] int m_maxLife = 100;
    [SerializeField] int m_currentLife = 100;
    [SerializeField] int m_attack = 15;
    [SerializeField] int m_deffence = 8;

    [SerializeField] GameObject m_DeathObject;
    [SerializeField] Slider m_hpSlider;
    [SerializeField] GameObject m_attackRange;
    GameObject m_key;

    // Start is called before the first frame update
    void Start()
    {
        m_hpSlider.maxValue = m_maxLife; // HPスライダーの最大値を初期HPと同じに

        m_key = GameObject.Find("KeyUI");
        m_key.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        m_hpSlider.value = m_currentLife;  //　スライダーの値を現在HPと同じに
    }
    public void Damage(int damage)
    {
        m_currentLife -= Mathf.Max(0, damage - m_deffence);
        if (m_currentLife <= 0 && m_DeathObject)
        {
            Gamemanager.m_key = true;
            m_key.SetActive(true);
            GameObject death = Instantiate(m_DeathObject, this.gameObject.transform.position, this.gameObject.transform.rotation);
            Destroy(this.gameObject);
        }
    }

}
