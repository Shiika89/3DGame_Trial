using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemDetection : MonoBehaviour
{
    [SerializeField] JewelType m_jewelType;
    [SerializeField] Canvas m_canvas;
    [SerializeField] GameObject m_itemManagerobject;
    ItemData m_data;

    private void Start()
    {
        m_data = new ItemData(m_jewelType);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            m_canvas.gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            m_canvas.gameObject.SetActive(false);
        }
    }

    public void ItemPickUp()
    {
        ItemManager.Instance.ItemGet(m_data);
        Destroy(gameObject);
    }

    void AddItemList()
    {
        //m_itemManager.m_haveitem.Add(gameObject);
    }
}

