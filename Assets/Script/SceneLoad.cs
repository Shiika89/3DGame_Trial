using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoad : MonoBehaviour
{
    [SerializeField] GameObject m_content;

    public void Retry()
    {
        ItemReset();
        SceneManager.LoadScene("GameScene");
    }

    public void Title()
    {
        ItemReset();
        SceneManager.LoadScene("Title");
    }

    void ItemReset()
    {
        foreach (var item in InventoryManager.Instance.m_jewerData)
        {
            item.MyDestroy();
        }

        InventoryManager.Instance.m_jewerData.Clear();
    }
}
