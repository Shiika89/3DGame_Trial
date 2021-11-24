using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectJewel : MonoBehaviour
{
    [SerializeField] JewelType m_jewelType;
    public JewelType JewelType => m_jewelType;

    [SerializeField] bool m_select;

    [SerializeField] GameObject m_mark;

    public ItemData m_itemData { get; set; }

    [SerializeField] GameObject m_slot1Button;
    [SerializeField] GameObject m_slot2Button;
    [SerializeField] GameObject m_slot3Button;

    // Start is called before the first frame update
    public void StartSet(ItemData itemData)
    {
        m_itemData = itemData;
        gameObject.SetActive(true);
    }
    
    public void ActiveButton()
    {
        if (m_select) return;
        InventoryManager.Instance.SelectItem();
        m_slot1Button.SetActive(true);
        m_slot2Button.SetActive(true);
        m_slot3Button.SetActive(true);
        InventoryManager.Instance.OnSelectItem += InactiveButton;
    }

    public void InactiveButton()
    {
        m_slot1Button.SetActive(false);
        m_slot2Button.SetActive(false);
        m_slot3Button.SetActive(false);
        InventoryManager.Instance.OnSelectItem -= InactiveButton;
    }

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

    public void SelectOut()
    {
        m_select = false;
        m_mark.SetActive(false);
    }
    public void Equipment()
    {
        m_select = true;
        m_mark.SetActive(true);
    }
}
