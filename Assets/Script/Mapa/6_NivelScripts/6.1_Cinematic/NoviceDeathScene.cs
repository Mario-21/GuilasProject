using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class NoviceDeathScene : MonoBehaviour
{
    public int indexMod;
    [Header("Return Scene")]
    public int nextScene;
    public string nombreSiguienteEscena;
    [Header("Checkpoint")]
    public int checkpoint;
    [Header("Soldados Cinematic")]
    [SerializeField] SoldadoNormal soldado1;
    [SerializeField] SoldadoNormal soldado2;
    [Header("Ubicaciones Salida")]
    [SerializeField] Transform ubiSalida1;
    enum SceneNovice 
    {
        First,
        Second,
        Third,
        Fourth
    }
    SceneNovice sceneNoviceDeath;
    public float timeScene;
    public float timeSceneLimit;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CinematicNoviceDeath();
    }

    void CinematicNoviceDeath()
    {
        switch (sceneNoviceDeath)
        {
            case SceneNovice.First:
                EstructuraNiveles.nivel = nextScene;
                EstructuraNiveles.nombreNivel = nombreSiguienteEscena;
                CheckPointController.numeroCheckPoint = checkpoint;
                StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion = true;
                timeScene += Time.deltaTime;
                if (timeScene >= timeSceneLimit)
                {
                    soldado1.enabled = true;
                    sceneNoviceDeath = SceneNovice.Second;
                    timeScene = 0;
                }
                
                break;
            case SceneNovice.Second:
                soldado1.ubicacionesDirigir[0] = ubiSalida1;
                timeScene += Time.deltaTime;
                if (timeScene >= 1)
                {
                    Debug.Log("Dados");
                    soldado2.ubicacionesDirigir[0] = ubiSalida1;
                    sceneNoviceDeath = SceneNovice.Third;
                    timeScene = 0;
                }
                break;
            case SceneNovice.Third:
                AnimationHud.detectar_echar.SetTrigger("Detectar_Echar");
                break;
            case SceneNovice.Fourth:
                break;
        }
    }
}
