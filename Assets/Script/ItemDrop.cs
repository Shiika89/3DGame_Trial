using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDrop : MonoBehaviour
{
    public GameObject[] m_dropitem;
    
    public void RamdomItemDrop()
    {
        var number = Random.Range(0, m_dropitem.Length);
        Instantiate(m_dropitem[number], transform.position, transform.rotation);
    }
}
