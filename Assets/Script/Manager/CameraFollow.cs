using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// カメラの高さを変えれるようにするためのクラス
/// </summary>
public class CameraFollow : MonoBehaviour
{
    // ターゲットにするオブジェクト
    [SerializeField] GameObject target;
    // カメラの位置を固定するための変数
    private Vector3 distance;

    Vector3 m_posY;
    Vector3 m_posZ;
    // カメラのズームスピードを変えるための変数
    [SerializeField] float m_zoomSpeed;
    // 追従するカメラを入れる変数
    [SerializeField] Camera m_camera;

    void Start()
    {
        // カメラの位置を記憶
        distance = transform.position - target.transform.position;
    }

    void Update()
    {
        if (GameManager.Instance.m_UIflag)
        {
            return;
        }
        // マウスのホイールでカメラとターゲットの距離をyとzだけ調整
        var scrollY = Input.mouseScrollDelta.y;
        distance.y -= scrollY * m_zoomSpeed;
        distance.z += scrollY * m_zoomSpeed;
        //m_posY += transform.forward * scrollY * m_zoomSpeed;

        if (target != null)
        {
            // カメラのxとzだけを固定する
            var pos = target.transform.position + distance;
            transform.position = new Vector3(pos.x, pos.y, pos.z);
        }
    }
}
