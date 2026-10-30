using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SelectorNiveles : MonoBehaviour
{
    public int escenaPantallaCarga;
    public string nombreEscenaPantallaCarga;
    private void Start()
    {
        
    }
    public void NivelDefinicion(string nombreNivel)
    {
        EstructuraNiveles.nivel = escenaPantallaCarga;
        EstructuraNiveles.nombreNivel = nombreEscenaPantallaCarga;
        ControladorListasNivel.nombreSiguienteNivel = nombreNivel;
        AnimationHud.detectar_echar.SetTrigger("Detectar_Echar");
    }
}
