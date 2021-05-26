using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDesroy : MonoBehaviour
{
    [SerializeField] public int m_life = 5;

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "EnemyAttack")
        {
            m_life--;
            if (m_life == 0)
            {
                Destroy(this.gameObject);
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
