using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class AgitarCamaraEvento : MonoBehaviour
{
    public int indexMod;
    [Header("Camera Shake")]
    [SerializeField] CinemachineVirtualCamera cmCamera_1;
    [SerializeField] float cameraShake = 1;
    [SerializeField] float tiempoAgitacionLimit;
    float tiempoAgitacion;
    [Header("Anotacion")]
    [TextArea(0, 3)]
    public string nota = "Este script siempre estará unido a un ScientificRoomOpen, dado que este script sirve más como un evento de trasición que realmente como una mecánica o algo similar";
    // Update is called once per frame
    private void Start()
    {
        if (StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion)
        {
            cmCamera_1.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_AmplitudeGain = 0;
            this.enabled = false;
        }
    }
    void Update()
    {
        if (StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion)
        {
            if (tiempoAgitacion < tiempoAgitacionLimit)
            {
                tiempoAgitacion += Time.deltaTime;
                cmCamera_1.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_AmplitudeGain = cameraShake;
            }
            else if (tiempoAgitacion >= tiempoAgitacionLimit)
            {
                cmCamera_1.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_AmplitudeGain = 0;
                this.enabled = false;
            }
        }
        
    }
}
