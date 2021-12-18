using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Jewelにつけて自分がなんの種類なのか管理する
/// </summary>
public class ItemDetection : MonoBehaviour
{
    [Tooltip("自分がどの種類のJewelなのか設定")]
    [SerializeField] JewelType m_jewelType;
    [Tooltip("子についてるUI")]
    [SerializeField] Canvas m_canvas;
    [SerializeField] Text m_text;
    ItemData m_data;
    bool m_falg = false;
    int m_heal;

    private void Start()
    {
        
        m_data = new ItemData(m_jewelType);
        ItemText();
    }

    private void Update()
    {
        if (m_falg)
        {
            if (Input.GetKeyDown(KeyCode.E)) //アイテムを回収
            {
                ItemPickUp();
            }
            if (Input.GetKeyDown(KeyCode.Q)) // アイテムを消費して体力を回復
            {
                PlayerHealPickUp();
            }
            
        }
    }

    /// <summary>
    /// プレイヤーがアイテムの検知内に入ったらUIを表示
    /// </summary>
    /// <param name="other"></param>
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            m_falg = true;
            m_canvas.gameObject.SetActive(true);
        }
    }

    /// <summary>
    /// プレイヤーがアイテムの検知外に出たらUIを非表示
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            m_falg = false;
            m_canvas.gameObject.SetActive(false);
        }
    }

    /// <summary>
    /// 拾うボタンを押した時に
    /// なんのアイテムを拾ったかをItemManagerに報告、自身を削除
    /// </summary>
    void ItemPickUp()
    {
        ItemManager.Instance.ItemGet(m_data);
        //PlayerStatus.m_attack += m_data.Para1;
        //PlayerStatus.m_deffence += m_data.Para2;
        //PlayerStatus.m_maxSutamina += m_data.Para3;
        //Debug.Log(m_data.Para1);
        //Debug.Log(m_data.Para2);
        Destroy(gameObject);
    }

    void PlayerHealPickUp()
    {
        m_heal = ((m_data.Para1 + m_data.Para2 + m_data.Para3) * 3);
        if (PlayerStatus.m_currentLife < 300)
        {
            if (PlayerStatus.m_currentLife + m_heal >300)
            {
                PlayerStatus.m_currentLife = 300;
                //m_chara.m_slinder.value = 100;
                Debug.Log("HPは満タンになった");
                Destroy(gameObject);
            }
            else
            {
                PlayerStatus.m_currentLife += m_heal;
                //m_chara.m_slinder.value += m_heal;
                Debug.Log($"HPが{m_heal}回復した");
                Destroy(gameObject);
            }
        }
        else
        {
            Debug.Log("HPが満タンで拾えない");
        }
    }

    private void ItemText()
    {
        Debug.Log(m_data.JewelRarity);
        m_text.text = $"攻撃力  {m_data.Para1}\n防御力  {m_data.Para2}     回復力  {((m_data.Para1 + m_data.Para2 + m_data.Para3) * 3)}\nスタミナ  {m_data.Para3}";
    }
}

