using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 現在未使用
/// </summary>
public class CursorManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
