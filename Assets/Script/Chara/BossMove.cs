using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BossMove : MonoBehaviour
{
    Transform m_target;
    [SerializeField] Animator m_anim;

    [SerializeField] float m_attackRange;
    [SerializeField] float m_jampAttackRange;
    [SerializeField] float m_walkRange;

    [SerializeField] NavMeshAgent m_navMeshAgent;

    // Start is called before the first frame update
    void Start()
    {
        m_target = GameObject.Find("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(m_target.transform);
        AttackAnim();
    }

    private void AttackAnim()
    {
        if (Vector3.Distance(transform.position, m_target.position) <= m_attackRange)
        {
            m_anim.SetBool("Attack", true);
            m_anim.SetBool("JampAttack", false);
            m_anim.SetBool("Walk", false);
        }
        else if (Vector3.Distance(transform.position, m_target.position) <= m_jampAttackRange)
        {
            m_anim.SetBool("Attack", false);
            m_anim.SetBool("JampAttack", true);
            m_anim.SetBool("Walk", false);
        }
        else
        {
            m_anim.SetBool("Attack", false);
            m_anim.SetBool("JampAttack", false);
            m_anim.SetBool("Walk", true);
            m_navMeshAgent.destination = m_target.transform.position;
            MoveAnimation();
        }
    }

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
