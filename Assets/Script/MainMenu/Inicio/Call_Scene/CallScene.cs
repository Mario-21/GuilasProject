using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CallScene : MonoBehaviour
{
    public int scene;
    public string nombreEscena;
    [Header("Transicion Animacion")]
    public string nameAnimVar;
    public Animator transtion;
    public void CallNewScene()
    {
        Calls_Transition calls = new Calls_Transition();
        calls.Call(transtion, nameAnimVar);
        //Desactivar colliders para que no se pueda volver a presionar el bton
        EstructuraNiveles.nivel = scene;
        EstructuraNiveles.nombreNivel = nombreEscena;
    }
}
