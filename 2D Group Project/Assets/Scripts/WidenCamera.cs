using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WidenCamera : MonoBehaviour
{
    public Camera mainCamera;
    void OnTriggerEnter2D(Collider2D collision)
    {
        while(mainCamera.GetComponent<CinemachineVirtualCamera>().m_Lens.OrthographicSize < 10)
        {
            mainCamera.GetComponent<CinemachineVirtualCamera>().m_Lens.OrthographicSize += 0.1f;
        }
    }
}
