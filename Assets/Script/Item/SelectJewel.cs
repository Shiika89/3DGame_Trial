using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// アイテム自身に持たせて自分を装備するかを選択する
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

    public ItemData m_itemData { get; set; }

    // 装備スロットを登録する変数
    [SerializeField] GameObject m_slot1Button;
    [SerializeField] GameObject m_slot2Button;
    [SerializeField] GameObject m_slot3Button;

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
        // 装備中はボタンを表示しない
        if (m_select) return;

        // 装備せずに違うアイテムを選んだ時にスロットボタンを消す、他に何も選んでなければ何も要録されていないからスルーする
        InventoryManager.Instance.SelectItem();

        m_slot1Button.SetActive(true);
        m_slot2Button.SetActive(true);
        m_slot3Button.SetActive(true);

        SelectJewelText.Instance.SelectText(m_itemData);

        // OnSelectItemのイベントにInactiveButtonの関数を登録
        InventoryManager.Instance.OnSelectItem += InactiveButton;
    }

    /// <summary>
    /// 表示しているスロットボタンを消すための関数
    /// </summary>
    public void InactiveButton()
    {
        m_slot1Button.SetActive(false);
        m_slot2Button.SetActive(false);
        m_slot3Button.SetActive(false);

        // OnSelectItemのイベントからInactiveButtonの関数を消す
        InventoryManager.Instance.OnSelectItem -= InactiveButton;
    }

    // 選択したスロットから装備する関数を呼び出すためにボタンに設定する関数
    public void Select1()
    {
        Equipment();
        InventoryManager.Instance.EquipmentJewels[0].Eqipment(this);
    }

    public void Select2()
    {
        Equipment();
        InventoryManager.Instance.EquipmentJewels[1].Eqipment(this);
    }

    public void Select3()
    {
        Equipment();
        InventoryManager.Instance.EquipmentJewels[2].Eqipment(this);
    }

    /// <summary>
    /// 装備から外れたらフラグとマークをオフにする
    /// </summary>
    public void SelectOut()
    {
        m_select = false;
        m_mark.SetActive(false);
    }

    /// <summary>
    /// 自分装備中フラグをオンにし、装備中のマークをアクティブにする
    /// </summary>
    public void Equipment()
    {
        m_select = true;
        m_mark.SetActive(true);
    }
}
