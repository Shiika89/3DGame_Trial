using System;
using UnityEngine;
using UnityEngine.UI;

public class Character : MonoBehaviour, IStatusModelHolder, IDamagable
{
    [SerializeField] private StatusModel m_Status;
    public StatusModel Status => m_Status;

    [SerializeField] GameObject m_DeathObject;

    [SerializeField] GameObject m_HPUI;

    [SerializeField] GameObject m_attackRange;

    private Slider m_slinder;

    private void Start()
    {
        m_slinder = m_HPUI.transform.Find("HPBar").GetComponent<Slider>();
        Status.currentLife = Status.maxLife; // 現在HPを初期HPに
        m_slinder.maxValue = Status.maxLife; // HPスライダーの最大値を初期HPと同じに
        m_slinder.value = Status.currentLife;  //　スライダーの値を現在HPと同じに
    }

    public void Damage(int damage)
    {
        Status.currentLife -= Mathf.Max(0, damage - Status.deffence);
        m_slinder.value -= Mathf.Max(0, damage - Status.deffence);
        if (Status.currentLife <= 0)
        {
            Debug.Log("my health is less than or equal to 0");
            GameObject death = Instantiate(m_DeathObject);
            death.transform.position = this.transform.position;
            Destroy(this.gameObject);
        }
    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    var attack = other.GetComponent<IDamagable>();

    //    if (attack != null)
    //    {
    //        attack.Damage(Status.attack);
    //        //Debug.Log($"on attack to {other.gameObject.name}");
    //    }
    //}
}

//public class Sample : MonoBehaviour, IDamagable
//{
//    int health;
//    [SerializeField]
//    private int m_AttackValue = 5;
//    public void Damage(int damage)
//    {
//        health -= damage;
//    }

//    private void OnCollisionEnter(Collision collision)
//    {
//        if(collision is IDamagable damagable)
//        {
//            damagable.Damage(m_AttackValue);
//        }
//    }
//}

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