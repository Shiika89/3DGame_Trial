using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDesroy : MonoBehaviour
{
    [SerializeField] public int m_life = 5;
    [SerializeField] GameObject m_unitychanDie;

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "EnemyAttack")
        {
            m_life--;
            if (m_life == 0)
            {
                Debug.Log("プレイヤー死亡");
                GameObject death = Instantiate(m_unitychanDie);
                death.transform.position = this.transform.position;
                Destroy(this.gameObject);
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
