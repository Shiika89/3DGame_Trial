using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// エネミーのHPバーを常にカメラの方向に向ける
/// </summary>
public class HPUIRotateScript : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        transform.rotation = Camera.main.transform.rotation;
    }
}
