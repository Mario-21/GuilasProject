using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CientificoCinematic : MonoBehaviour
{
    public int indexMod;
    [Header("Regresar Escena Anterior")]
    public int checkpointSpawn;
    public int siguienteEscena;
    [Header("Scientific Data Scene")]
    [SerializeField] SoldadoNormal scientific;
    [Header("Actions in Scene")]
    public GameObject blackScreen;
    enum Scientific_Scenes
    {
        Start_Scene,
        Middle_Scene,
        End_Scene,
    }

    Scientific_Scenes scientific_Cinematic;

    float tiempoEscena;
    [Header("Tiempo Transcurso Escena")]
    public float duracionEntreEscena;


    // Update is called once per frame
    private void Update()
    {
        CientificoCinematica();
    }
    void CientificoCinematica()
    {
        switch (scientific_Cinematic)
        {
            case Scientific_Scenes.Start_Scene:
                //Espera el tiempo necesario a que el soldado se active
                if (tiempoEscena >= duracionEntreEscena)
                {
                    scientific.enabled = true;
                    //Cuando el soldado llega a la ubicación indicada "cerrará" la puerta de golpe
                    if (scientific.transform.position.x == scientific.ubicacionesDirigir[0].position.x)
                    {
                        AudioManager.instancia.PlayOneShot(FMODEvent.instancia.puertaHidden);
                        blackScreen.SetActive(true);
                        scientific_Cinematic = Scientific_Scenes.Middle_Scene;
                        tiempoEscena = 0;
                    }

                }
                else tiempoEscena += Time.deltaTime;
                break;
            case Scientific_Scenes.Middle_Scene:
                Debug.Log("Second Stage");
                //Colocará la variable correspondiente y reproducirá un sonido de cerrado de puerta.
                if(tiempoEscena >= 1)
                {
                    AudioManager.instancia.PlayOneShot(FMODEvent.instancia.cerrar_Abrir_Lock);
                    StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion = true;
                    scientific_Cinematic = Scientific_Scenes.End_Scene;
                }
                else tiempoEscena += Time.deltaTime;
                break;
            case Scientific_Scenes.End_Scene:
                //Regresas a la escena en la que estabas
                CheckPointController.numeroCheckPoint = checkpointSpawn;
                EstructuraNiveles.nivel = siguienteEscena;
                AnimationHud.detectar_echar.SetTrigger("Detectar_Echar");
                break;
        }
    } 
}
