using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// プレイヤーの動きやアニメーションの処理
/// </summary>
public class PlayerMove : MonoBehaviour
{
    const int FIRST_ATTACK = 0;
    const int SECOND_ATTACK = 1;
    const int LAST_ATTACK = 2;
    static public PlayerMove Instance;

    [Tooltip("動く速さ")]
    [SerializeField] public float m_movingSpeed = 5f;

    [SerializeField] Animator m_anim;

    [Tooltip("回避する時の速さ")]
    [SerializeField] float m_kaihiSpeed;
    public float KaihiSpeed { get => m_kaihiSpeed; set => m_kaihiSpeed = value; }

    [Tooltip("回避時間")]
    [SerializeField] float m_kaihiTime;
    public float KaihiTime { get => m_kaihiTime; set => m_kaihiTime = value; }

    [Tooltip("プレイヤーのモデル")]
    [SerializeField] GameObject m_model;

    [Tooltip("回避中のエフェクト")]
    [SerializeField] ParticleSystem m_effect;

    [SerializeField] AudioSource m_audioSource;

    [Tooltip("攻撃した時の音")]
    [SerializeField] AudioClip m_audioClip;

    [Tooltip("アタックアップのスキル")]
    [SerializeField] AttackUp m_attackUp;

    [Tooltip("回避をしたときに減るスタミナの量")]
    [SerializeField] float m_kaihiCost;

    [SerializeField] AttackController m_attackController;
    
    /// <summary>プレイヤーが攻撃中かを判定するフラグ</summary>
    public bool m_IsAttacking { get; set; } = false;

    /// <summary>スキル発動中の今何段目の攻撃中かを数える変数</summary>
    public int DualAttackNum { get; set; }

    /// <summary> 通常攻撃の今何段階目の攻撃中かを数える変数 </summary>
    public int AttackNum { get; set; }

    /// <summary>回避中かどうかを判定するフラグ</summary>
    public bool m_IsKaihi;

    /// <summary>回避が始まってからの時間を計るタイマー</summary>
    float m_kaihiTimer;

    public Rigidbody m_rb;

    private void Awake()
    {
        Instance = this;
    }

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
    /// 移動に関する関数
    /// </summary>
    public void Move()
    {
        // 攻撃中・回避中・ステータス画面だったら操作を受け付けない
        if (m_IsAttacking || m_IsKaihi || GameManager.Instance.m_UIflag) 
        {
            return;
        }

        float v = Input.GetAxisRaw("Vertical");
        float h = Input.GetAxisRaw("Horizontal");

        Vector3 dir = (Vector3.forward * v + Vector3.right * h).normalized;
        if (dir == Vector3.zero)
        {
            // 方向の入力がニュートラルの時は、y 軸方向の速度を保持するだけ
            m_rb.velocity = new Vector3(0f, m_rb.velocity.y, 0f);
        }
        else
        {
            this.transform.forward = dir;

            m_rb.velocity = this.transform.forward * m_movingSpeed;
        }
    }

    /// <summary>
    /// プレイヤーの操作（カメラの方向を基準に移動）現在未使用
    /// </summary>
    public void CameraMove()
    {
        if (m_IsAttacking || m_IsKaihi) // 攻撃中・回避中だったら操作を受け付けない
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
        if (m_anim && !m_IsKaihi)
        {
            // 水平方向の速度を Speed にセットする
            Vector3 velocity = m_rb.velocity;
            velocity.y = 0f;
            m_anim.SetFloat("Speed", velocity.magnitude);

            // ステータス画面を開いてなくて攻撃ボタンを押したら Attack をセットする
            if (Input.GetButtonDown("Fire1") && !GameManager.Instance.m_UIflag)
            {
                // スキル発動中は連続攻撃可能
                if (m_attackUp.IsSkillActive)
                {
                    if (DualAttackNum == FIRST_ATTACK)
                    {
                        DualAttackNum++;
                        m_anim.SetInteger("DualAttack", DualAttackNum);
                    }
                    else if(DualAttackNum == SECOND_ATTACK && m_attackController.IsDualAttack1)
                    {
                        DualAttackNum++;
                        m_anim.SetInteger("DualAttack", DualAttackNum);
                    }
                    else if (DualAttackNum == LAST_ATTACK && m_attackController.IsDualAttack2)
                    {
                        DualAttackNum++;
                        m_anim.SetInteger("DualAttack", DualAttackNum);
                    }
                }
                else // スキル発動中でなければ通常攻撃
                {
                    if (AttackNum == FIRST_ATTACK)
                    {
                        AttackNum++;
                        m_anim.SetInteger("Attack", AttackNum);
                    }
                    else if (AttackNum == SECOND_ATTACK && m_attackController.IsAttack1)
                    {
                        AttackNum++;
                        m_anim.SetInteger("Attack", AttackNum);
                    }
                    else if (AttackNum == LAST_ATTACK && m_attackController.IsAttack2)
                    {
                        AttackNum++;
                        m_anim.SetInteger("Attack", AttackNum);
                    }
                }

                //m_rb.velocity = transform.forward * m_movingSpeed;
                //m_rb.AddForce(transform.forward * 10, ForceMode.Impulse);

                // 攻撃をすると音を鳴らす
                m_audioSource.clip = m_audioClip;
                m_audioSource.Play();
            }
        }
    }

    /// <summary>
    /// 右クリックでスタミナを消費して回避を行う
    /// </summary>
    public void Kaihi()
    {
        if (m_IsAttacking) // 攻撃中は受け付けない
        {
            return;
        }

        // 規定値以上のスタミナがあれば回避を実行
        if (Input.GetButtonDown("Fire2") && !m_IsKaihi && PlayerStatus.Instance.Sutamina >= m_kaihiCost)
        {
            m_IsKaihi = true;
            m_model.SetActive(false); // 回避中は姿を見えなくする
            m_effect.Play();
            PlayerStatus.Instance.Sutamina -= m_kaihiCost; // スタミナを減らす

            float v = Input.GetAxisRaw("Vertical");
            float h = Input.GetAxisRaw("Horizontal");

            Vector3 dir = (Vector3.forward * v + Vector3.right * h).normalized;

            if (dir != Vector3.zero)
            {
                this.transform.forward = dir;

                Vector3 velo = this.transform.forward * m_movingSpeed;
                m_rb.AddForce(velo * m_kaihiSpeed, ForceMode.Impulse);
            }

            m_kaihiTimer = m_kaihiTime;

        }

        // 回避が終わったらエフェクトを消してモデルを戻す
        if (m_kaihiTimer > 0 && m_IsKaihi)
        {
            m_kaihiTimer -= Time.deltaTime;
            if (m_kaihiTimer <= 0)
            {
                m_IsKaihi = false;
                m_model.SetActive(true);
                m_effect.Stop();
            }
        }
    }

    // 現在は使っていない回避
    public void CameraMoveKaihi()
    {
        if (m_IsAttacking)
        {
            return;
        }

        if (Input.GetButtonDown("Fire2") && !m_IsKaihi && PlayerStatus.Instance.Sutamina >= 20f)
        {
            m_IsKaihi = true;
            m_model.SetActive(false);
            m_effect.Play();
            PlayerStatus.Instance.Sutamina -= 20f;
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

        if (m_kaihiTimer > 0 && m_IsKaihi)
        {
            m_kaihiTimer -= Time.deltaTime;
            if (m_kaihiTimer <= 0)
            {
                m_IsKaihi = false;
                m_model.SetActive(true);
                m_effect.Stop();
            }
        }
    }
}
