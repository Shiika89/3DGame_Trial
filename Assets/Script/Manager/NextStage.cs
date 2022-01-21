using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextStage : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        //if (Gamemanager.Instance.m_key)
        //{
        //    Gamemanager.Instance.m_stage++;
        //    SceneManager.LoadScene("GameScene");
        //}

        if (Gamemanager.Instance.m_key)
        {
            RandomStage.Instance.StageClear();

            PlayerStatus.Instance.gameObject.transform.position = Vector3.zero;
            Gamemanager.Instance.m_stage++;
            Gamemanager.Instance.m_key = false;

            RandomStage.Instance.NextStage();
        }
    }
}
