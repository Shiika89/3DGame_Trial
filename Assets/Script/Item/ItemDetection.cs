﻿using System.Collections;
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
    [SerializeField] Skill m_sill;
    ItemData m_data;
    bool m_falg = false;
    int m_heal;

    private void Start()
    {
        m_data = new ItemData(m_jewelType);
        SkillSet();
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

    void SkillSet()
    {
        m_data.Skill = m_sill;

        //foreach (var item in m_sill)
        //{
        //    if (item.jewelType == m_jewelType)
        //    {
        //        m_data.Skill = item;
        //    }
        //}
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
        Destroy(gameObject);
    }

    void PlayerHealPickUp()
    {
        m_heal = ((m_data.Para1 + m_data.Para2 + m_data.Para3) * 3);
        if (PlayerStatus.Instance.CurrentLife < 300)
        {
            if (PlayerStatus.Instance.CurrentLife + m_heal >300)
            {
                PlayerStatus.Instance.CurrentLife = 300;
                //m_chara.m_slinder.value = 100;
                Debug.Log("HPは満タンになった");
                Destroy(gameObject);
            }
            else
            {
                PlayerStatus.Instance.CurrentLife += m_heal;
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
        m_text.text = $"攻撃力  {m_data.Para1}     回復力  {((m_data.Para1 + m_data.Para2 + m_data.Para3) * 3)}\n防御力  {m_data.Para2}     SKILL Lv 1\nスタミナ  {m_data.Para3}";
    }
}

