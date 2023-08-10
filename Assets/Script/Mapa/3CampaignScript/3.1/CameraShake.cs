using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using FMOD.Studio;

public class CameraShake : MonoBehaviour
{
    public CinemachineVirtualCamera cineMachineCamera;

    public int zonaModificada;
    private void Awake()
    {

    }
    public void Shake()
    {
        
        CinemachineBasicMultiChannelPerlin cineMachinePerlin = cineMachineCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();

        cineMachinePerlin.m_AmplitudeGain = 1f;

        EstructuraNiveles.nivel = zonaModificada;
    }
}
