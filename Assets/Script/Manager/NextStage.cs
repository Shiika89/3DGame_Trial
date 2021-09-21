using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextStage : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Gamemanager.m_stage++;
        SceneManager.LoadScene("GameScene");
    }
}
