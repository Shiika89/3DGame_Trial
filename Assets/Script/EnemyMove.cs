﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

/// <summary>
/// Enemyの移動と攻撃を管理
/// </summary>
[RequireComponent(typeof(NavMeshAgent))]
public class EnemyMove : MonoBehaviour
{
    [Tooltip("移動目標")]
    [SerializeField] Transform m_target;
    [SerializeField] Animator m_anim;
    [Tooltip("攻撃を開始する距離")]
    [SerializeField] float m_attackRange = 1.5f;
    /// <summary> 相手が検知範囲内にいるか判定するためのフラグ </summary>
    public bool m_inArea = false;
    NavMeshAgent m_navMeshAgent;

    // Start is called before the first frame update
    void Start()
    {
        m_navMeshAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        //検知エリアに入ったら動いて出たら止まる
        if (m_inArea == true)
        {
            //相手が検知にいれば移動目標を相手に設定
            m_navMeshAgent.destination = m_target.transform.position;

            MoveAnimation();
            AttackAnimation();
        }
        else
        {
            // 相手が検知内にいなければ移動目標をその場に設定
            m_navMeshAgent.destination = this.transform.position;

            //Speedを０にする
            m_anim.SetFloat("Speed", 0);

            return;
        }
    }
    /// <summary>
    /// Enemyをナビメッシュで動かす
    /// </summary>
    public void MoveAnimation()
    {
        if (m_anim)
        {
            Vector3 velocity = m_navMeshAgent.velocity;
            velocity.y = 0f;
            m_anim.SetFloat("Speed", velocity.magnitude);
        }
    }
    /// <summary>
    /// Enemyの攻撃アニメーション
    /// </summary>
    public void AttackAnimation()
    {
        //　相手が攻撃範囲内にいれば攻撃を開始
        if (Vector3.Distance(transform.position, m_target.position) <= m_attackRange)
        {
            m_anim.SetTrigger("Attack");
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
}
