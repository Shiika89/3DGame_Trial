using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextStage : MonoBehaviour
{
    Animator m_stageTextAnim;

    private void Start()
    {
        m_stageTextAnim = GameObject.Find("StageText").GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (Gamemanager.Instance.Key)
        {
            RandomStage.Instance.StageClear();

            PlayerStatus.Instance.gameObject.transform.position = Vector3.zero;
            Gamemanager.Instance.Stage++;
            Gamemanager.Instance.Key = false;
            m_stageTextAnim.SetTrigger("NextStage");
            ItemManager.Instance.DeleteJewel();

            RandomStage.Instance.NextStage();
            Gamemanager.Instance.StageBGM();
        }
    }
}
