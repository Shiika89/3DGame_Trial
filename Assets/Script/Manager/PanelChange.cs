using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PanelChange : MonoBehaviour
{
    static public PanelChange Instance;

    [SerializeField] GameObject m_gouseiPanel;

    public bool IsGouseiPanel { get; set; } 

    private void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        IsGouseiPanel = false;
        m_gouseiPanel.SetActive(false);
    }

    public void ActiveTrue()
    {
        m_gouseiPanel.SetActive(true);
        IsGouseiPanel = true;
        InventoryManager.Instance.SelectItem();
    }

    public void ActiveFalse()
    {
        IsGouseiPanel = false;
        m_gouseiPanel.SetActive(false);
        InventoryManager.Instance.SelectItem();
    }
}
