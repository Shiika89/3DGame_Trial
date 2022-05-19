using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// プレイヤーの攻撃判定のオンオフを切り替える
/// </summary>
public class AttackController : MonoBehaviour
{
    public static AttackController Instanca { get; set; }

    [SerializeField] Collider m_attackRange;
    [SerializeField] Collider m_attackAllRange;
    [SerializeField] PlayerMove m_playerMove;
    [SerializeField] Animator m_anim;
    [SerializeField] float m_sceal;

    public bool IsDualAttack1 { get; set; }
    public bool IsDualAttack2 { get; private set; }

    public bool IsAttack1 { get; set; }
    public bool IsAttack2 { get; set; }


    // ヒットストップをするか判定するフラグ
    public bool OnHitStop { get; set; }

    private void Awake()
    {
        Instanca = this;
    }

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

    void BiginKnockBackAttack()
    {
        m_attackAllRange.gameObject.SetActive(true);
    }

    void EndKnockBackAttack()
    {
        m_attackAllRange.gameObject.SetActive(false);
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

    public void Attack1Start()
    {
        IsAttack1 = true;
    }

    public void DualAttack1Start()
    {
        IsDualAttack1 = true;
    }

    public void Attack1End()
    {
        IsAttack1 = false;
        if (m_playerMove.AttackNum == 1)
        {
            m_playerMove.m_IsAttacking = false;
            m_playerMove.AttackNum = 0;
        }
        m_anim.SetInteger("Attack", m_playerMove.AttackNum);
    }

    public void DualAttack1End()
    {
        IsDualAttack1 = false;
        if (m_playerMove.DualAttackNum == 1)
        {
            m_playerMove.m_IsAttacking = false;
            m_playerMove.DualAttackNum = 0;
        }
        m_anim.SetInteger("DualAttack", m_playerMove.DualAttackNum);
    }

    public void Attack2Start()
    {
        IsAttack2 = true;
    }

    public void DualAttack2Start()
    {
        IsDualAttack2 = true;
    }

    public void Attack2End()
    {
        IsAttack1 = false;
        IsAttack2 = false;
        if (m_playerMove.AttackNum == 2)
        {
            m_playerMove.m_IsAttacking = false;
            m_playerMove.AttackNum = 0;
        }
        m_anim.SetInteger("Attack", m_playerMove.AttackNum);
    }

    public void DualAttack2End()
    {
        IsDualAttack1 = false;
        IsDualAttack2 = false;
        if (m_playerMove.DualAttackNum == 2)
        {
            m_playerMove.m_IsAttacking = false;
            m_playerMove.DualAttackNum = 0;
        }
        m_anim.SetInteger("DualAttack", m_playerMove.DualAttackNum);
    }

    public void Attack3End()
    {
        IsAttack1 = false;
        IsAttack2 = false;
        if (m_playerMove.AttackNum == 3)
        {
            m_playerMove.m_IsAttacking = false;
            m_playerMove.AttackNum = 0;
        }
        m_anim.SetInteger("Attack", m_playerMove.AttackNum);
    }

    public void DualAttack3End()
    {
        IsDualAttack1 = false;
        IsDualAttack2 = false;
        if (m_playerMove.DualAttackNum == 3)
        {
            m_playerMove.m_IsAttacking = false;
            m_playerMove.DualAttackNum = 0;
        }
        m_anim.SetInteger("DualAttack", m_playerMove.DualAttackNum);
    }

    public void StartHitStop()
    {
        if (OnHitStop)
        {
            Time.timeScale = m_sceal;
        }
    }

    public void EndHitStop()
    {
        if (OnHitStop)
        {
            Time.timeScale = 1;
            OnHitStop = false;
        }
    }
}
