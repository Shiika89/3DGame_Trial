using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentData : MonoBehaviour
{
    GameObject m_player;
    EnemyStatus m_chara;
    List<JewerData> m_eqip;

    [Tooltip("生成するUIの親")]
    [SerializeField] JewerData m_JewelUIParent;
    [SerializeField] GameObject m_eqipUI;

    // Start is called before the first frame update
    void Start()
    {
        m_player = GameObject.FindGameObjectWithTag("Player");
        m_chara = m_player.GetComponent<EnemyStatus>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
