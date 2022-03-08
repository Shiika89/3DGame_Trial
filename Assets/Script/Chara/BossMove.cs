using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

/// <summary>
/// ボスの行動を決めるクラス
/// *要修正必要
/// </summary>
[RequireComponent(typeof(NavMeshAgent))]
public class BossMove : MonoBehaviour
{
    [SerializeField] Animator m_anim;
    [SerializeField] NavMeshAgent m_navMeshAgent;
    [SerializeField] float m_attackRange; // 近接通常攻撃を行う間合い
    [SerializeField] float m_jampAttackRange; // ジャンプ攻撃をする間合い

    Transform m_target;　// プレイヤーを入れる

    // Start is called before the first frame update
    void Start()
    {
        m_target = GameObject.Find("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (m_target != null)
        {
            // ターゲットの方に向いてアニメーションをする
            transform.LookAt(m_target.transform);
        }
        
        AttackAnim();
    }

    /// <summary>
    /// プレイヤーとの距離によって行動を変えるためのアニメーションの関数
    /// </summary>
    private void AttackAnim()
    {
        if (m_target != null)
        {
            // 近接距離に入ってれば近接通常攻撃
            if (Vector3.Distance(transform.position, m_target.position) <= m_attackRange)
            {
                m_anim.SetBool("Attack", true);
                m_anim.SetBool("JampAttack", false);
                m_anim.SetBool("Walk", false);
            }
            // 近接通常攻撃より遠く、歩く距離より近い場合ジャンプ攻撃
            else if (Vector3.Distance(transform.position, m_target.position) <= m_jampAttackRange)
            {
                m_anim.SetBool("Attack", false);
                m_anim.SetBool("JampAttack", true);
                m_anim.SetBool("Walk", false);
            }
            // ジャンプ攻撃が届かない距離は歩く
            else
            {
                m_anim.SetBool("Attack", false);
                m_anim.SetBool("JampAttack", false);
                m_anim.SetBool("Walk", true);
                m_navMeshAgent.destination = m_target.transform.position;
                MoveAnimation();
            }
        }
    }

    /// <summary>
    /// 最初にプレイヤーが範囲に入ると咆哮をする
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            m_anim.SetTrigger("Scream");
        }
    }

    public void MoveAnimation()
    {
        if (m_anim)
        {
            Vector3 velocity = m_navMeshAgent.velocity;
            velocity.y = 0f;
            m_anim.SetFloat("Speed", velocity.magnitude);
        }
    }
}
