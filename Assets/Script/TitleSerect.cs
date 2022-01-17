using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleSerect : MonoBehaviour
{
    public void TimeAttack()
    {
        Gamemanager.Instance.m_timeAttack = true;
        SceneManager.LoadScene("GameScene");
    }

    public void Loop()
    {
        SceneManager.LoadScene("GameScene");
    }
}
