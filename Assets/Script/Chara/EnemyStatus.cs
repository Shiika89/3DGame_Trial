using System;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// プレイヤーやエネミーのステータスやダメージ処理
/// </summary>
public class EnemyStatus : MonoBehaviour, IStatusModelHolder, IDamagable
{
    //[SerializeField] EnemyParameter m_enemyParameter;

    [SerializeField] EnemyParameter[] m_enemyParameters;

    private StatusModel m_status = new StatusModel();
    public StatusModel Status => m_status;

    [SerializeField] GameObject m_DeathObject;

    [SerializeField] GameObject m_HPUI;

    [SerializeField] GameObject m_attackRange;

    public Slider m_slinder { get; set; }

    private void Start()
    {
        m_slinder = m_HPUI.transform.Find("HPBar").GetComponent<Slider>();

        //Status.maxLife = m_enemyParameter.GetMaxLife(Gamemanager.Instance.m_stage -1);
        //Status.attack = m_enemyParameter.GetAttack(Gamemanager.Instance.m_stage  - 1);
        //Status.deffence = m_enemyParameter.GetDeffence(Gamemanager.Instance.m_stage - 1);

        switch (Gamemanager.Instance.m_gameLevel)
        {
            case 0:
                Status.maxLife = m_enemyParameters[0].maxLife;
                Status.attack = m_enemyParameters[0].attack;
                Status.deffence = m_enemyParameters[0].deffence;
                break;
            case 1:
                Status.maxLife = m_enemyParameters[1].maxLife;
                Status.attack = m_enemyParameters[1].attack;
                Status.deffence = m_enemyParameters[1].deffence;
                break;
            case 2:
                Status.maxLife = m_enemyParameters[2].maxLife;
                Status.attack = m_enemyParameters[2].attack;
                Status.deffence = m_enemyParameters[2].deffence;
                break;
            default:
                break;
        }

        Status.currentLife = Status.maxLife; // 現在HPを初期HPに
        m_slinder.maxValue = Status.maxLife; // HPスライダーの最大値を初期HPと同じに
        
    }

    private void Update()
    {
        m_slinder.value = Status.currentLife;  //　スライダーの値を現在HPと同じに
    }

    public void Damage(int damage)
    {
        Status.currentLife -= Mathf.Max(0, damage - Status.deffence);
        if (Status.currentLife <= 0)
        {
            GameObject death = Instantiate(m_DeathObject);
            death.transform.position = this.transform.position;
            Destroy(this.gameObject);
        }
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