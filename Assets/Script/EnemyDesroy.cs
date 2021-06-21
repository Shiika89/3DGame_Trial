using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyDesroy : MonoBehaviour
{
    [SerializeField] public int m_life = 100;
    [SerializeField] GameObject m_enemyDie;
    [SerializeField] int m_currentLife;
    [SerializeField] private GameObject m_HPUI;
    private Slider m_slinder;

    int Damage = 10;

    
    // Start is called before the first frame update
    void Start()
    {
        m_slinder = m_HPUI.transform.Find("HPBar").GetComponent<Slider>();
        m_currentLife = m_life;
        m_slinder.maxValue = m_life;
        m_slinder.value = m_currentLife;
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Attack")
        {
            m_currentLife -= Damage;
            m_slinder.value -= Damage;


            if (m_currentLife <= 0)
            {
                Debug.Log("エネミー死亡");
                GameObject death = Instantiate(m_enemyDie);
                death.transform.position = this.transform.position;
                Destroy(this.gameObject);
            }
        }
    }
}
