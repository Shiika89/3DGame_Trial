using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    GameObject m_key;

    private void Start()
    {
        m_key = GameObject.Find("Key");
        m_key.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        GameManager.Instance.Key = true;
        m_key.SetActive(true);
        Destroy(gameObject);
    }
}
