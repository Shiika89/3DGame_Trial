using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardianArea : SkillBase
{
    [SerializeField] float m_areaDamege;
        
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            var attack = other.GetComponent<EnemyStatus>();
            if (attack != null)
            {
                attack.Status.currentLife -= (int)m_areaDamege;
            }
        }
    }
}
