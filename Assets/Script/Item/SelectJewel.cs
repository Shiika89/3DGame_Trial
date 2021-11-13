using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectJewel : MonoBehaviour
{
    [SerializeField] JewelType m_jewelType;
    public JewelType JewelType => m_jewelType;

    [SerializeField] bool m_select;

    public ItemData m_itemData { get; set; }

    EquipmentJewel m_slot1;
    EquipmentJewel m_slot2;
    EquipmentJewel m_slot3;

    [SerializeField] GameObject m_slot1Button;
    [SerializeField] GameObject m_slot2Button;
    [SerializeField] GameObject m_slot3Button;

    // Start is called before the first frame update
    void Start()
    {
        m_itemData = new ItemData(m_jewelType);
    }
    
    public void ActiveButton()
    {
        m_slot1Button.SetActive(true);
        m_slot2Button.SetActive(true);
        m_slot3Button.SetActive(true);
    }

    public void Select1()
    {
        m_slot1 = GameObject.Find("Slot1").GetComponent<EquipmentJewel>();
        m_select = true;
        m_slot1.Eqipment(this);
    }

    public void Select2()
    {
        m_slot2 = GameObject.Find("Slot2").GetComponent<EquipmentJewel>();
        m_select = true;
        m_slot2.Eqipment(this);
    }

    public void Select3()
    {
        m_slot3 = GameObject.Find("Slot3").GetComponent<EquipmentJewel>();
        m_select = true;
        m_slot3.Eqipment(this);
    }
}
