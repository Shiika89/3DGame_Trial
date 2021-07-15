using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    [SerializeField] ItemList itemList;
    public void GetItem(int id)
    {
        string a = itemList.GetItem(id).ItemName;
        Debug.Log(a);
    }
}
