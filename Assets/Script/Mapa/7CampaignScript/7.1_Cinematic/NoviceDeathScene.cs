using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoviceDeathScene : MonoBehaviour
{
    public int indexMod;
    [Header("Return Scene")]
    public int nextScene;
    [Header("Checkpoint")]
    public int checkpoint;
    [Header("Soldados Cinematic")]
    [SerializeField] SoldadoNormal soldado1;
    [SerializeField] SoldadoNormal soldado2;
    [Header("Flower")]
    public GameObject flowerSoldado;
    public GameObject flowerTumba;
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
    float timeScene;
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
                CheckPointController.numeroCheckPoint = checkpoint;
                StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion = true;
                timeScene += Time.deltaTime;
                if (timeScene >= 3)
                {
                    soldado1.enabled = true;
                    sceneNoviceDeath = SceneNovice.Second;
                }
                
                break;
            case SceneNovice.Second:

                timeScene -= Time.deltaTime;
                if (timeScene <= 0)
                {
                    flowerSoldado.SetActive(false);
                    flowerTumba.SetActive(true);
                    sceneNoviceDeath = SceneNovice.Third;
                }
                break;
            case SceneNovice.Third:
                soldado1.ubicacionesDirigir[0] = ubiSalida1;
                timeScene += Time.deltaTime;
                if (timeScene >= 2)
                {
                    soldado2.ubicacionesDirigir[0] = ubiSalida1;
                    sceneNoviceDeath = SceneNovice.Fourth;
                }
                break;
            case SceneNovice.Fourth:
                AnimationHud.detectar_echar.SetTrigger("Detectar_Echar");
                break;
        }
    }
}
