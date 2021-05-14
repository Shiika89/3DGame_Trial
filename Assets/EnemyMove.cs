using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]

public class EnemyMove : MonoBehaviour
{
    [SerializeField] GameObject m_Player;
    [SerializeField] Animator m_anim;
    //Rigidbody m_rb;
    NavMeshAgent m_navMeshAgent;

    // Start is called before the first frame update
    void Start()
    {
        m_navMeshAgent = GetComponent<NavMeshAgent>();
        //m_rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        m_navMeshAgent.destination = m_Player.transform.position;
        Animation();
        
    }

    public void Animation()
    {
        if (m_anim)
        {
            Vector3 velocity = m_navMeshAgent.velocity;
            velocity.y = 0f;
            m_anim.SetFloat("Speed", velocity.magnitude);
        }
    }
}
