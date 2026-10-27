using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseCin : MonoBehaviour
{
    [Header("Cinematic")]
    public int spawn;
    public int nextScene;
    public void UseCinematic()
    {
        CheckPointController.numeroCheckPoint = spawn;
        EstructuraNiveles.nivel = nextScene;
        AnimationHud.detectar_echar.SetTrigger("Detectar_Echar");
    }
}
