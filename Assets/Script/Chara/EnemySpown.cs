using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpown : MonoBehaviour
{
    [SerializeField] GameObject m_enemy;
    [SerializeField] GameObject[] m_spownPos;

    bool m_spownFlag;

    private void OnTriggerEnter(Collider other)
    {
        if (!m_spownFlag)
        {
            Debug.Log("敵が現れた");
            foreach (var item in m_spownPos)
            {
                Instantiate(m_enemy, item.transform);
            }
            m_spownFlag = true;
        }
        
    }
}
