using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DurationScene : MonoBehaviour
{
    public int indexMod;
    public int scene;
    public string nombreSiguienteEscena;
    public int checkpoint;

    float timeScene;
    public float timeSceneLimit;
    void Update()
    {
        Duration();
    }
    void Duration()
    {
        timeScene += Time.deltaTime;
        if(timeScene >= timeSceneLimit)
        {
            CheckPointController.numeroCheckPoint = checkpoint;
            EstructuraNiveles.nivel = scene;
            EstructuraNiveles.nombreNivel = nombreSiguienteEscena;
            AnimationHud.detectar_echar.SetTrigger("Detectar_Echar");
            StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion = true;
        }
    }
}
