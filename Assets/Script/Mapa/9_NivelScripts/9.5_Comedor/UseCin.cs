using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseCin : MonoBehaviour
{
    [Header("Cinematic")]
    public int spawn;
    public int nextScene;
    public string nombreSiguienteEscena;
    public void UseCinematic()
    {
        CheckPointController.numeroCheckPoint = spawn;
        EstructuraNiveles.nivel = nextScene;
        EstructuraNiveles.nombreNivel = nombreSiguienteEscena;
        AnimationHud.detectar_echar.SetTrigger("Detectar_Echar");
    }
}
