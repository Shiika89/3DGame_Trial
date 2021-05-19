using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]

public class EnemyMove : MonoBehaviour
{
    //向かう相手を決めるための変数
    [SerializeField] Transform m_target;
    [SerializeField] Animator m_anim;
    //動くスピード
    [SerializeField] float m_moveSpeed = 0f;
    //相手が検知範囲に入ったどうか調べるための変数
    public bool m_inArea = false;
    Rigidbody m_rb;
    NavMeshAgent m_navMeshAgent;

    // Start is called before the first frame update
    void Start()
    {
        m_navMeshAgent = GetComponent<NavMeshAgent>();
        m_rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //検知エリアに入ったら動いて出たら止まる
        if (m_inArea == true)
        {
            //m_navMeshAgent.destination = m_target.transform.position;
            //m_anim.SetBool("Inarea", true);
            Move();
            Animation();
        }
        else
        {
            //Speedを０にする
            Vector3 velocity = m_rb.velocity;
            velocity.y = 0f;
            m_anim.SetFloat("Speed", 0);

            return;
        }
    }

    public void Animation()
    {
        if (m_anim)
        {
            //Speedにm_rbの速度を入れる
            Vector3 velocity = m_rb.velocity;
            velocity.y = 0f;
            m_anim.SetFloat("Speed", velocity.magnitude);
        }
    }

    //検出範囲に入った時の処理
    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            m_inArea = true;
        }
    }

    //検出範囲から出たときの処理
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            m_inArea = false;
        }
    }

    void Move()
    {
        //自身をtargetの方向に向かせる
        Vector3 targetPos = m_target.position;
        targetPos.y = transform.position.y;
        transform.LookAt(targetPos);

        //向いてる方向に進ませる
        Vector3 velo = this.transform.forward * m_moveSpeed;
        velo.y = m_rb.velocity.y;
        m_rb.velocity = velo;
        transform.position = transform.position + velo * Time.deltaTime;
    }
}
