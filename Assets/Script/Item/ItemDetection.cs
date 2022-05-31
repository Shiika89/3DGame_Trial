using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Jewelにつけて自分がなんの種類なのか管理する
/// </summary>
public class ItemDetection : MonoBehaviour
{
    const int PARAMETER_COUNT = 3;
    
    [Tooltip("自分がどの種類のJewelなのか設定")]
    [SerializeField] JewelType m_jewelType;

    [Tooltip("子についてるUI")]
    [SerializeField] Canvas m_canvas;

    [SerializeField] Text m_text;

    [SerializeField] JewelParameter m_jewelPara;

    Skill m_skill;
    ItemData m_data;
    JewelRarity m_jewelRarity;
    bool m_falg = false;
    int m_heal;

    int m_attack;
    int m_deffence;
    int m_sutamina;

    private void Start()
    {
        JewelRaritySet();
        JewelParaSet();
        m_data = new ItemData(m_jewelType, m_jewelRarity, m_attack, m_deffence, m_sutamina);
        m_skill = new Skill(m_jewelType);
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
        m_data.Skill = m_skill;
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
        if (PlayerStatus.Instance.CurrentLife < PlayerStatus.Instance.MaxLife)
        {
            if (PlayerStatus.Instance.CurrentLife + m_heal > PlayerStatus.Instance.MaxLife)
            {
                PlayerStatus.Instance.CurrentLife = PlayerStatus.Instance.MaxLife;
                Debug.Log("HPは満タンになった");
                Destroy(gameObject);
            }
            else
            {
                PlayerStatus.Instance.CurrentLife += m_heal;

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
        m_text.text = $"攻撃力  {m_attack}    回復力  {m_heal * 3}\n防御力  {m_deffence}    SKILL Lv 1\nスタミナ  {m_sutamina}";
    }

    void JewelRaritySet()
    {
        int rarity = Random.Range(1, 10 + 1);
        if (rarity == 10)
        {
           m_jewelRarity  = JewelRarity.SuperRare;
        }
        else if (rarity == 7 || rarity == 8 || rarity == 9)
        {
            m_jewelRarity = JewelRarity.Rare;
        }
        else
        {
            m_jewelRarity = JewelRarity.Normal;
        }
    }

    void JewelParaSet()
    {
        switch (m_jewelType)
        {
            case JewelType.Red:
                m_attack = GetParaHigh(m_jewelRarity);
                m_deffence = GetParaMiddle(m_jewelRarity);
                m_sutamina = GetParaLow(m_jewelRarity);
                break;
            case JewelType.Blue:
                m_attack = GetParaLow(m_jewelRarity);
                m_deffence = GetParaHigh(m_jewelRarity);
                m_sutamina = GetParaMiddle(m_jewelRarity);
                break;
            case JewelType.Green:
                m_attack = GetParaMiddle(m_jewelRarity);
                m_deffence = GetParaLow(m_jewelRarity);
                m_sutamina = GetParaHigh(m_jewelRarity);
                break;
            default:
                m_attack = 0;
                m_deffence = 0;
                m_sutamina = 0;
                break;
        }
        m_heal = ((m_attack + m_deffence + m_sutamina) * PARAMETER_COUNT); // 回復量を決定
    }

    private int GetParaHigh(JewelRarity rarity)
    {
        return Random.Range(m_jewelPara.High[(int)rarity].x, m_jewelPara.High[(int)rarity].y); ;
    }

    private int GetParaMiddle(JewelRarity rarity)
    {
        return Random.Range(m_jewelPara.Middle[(int)rarity].x, m_jewelPara.Middle[(int)rarity].y); ;
    }

    private int GetParaLow(JewelRarity rarity)
    {
        return Random.Range(m_jewelPara.Low[(int)rarity].x, m_jewelPara.Low[(int)rarity].y); ;
    }
}

