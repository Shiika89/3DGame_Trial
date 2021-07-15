using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoder : MonoBehaviour
{
    public void ChangeScene(string a)
    {
        SceneManager.LoadScene(a);
    }
}
