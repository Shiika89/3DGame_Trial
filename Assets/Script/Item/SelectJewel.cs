using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// アイテムのUI自身に持たせて自分を装備するかを選択する
/// </summary>
public class SelectJewel : MonoBehaviour
{
    [Tooltip("自分がなんのジュエルかを覚えておくための変数")]
    [SerializeField] JewelType m_jewelType;
    public JewelType JewelType => m_jewelType;

    [Tooltip("自分が装備中かを判定するためのフラグ")]
    [SerializeField] bool m_select;

    [Tooltip("装備中に表示するマーク")]
    [SerializeField] GameObject m_mark;

    [Tooltip("宝玉UIのスキルレベルが分かるように付けるテキスト")]
    [SerializeField] Text m_skillLvText;

    public ItemData m_itemData { get; set; }

    // 装備スロットを登録する変数
    [SerializeField] GameObject m_slot1Button;
    [SerializeField] GameObject m_slot2Button;
    [SerializeField] GameObject m_slot3Button;

    // 合成スロットを登録する
    [SerializeField] GameObject m_GouseiSlot1;
    [SerializeField] GameObject m_GouseiSlot2;

    /// <summary> 合成スロットに選択されているか判別するフラグ </summary>
    public bool IsGouseiSelect { get; set; }

    public bool IsSlot1 { get; private set; }
    public bool IsSlot2 { get; private set; }
    public bool IsSlot3 { get; private set; }


    private void Update()
    {
        m_skillLvText.text = $"{m_itemData.Skill.SkillLevel}";
    }

    /// <summary>
    /// 親が生成された時に呼ばれる変数、自分をアクティブにしてアイテムデータを読み込む
    /// </summary>
    /// <param name="itemData"></param>
    public void StartSet(ItemData itemData)
    {
        m_itemData = itemData;
        gameObject.SetActive(true);
    }
    
    /// <summary>
    /// ボタンに設定する関数、押すとどのスロットに装備するかのボタンを呼び出す
    /// </summary>
    public void ActiveButton()
    {
        SelectJewelText.Instance.SelectText(m_itemData);

        // 合成パネルを開いていて自分がスロットに設定されていなければ
        if (PanelChange.Instance.IsGouseiPanel && !IsGouseiSelect)
        {
            m_GouseiSlot1.SetActive(true);
            m_GouseiSlot2.SetActive(true);
        }

        // 装備中はボタンを表示しない
        if (m_select)
        {
            InventoryManager.Instance.OnSelectItem += InActiveButton;
            return;
        }

        // 装備せずに違うアイテムを選んだ時にスロットボタンを消す、他に何も選んでなければ何も要録されていないからスルーする
        InventoryManager.Instance.SelectItem();

        if (!PanelChange.Instance.IsGouseiPanel)
        {
            m_slot1Button.SetActive(true);
            m_slot2Button.SetActive(true);
            m_slot3Button.SetActive(true);
        }

        // OnSelectItemのイベントにInactiveButtonの関数を登録
        InventoryManager.Instance.OnSelectItem += InActiveButton;
    }

    /// <summary>
    /// 表示しているスロットボタンを消すための関数
    /// </summary>
    public void InActiveButton()
    {
        m_GouseiSlot1.SetActive(false);
        m_GouseiSlot2.SetActive(false);

        m_slot1Button.SetActive(false);
        m_slot2Button.SetActive(false);
        m_slot3Button.SetActive(false);
        
        // OnSelectItemのイベントからInactiveButtonの関数を消す
        InventoryManager.Instance.OnSelectItem -= InActiveButton;
    }

    // 選択したスロットから装備する関数を呼び出すためにボタンに設定する関数
    public void Select1()
    {
        InventoryManager.Instance.EquipmentJewels[0].Eqipment(this);
        InventoryManager.Instance.SelectItem();
        IsSlot1 = true;
    }

    public void Select2()
    {
        InventoryManager.Instance.EquipmentJewels[1].Eqipment(this);
        InventoryManager.Instance.SelectItem();
        IsSlot2 = true;
    }

    public void Select3()
    {
        InventoryManager.Instance.EquipmentJewels[2].Eqipment(this);
        InventoryManager.Instance.SelectItem();
        IsSlot3 = true;
    }

    // 合成パネルにセットする関数、ボタンにつける
    public void Set1()
    {
        Gousei.Instance.SetJewel1(this);
        Gousei.Instance.IsSlot1 = true;
        IsGouseiSelect = true;
    }

    public void Set2()
    {
        Gousei.Instance.SetJewel2(this);
        Gousei.Instance.IsSlot2 = true;
        IsGouseiSelect = true;
    }

    /// <summary>
    /// 装備から外れたらフラグとマークをオフにする
    /// </summary>
    public void SelectOut()
    {
        m_select = false;
        m_mark.SetActive(false);

        IsSlot1 = false;
        IsSlot2 = false;
        IsSlot3 = false;
    }

    /// <summary>
    /// 自分装備中フラグをオンにし、装備中のマークをアクティブにする
    /// </summary>
    public void Equipment()
    {
        m_select = true;
        m_mark.SetActive(true);
    }

    public void JewelOut()
    {
        var data = gameObject.GetComponentInParent<JewerData>();
        InventoryManager.Instance.m_jewerData.Remove(data);
        data.MyDestroy();
    }
}
