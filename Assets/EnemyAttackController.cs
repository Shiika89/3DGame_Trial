using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackController : MonoBehaviour
{
    [SerializeField] Collider m_attackRange;

    PlayerDesroy Player;

    // Start is called before the first frame update
    void Start()
    {
        m_attackRange.gameObject.SetActive(false);
        if (m_attackRange.gameObject.activeSelf)
        {
            EndAttack();
        }
    }

    void BeginAttack()
    {
        m_attackRange.gameObject.SetActive(true);
        //PlayerDesroy
    }

    void EndAttack()
    {
        m_attackRange.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
