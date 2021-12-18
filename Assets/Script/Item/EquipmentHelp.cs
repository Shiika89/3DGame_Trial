using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EquipmentHelp : MonoBehaviour
{
    [SerializeField] Image m_help = default;

    public void ColorChange(Image slot)
    {
        m_help.color = slot.color;
    }
}
