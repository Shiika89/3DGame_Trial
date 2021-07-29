using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// エネミーのHP等を管理、IDamageを継承
/// </summary>
public class EnemyDesroy : MonoBehaviour ,IDamage
{
    [Tooltip("Enemyの初期HP")]
    [SerializeField] public int m_life = 100;
    [Tooltip("Enemyが死亡した時に呼ばれるオブジェクト")]
    [SerializeField] GameObject m_enemyDie;
    [Tooltip("Enemyの現在HP")]
    [SerializeField] int m_currentLife;
    [Tooltip("EnemyのHPバーのUIを入れる")]
    [SerializeField] private GameObject m_HPUI;
    /// <summary> ここに登録したアイテムからランダムにドロップする </summary>
    public GameObject[] m_dropitem;
    private Slider m_slinder;
    
    // Start is called before the first frame update
    void Start()
    {
        m_slinder = m_HPUI.transform.Find("HPBar").GetComponent<Slider>();
        m_currentLife = m_life; // 現在HPを初期HPに
        m_slinder.maxValue = m_life; // HPスライダーの最大値を初期HPと同じに
        m_slinder.value = m_currentLife;  //　スライダーの値を現在HPと同じに
    }

    /// <summary>
    /// エネミーが攻撃を食らった時に呼ばれる
    /// </summary>
    /// <param name="a"></param>
    public void Damage(int a)
    {
        // 攻撃を食らったら現在HPとスライダーの値を減らす
        m_currentLife -= a;
        m_slinder.value -= a;

        // HPが０以下になったら死亡用のアニメーションのオブジェクトとアイテムを生成
        if (m_currentLife <= 0)
        {
            Debug.Log("エネミー死亡");
            GameObject death = Instantiate(m_enemyDie);
            death.transform.position = this.transform.position;
            RamdomItemDrop();
            Destroy(this.gameObject);
        }
    }

    /// <summary>
    /// 設定したアイテムの中からランダムにアイテムを生成
    /// </summary>
    public void RamdomItemDrop()
    {
        var number = Random.Range(0, m_dropitem.Length);
        Instantiate(m_dropitem[number], new Vector3(transform.position.x, 0.32f, transform.position.z), transform.rotation);
    }
}
