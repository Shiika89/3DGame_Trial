using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Enemyの攻撃判定のオンオフを切り替える
/// </summary>
public class EnemyAttackController : MonoBehaviour
{
    [SerializeField] Collider m_attackRange;

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
