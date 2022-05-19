using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// エネミーのステータスやダメージ処理
/// </summary>
public class EnemyStatus : MonoBehaviour, IStatusModelHolder, IDamagable
{
    [Tooltip("敵のステータスのスクリプタブルオブジェクトを入れる")]
    [SerializeField] EnemyParameter m_enemyParameter;

    // 敵のステータスの受け皿
    private StatusModel m_status = new StatusModel();
    public StatusModel Status => m_status;

    [SerializeField] GameObject m_DeathObject;

    [SerializeField] GameObject m_HPUI;

    [SerializeField] GameObject m_attackRange;

    public Slider m_slinder { get; set; }

    EnemyMove m_enemyMove;


    private void Start()
    {
        EnemyStatusSet();

        m_slinder = m_HPUI.transform.Find("HPBar").GetComponent<Slider>();
        m_enemyMove = GetComponent<EnemyMove>();

        Status.currentLife = Status.maxLife; // 現在HPを初期HPに
        m_slinder.maxValue = Status.maxLife; // HPスライダーの最大値を初期HPと同じに
    }

    private void Update()
    {
        m_slinder.value = Status.currentLife;  //　スライダーの値を現在HPと同じに

        // 死んだらプレハブを生成して自身を消す
        if (Status.currentLife <= 0)
        {
            GameObject death = Instantiate(m_DeathObject);
            death.transform.position = this.transform.position;
            Destroy(this.gameObject);
        }
    }

    /// <summary>
    /// 敵のステータスをセットする
    /// </summary>
    void EnemyStatusSet()
    {
        // GameManagerに登録したレベルの配列の現在の敵のレベルを呼び出し
        int enemyLv = Gamemanager.Instance.EnemyLevel[Gamemanager.Instance.m_nowEnemyLv - 1];

        // スクリプタブルオブジェクトに登録してあるenemyLvのステータスを書き写し
        Status.maxLife = m_enemyParameter.ParaData(enemyLv).MaxLife;
        Status.attack = m_enemyParameter.ParaData(enemyLv).Attack;
        Status.deffence = m_enemyParameter.ParaData(enemyLv).Deffence;
    }

    /// <summary>
    /// 攻撃をくらった時に数値を参照してダメージを計算する関数
    /// </summary>
    /// <param name="damage"></param>
    public void Damage(int damage)
    {
        Status.currentLife -= Mathf.Max(0, damage - Status.deffence);
        if (m_enemyMove.IsHit == true)
        {
            StartCoroutine(KnockBack());
        }
    }

    IEnumerator KnockBack()
    {
        yield return new WaitForSeconds(0.001f);

        m_enemyMove.IsHit = false;
    }
}



public interface IStatusModelHolder
{
    StatusModel Status { get; }
}


[Serializable]
public class StatusModel
{
    public int maxLife;
    public int currentLife;
    public int attack;
    public int deffence;
}