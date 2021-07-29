using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// プレイヤーの攻撃判定のオンオフを切り替える
/// </summary>
public class AttackController : MonoBehaviour
{
    [SerializeField] Collider m_attackRange;
    [SerializeField] PlayerMove m_attackStop;

    // Start is called before the first frame update
    void Start()
    {
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

    public void BeginStop()
    {
        m_attackStop.m_IsAttacking = true;
    }

    public void EndStop()
    {
        m_attackStop.m_IsAttacking = false;
    }
    // Update is called once per frame
    
}
