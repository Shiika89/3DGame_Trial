using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [Tooltip("動く速さ")]
    [SerializeField] public float m_movingSpeed = 5f;
    /// <summary>プレイヤーが攻撃中かを判定するフラグ</summary>
    public bool m_IsAttacking = false;
    [SerializeField] Animator m_anim;
    Rigidbody m_rb;
    bool m_kaihi;
    float m_kaihiTimer;
    [SerializeField] float m_kaihiTime = 0.5f;
    [SerializeField] GameObject m_model;
    [SerializeField] ParticleSystem m_effect;

    void Start()
    {
        m_rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Animation();
        Kaihi();
    }
    /// <summary>
    /// プレイヤーの操作（カメラの方向を基準に移動）
    /// </summary>
    public void Move()
    {
        if (m_IsAttacking || m_kaihi) // 攻撃中だったら操作を受け付けない
        {
            return;
        }
        float v = Input.GetAxisRaw("Vertical");
        float h = Input.GetAxisRaw("Horizontal");

        Vector3 dir = Vector3.forward * v + Vector3.right * h;

        if (dir == Vector3.zero)
        {
            // 方向の入力がニュートラルの時は、y 軸方向の速度を保持するだけ
            m_rb.velocity = new Vector3(0f, m_rb.velocity.y, 0f);
        }
        else
        {
            // カメラを基準に入力が上下=奥/手前, 左右=左右にキャラクターを向ける
            dir = Camera.main.transform.TransformDirection(dir);    // メインカメラを基準に入力方向のベクトルを変換する
            dir.y = 0;  // y 軸方向はゼロにして水平方向のベクトルにする
            this.transform.forward = dir;   // そのベクトルの方向にオブジェクトを向ける

            // 前方に移動する。ジャンプした時の y 軸方向の速度は保持する。
            Vector3 velo = this.transform.forward * m_movingSpeed;
            velo.y = m_rb.velocity.y;
            m_rb.velocity = velo;
        }
    }
    /// <summary>
    /// プレイヤーのアニメーション
    /// </summary>
    public void Animation()
    {
        if (m_anim && !m_kaihi)
        {
            // 水平方向の速度を Speed にセットする
            Vector3 velocity = m_rb.velocity;
            velocity.y = 0f;
            m_anim.SetFloat("Speed", velocity.magnitude);

            //攻撃ボタンを押したら Attack をセットする
            if (Input.GetButtonDown("Fire1"))
            {
                m_anim.SetTrigger("Attack");
            }
        }
    }

    public void Kaihi()
    {
        if (m_IsAttacking)
        {
            return;
        }
        if (Input.GetButtonDown("Fire2") && !m_kaihi && PlayerStatus.m_sutamina >= 20f)
        {
            m_kaihi = true;
            m_model.SetActive(false);
            m_effect.Play();
            PlayerStatus.m_sutamina -= 20f;
            float v = Input.GetAxisRaw("Vertical");
            float h = Input.GetAxisRaw("Horizontal");

            Vector3 dir = Vector3.forward * v + Vector3.right * h;

            if (dir == Vector3.zero)
            {
                // 方向の入力がニュートラルの時は、y 軸方向の速度を保持するだけ
                m_rb.velocity = new Vector3(0f, m_rb.velocity.y, 0f);
            }
            else
            {
                // カメラを基準に入力が上下=奥/手前, 左右=左右にキャラクターを向ける
                dir = Camera.main.transform.TransformDirection(dir);    // メインカメラを基準に入力方向のベクトルを変換する
                dir.y = 0;  // y 軸方向はゼロにして水平方向のベクトルにする
                this.transform.forward = dir;   // そのベクトルの方向にオブジェクトを向ける

                // 前方に移動する。ジャンプした時の y 軸方向の速度は保持する。
                Vector3 velo = this.transform.forward * m_movingSpeed;
                velo.y = m_rb.velocity.y;
                m_rb.AddForce(velo * 2, ForceMode.Impulse);
            }
            m_kaihiTimer = m_kaihiTime;

        }

        if (m_kaihiTimer > 0 && m_kaihi)
        {
            m_kaihiTimer -= Time.deltaTime;
            if (m_kaihiTimer <= 0)
            {
                m_kaihi = false;
                m_model.SetActive(true);
                m_effect.Stop();
            }
        }
    }
}
