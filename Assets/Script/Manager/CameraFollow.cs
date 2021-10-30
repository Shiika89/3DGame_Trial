using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject target;
    private Vector3 distance;

    [SerializeField] float m_zoomSpeed;
    [SerializeField] Camera m_camera;

    void Start()
    {
        distance = transform.position - target.transform.position;
    }

    void Update()
    {
        var pos = target.transform.position + distance;
        transform.position = new Vector3(pos.x, transform.position.y, pos.z);

        var scroll = Input.mouseScrollDelta.y;
        m_camera.transform.position += -m_camera.transform.forward * scroll * m_zoomSpeed;
    }
}
