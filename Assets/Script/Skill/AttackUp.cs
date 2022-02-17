using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackUp : MonoBehaviour
{
    [SerializeField] float m_attackBuff;
    float m_attackUp;
    bool m_isAttackUp;

    private void Update()
    {
        if (!m_isAttackUp)
        {
            m_isAttackUp = true;
            m_attackUp = PlayerStatus.Instance.Attack * m_attackBuff;
            PlayerStatus.Instance.Attack = (int)m_attackUp;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            PlayerStatus.Instance.Attack += PlayerStatus.Instance.Attack * (int)m_attackBuff;
            Debug.Log("AttackUp");
        }
    }
}
