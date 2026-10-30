using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Elevator_Automatic_Asig : MonoBehaviour
{
    [Header("Player")]
    [SerializeField] BloquearMovimientoPlayer bloqPlayer;
    [Header("Camera")]
    [SerializeField] CinemachineVirtualCamera mainCamera;
    [SerializeField] float magnitudAscensor;
    [Header("InfoPisos")]
    public List<InfoPisos> informacion_Pisos;
    [Header("Info del Piso Actual")]

    public Pisos_Ascensor piso_Actual;
    public enum Pisos_Ascensor
    {
        Piso_0,
        Piso_1,
        Piso_2,
        Piso_3,
        Default
    }
    void GoPisoAuto(int piso)
    {
        Debug.Log("Escena Piso");
        AudioManager.instancia.PlayOneShot(FMODEvent.instancia.buttonAscensor_UI);
        AudioManager.instancia.PlayOneShot(FMODEvent.instancia.ascensorAction);
        EstructuraNiveles.nivel = piso;
        AnimationHud.detectar_echar.SetTrigger("Detectar_Echar");
        bloqPlayer.BloquearMovPlayer();
        mainCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_AmplitudeGain = magnitudAscensor;
    }
    void GoPisoNombreAuto(string pisoNombreEscena)
    {
        Debug.Log("Escena Piso");
        AudioManager.instancia.PlayOneShot(FMODEvent.instancia.buttonAscensor_UI);
        AudioManager.instancia.PlayOneShot(FMODEvent.instancia.ascensorAction);
        EstructuraNiveles.nombreNivel = pisoNombreEscena;
        AnimationHud.detectar_echar.SetTrigger("Detectar_Echar");
        bloqPlayer.BloquearMovPlayer();
        mainCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_AmplitudeGain = magnitudAscensor;
    }
    void SpawnPisoAuto(int spawn)
    {
        Debug.Log("Spawn Piso");
        CheckPointController.numeroCheckPoint = spawn;
    }
    public void AsigPisoAuto()
    {
        switch (piso_Actual)
        {
            case Pisos_Ascensor.Piso_0:
                Debug.Log("Te diriges al piso " + informacion_Pisos[0].nombrePiso);
                GoPisoAuto(informacion_Pisos[0].escenaDelPiso);
                GoPisoNombreAuto(informacion_Pisos[0].nombreEscenaPiso);
                SpawnPisoAuto(informacion_Pisos[0].spawnPiso);
                break;
            case Pisos_Ascensor.Piso_1:
                Debug.Log("Te diriges al piso " + informacion_Pisos[1].nombrePiso);
                GoPisoAuto(informacion_Pisos[1].escenaDelPiso);
                GoPisoNombreAuto(informacion_Pisos[1].nombreEscenaPiso);
                SpawnPisoAuto(informacion_Pisos[1].spawnPiso);
                break;
            case Pisos_Ascensor.Piso_2:
                Debug.Log("Te diriges al piso " + informacion_Pisos[2].nombrePiso);
                GoPisoAuto(informacion_Pisos[2].escenaDelPiso);
                GoPisoNombreAuto(informacion_Pisos[2].nombreEscenaPiso);
                SpawnPisoAuto(informacion_Pisos[2].spawnPiso);
                break;
            case Pisos_Ascensor.Piso_3:
                Debug.Log("Te diriges al piso " + informacion_Pisos[3].nombrePiso);
                GoPisoAuto(informacion_Pisos[3].escenaDelPiso);
                GoPisoNombreAuto(informacion_Pisos[3].nombreEscenaPiso);
                SpawnPisoAuto(informacion_Pisos[3].spawnPiso);
                break;

        }
    }
    
}
