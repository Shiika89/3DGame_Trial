using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// プレイヤーの攻撃判定のオンオフを切り替える
/// </summary>
public class AttackController : MonoBehaviour
{
    [SerializeField] Collider m_attackRange;
    [SerializeField] PlayerMove m_playerMove;

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
        m_playerMove.m_IsAttacking = true;
        m_playerMove.m_rb.velocity = new Vector3(0f, m_playerMove.m_rb.velocity.y, 0f);
    }

    public void EndStop()
    {
        m_playerMove.m_IsAttacking = false;
    }    
}
