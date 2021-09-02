using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    [SerializeField] GameObject m_cube;
    public int m_desNum;
    public int m_num = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            var cube = Instantiate(m_cube);
            cube.transform.position = new Vector3(m_num * 2, 0, 0);
            cube.name = m_num.ToString();
            m_num++;
        }
    }
}
