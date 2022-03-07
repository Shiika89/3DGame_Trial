using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoad : MonoBehaviour
{
    public void Retry()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void Title()
    {
        SceneManager.LoadScene("Title");
    }
}
