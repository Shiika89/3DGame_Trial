using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttackController : MonoBehaviour
{
    [SerializeField] Collider m_attackRange;
    [SerializeField] Collider m_jampAttackRange;

    // Start is called before the first frame update
    void Start()
    {
        m_attackRange.gameObject.SetActive(false);
        m_jampAttackRange.gameObject.SetActive(false);
        if (m_attackRange.gameObject.activeSelf)
        {
            EndAttack();
        }
    }

    void BeginAttack()
    {
        m_attackRange.gameObject.SetActive(true);
    }

    void EndAttack()
    {
        m_attackRange.gameObject.SetActive(false);
    }

    void BeginjampAttack()
    {
        m_jampAttackRange.gameObject.SetActive(true);
    }

    void EndJampAttack()
    {
        m_jampAttackRange.gameObject.SetActive(false);
    }
}
