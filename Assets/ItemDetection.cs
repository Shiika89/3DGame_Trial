using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemDetection : MonoBehaviour
{
    [SerializeField] Button m_button;

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            m_button.image.enabled = true;
        }
    }
}
