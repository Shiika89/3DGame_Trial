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
        m_data = new ItemData(m_jewelType);
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
        m_heal = ((m_data.Attack + m_data.Deffence + m_data.Sutamina) * 3);
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
        m_text.text = $"攻撃力  {m_data.Attack}    回復力  {((m_data.Attack + m_data.Deffence + m_data.Sutamina) * 3)}\n防御力  {m_data.Deffence}    SKILL Lv 1\nスタミナ  {m_data.Sutamina}";
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
                switch (m_jewelRarity)
                {
                    case JewelRarity.Normal:
                        m_attack = Random.Range(3, 5);
                        m_deffence = Random.Range(0, 3);
                        m_sutamina = Random.Range(-3, 1);
                        break;
                    case JewelRarity.Rare:
                        m_attack = Random.Range(5, 10);
                        m_deffence = Random.Range(3, 5);
                        m_sutamina = Random.Range(1, 3);
                        break;
                    case JewelRarity.SuperRare:
                        m_attack = Random.Range(10, 20);
                        m_deffence = Random.Range(5, 10);
                        m_sutamina = Random.Range(3, 6);
                        break;
                    default:
                        break;
                }
                break;
            case JewelType.Blue:
                switch (m_jewelRarity)
                {
                    case JewelRarity.Normal:
                        m_attack = Random.Range(-3, 1);
                        m_deffence = Random.Range(3, 5);
                        m_sutamina = Random.Range(0, 3);
                        break;
                    case JewelRarity.Rare:
                        m_attack = Random.Range(1, 3);
                        m_deffence = Random.Range(5, 10);
                        m_sutamina = Random.Range(3, 5);
                        break;
                    case JewelRarity.SuperRare:
                        m_attack = Random.Range(3, 6);
                        m_deffence = Random.Range(10, 20);
                        m_sutamina = Random.Range(5, 10);
                        break;
                    default:
                        break;
                }
                break;
            case JewelType.Green:
                switch (m_jewelRarity)
                {
                    case JewelRarity.Normal:
                        m_attack = Random.Range(0, 3);
                        m_deffence = Random.Range(-3, 1);
                        m_sutamina = Random.Range(3, 5);
                        break;
                    case JewelRarity.Rare:
                        m_attack = Random.Range(3, 5);
                        m_deffence = Random.Range(1, 3);
                        m_sutamina = Random.Range(5, 10);
                        break;
                    case JewelRarity.SuperRare:
                        m_attack = Random.Range(5, 10);
                        m_deffence = Random.Range(3, 6);
                        m_sutamina = Random.Range(10, 20);
                        break;
                    default:
                        break;
                }
                break;
            default:
                m_attack = 0;
                m_deffence = 0;
                m_sutamina = 0;
                break;
        }
    }
}

