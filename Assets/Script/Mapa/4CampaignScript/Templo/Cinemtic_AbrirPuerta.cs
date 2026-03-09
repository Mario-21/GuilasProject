using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using FMOD.Studio;

public class Cinemtic_AbrirPuerta : MonoBehaviour
{
    public int indexModificacion;

    [Header("Datos Cinematica")]
    [SerializeField] GameObject puerta;
    [SerializeField] Transform puertaObjetivo;
    [SerializeField] GameObject cambioZona;

    [Header("Camera Objective")]
    [SerializeField] CinemachineVirtualCamera cV_Camera;

    enum CinematicTemplo
    {
        transicionInicial,
        escenaPuertaTemplo,
        transicionFinal,
        endCinematic
    }

    CinematicTemplo cinematic_Templo;


    float tiempoCambiarCinematic;

    EventInstance openGateTemploSFX;
    int reproductorAudio;

    private void Start()
    {
        openGateTemploSFX = AudioManager.instancia.CreateEventInstance(FMODEvent.instancia.secretTemple); 
    }
    void Update()
    {
        CinematicTemploDoor();
    }
    void CinematicTemploDoor()
    {
        switch (cinematic_Templo)
        {
            case CinematicTemplo.transicionInicial:
                //AnimationHud.detectar_echar.SetBool("Transicion", true);
                tiempoCambiarCinematic += Time.deltaTime;
                //inventario.enabled = false;
                if (tiempoCambiarCinematic >= 1.5f)
                {
                    //Ejecuta el audio una vez para evitar que se reproduzca cada frame
                    if (reproductorAudio < 1) { openGateTemploSFX.start(); reproductorAudio++; }
                    puerta.transform.position = new Vector3(puerta.transform.position.x, puerta.transform.position.y + 0.01f, puerta.transform.position.z);
                    cV_Camera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_AmplitudeGain = 1f;
                    if (puerta.transform.position.y >= puertaObjetivo.position.y)
                    {
                        openGateTemploSFX.stop(STOP_MODE.ALLOWFADEOUT);
                        cinematic_Templo = CinematicTemplo.escenaPuertaTemplo;
                    }
                    //cV_Camera.Follow = cameraPosition;
                    //player.SetActive(false);

                }
                //cinematic_Templo = CinematicTemplo.escenaAbrirPuertaTemplo;
                //Colocar tiempo
                break;
            case CinematicTemplo.escenaPuertaTemplo:
                cV_Camera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_AmplitudeGain = 0f;
                StatusGameobjectsVariables.statusGameobject.modificacion[indexModificacion].modificacion = true;
                cambioZona.SetActive(true);
                //Colocar tiempo
                break;
            case CinematicTemplo.transicionFinal:
                /*
                cV_Camera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_AmplitudeGain = 0f;
                AnimationHud.detectar_echar.SetBool("Transicion", true);
                tiempoCambiarCinematic += Time.deltaTime;
                if(tiempoCambiarCinematic >= 1.5f)
                {
                    //cV_Camera.Follow = player.transform;
                    //player.SetActive(true);
                    cinematic_Templo = CinematicTemplo.endCinematic;
                }*/
                break;
            case CinematicTemplo.endCinematic:
                /*
                AnimationHud.detectar_echar.SetBool("Transicion", false);
                //Hacer apararecer un cambio de zona 
                //inventario.enabled = true;
                StatusGameobjectsVariables.statusGameobject.modificacion[indexModificacion].modificacion = true;*/
                break;

        }
    }
}
