using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    GameObject m_key;

    private void Start()
    {
        m_key = GameObject.Find("KeyUI");
        m_key.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        Gamemanager.Instance.m_key = true;
        m_key.SetActive(true);
        Destroy(gameObject);
    }
}
