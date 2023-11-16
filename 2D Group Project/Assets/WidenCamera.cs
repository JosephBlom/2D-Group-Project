using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WidenCamera : MonoBehaviour
{
    public Camera mainCamera;
    void OnTriggerEnter2D(Collider2D collision)
    {
        mainCamera.GetComponent<CinemachineVirtualCamera>().m_Lens.OrthographicSize =85f;
    }
}