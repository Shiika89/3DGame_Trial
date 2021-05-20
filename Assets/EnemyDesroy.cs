using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDesroy : MonoBehaviour
{
    [SerializeField] public int m_life = 100;

    [SerializeField] int currentLife;

    int Damage = 10;

    
    // Start is called before the first frame update
    void Start()
    {
        currentLife = m_life;
    }

    // Update is called once per frame
    

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Attack")
        {
           currentLife -= Damage;


            if (currentLife == 0)
            {
                Destroy(this.gameObject);
            }
        }
    }
}
