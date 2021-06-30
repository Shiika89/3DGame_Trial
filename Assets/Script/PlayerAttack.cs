using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        var a = other.GetComponent<IDamage>();
        if (a != null)
        {
            a.Damage(10);
        }
    }
}
