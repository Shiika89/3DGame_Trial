using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// ボスのステータスを決めるクラス
/// </summary>
public class BossStatus : MonoBehaviour, IDamagable
{
    [SerializeField] int m_maxLife = default; // 最大体力値
    int m_currentLife; // 現在の体力値
    [SerializeField] public int m_attack = default; // 攻撃力
    [SerializeField] int m_deffence = default; // 防御力

    [Tooltip("ボスが死んだときに出す死亡アニメーションを持ったボスのプレハブ")]
    [SerializeField] GameObject m_DeathObject;

    [SerializeField] Slider m_hpSlider; // ボスのHPバー

    GameObject m_key; // ボスが死んだら出す鍵

    // Start is called before the first frame update
    void Start()
    {
        m_hpSlider.maxValue = m_maxLife; // HPスライダーの最大値を初期HPと同じに
        m_currentLife = m_maxLife;

        // 最初は鍵のアクティブをオフにする
        m_key = GameObject.Find("KeyUI");
        m_key.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        m_hpSlider.value = m_currentLife;  //　スライダーの値を現在HPと同じに

        // HPが0になったら鍵と死亡アニメーションのプレハブを出して自信を消す
        if (m_currentLife <= 0 && m_DeathObject)
        {
            Gamemanager.Instance.m_key = true;
            m_key.SetActive(true);
            GameObject death = Instantiate(m_DeathObject, this.gameObject.transform.position, this.gameObject.transform.rotation);
            Destroy(this.gameObject);
        }
    }

    /// <summary>
    /// 攻撃されたときに引数の数値を参照して相手からダメージを与える
    /// ために呼ばれる関数
    /// </summary>
    /// <param name="damage"></param>
    public void Damage(int damage)
    {
        // ダメージが0以下にはならない
        m_currentLife -= Mathf.Max(0, damage - m_deffence);
    }

}
