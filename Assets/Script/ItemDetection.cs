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
    ItemData m_data;
    bool m_falg = false;
    GameObject m_player;
    Character m_chara;

    private void Start()
    {
        m_data = new ItemData(m_jewelType);
        m_player = GameObject.FindGameObjectWithTag("Player");
        m_chara = m_player.GetComponent<Character>();
    }

    private void Update()
    {
        if (m_falg)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                ItemPickUp();
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
    public void ItemPickUp()
    {
        ItemManager.Instance.ItemGet(m_data);
        m_chara.Status.attack += m_data.Para1;
        m_chara.Status.deffence += m_data.Para2;
        Debug.Log(m_data.Para1);
        Debug.Log(m_data.Para2);
        Destroy(gameObject);
    }
}

