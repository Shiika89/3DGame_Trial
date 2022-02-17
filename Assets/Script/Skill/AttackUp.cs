using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackUp : MonoBehaviour
{
    [SerializeField] float m_attackBuff;

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            PlayerStatus.Instance.Attack += PlayerStatus.Instance.Attack * (int)m_attackBuff;
            Debug.Log("AttackUp");
        }
    }
}
