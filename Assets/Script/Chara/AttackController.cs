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
        // 最初は必ず攻撃判定をオフにしておく
        if (m_attackRange.gameObject.activeSelf)
        {
            EndAttack();
        }
    }

    // アニメーションのシグナルで関数、攻撃判定のコライダーをオンにする
    void BeginAttack()
    {
        m_attackRange.gameObject.SetActive(true);
    }

    // アニメーションのシグナルで関数、攻撃判定のコライダーをオフにする
    void EndAttack()
    {
        m_attackRange.gameObject.SetActive(false);
    }

    // 攻撃中かを判定するための関数、攻撃中は移動できなくする
    public void BeginStop()
    {
        m_playerMove.m_IsAttacking = true;
        m_playerMove.m_rb.velocity = new Vector3(0f, m_playerMove.m_rb.velocity.y, 0f);
    }

    // 攻撃が終わったら呼ばれる関数
    public void EndStop()
    {
        m_playerMove.m_IsAttacking = false;
    }    
}
