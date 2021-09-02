using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCube : MonoBehaviour
{
    public int m_myNum;

    GameObject m_gj;
    Test m_test;
    GameObject m_next;
    GameObject m_prev;

    // Start is called before the first frame update
    void Start()
    {
        m_gj = GameObject.Find("GameObject");
        m_test = m_gj.GetComponent<Test>();
        m_myNum = m_test.m_num - 1;
        m_next = GameObject.Find(m_myNum + 1.ToString());
    }

    // Update is called once per frame
    void Update()
    {
        DedtroyCube();
    }

    void DedtroyCube()
    {
        if (m_test.m_desNum == m_myNum && Input.GetKeyDown(KeyCode.A))
        {
            Destroy(this.gameObject);
        }
    }
}
