using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class LostCameraControl : MonoBehaviour
{
    public CinemachineVirtualCamera cineMachineCamera;
    public bool refer;
    void PerderCamera()
    {
        cineMachineCamera.Follow = null;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PerderCamera();
        }
    }
}
