using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathAnimation : MonoBehaviour
{
    [SerializeField] GameObject[] m_dropItem;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("ItemDrop");
        Destroy(this.gameObject, 2);
    }

    IEnumerator ItemDrop()
    {
        yield return new WaitForSeconds(1.9f);

        var number = Random.Range(0, m_dropItem.Length);
        Instantiate(m_dropItem[number], new Vector3(transform.position.x, 0.32f, transform.position.z), transform.rotation);
    }
}
