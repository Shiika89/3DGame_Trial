using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    private void OnTriggerStay(Collider other)
    {
        var wall = other.gameObject.GetComponent<MeshRenderer>();
        if (wall)
        {
            wall.enabled = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        var wall = other.gameObject.GetComponent<MeshRenderer>();
        if (wall)
        {
            wall.enabled = true;
        }
    }
}
