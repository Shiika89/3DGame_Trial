using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Gamemanager.m_key = true;
        Destroy(gameObject);
    }
}
