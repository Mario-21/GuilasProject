using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SelectorNiveles : MonoBehaviour
{
    public int escenaPantallaCarga;
    private void Start()
    {
        
    }
    public void NivelDefinicion(string nombreNivel)
    {
        EstructuraNiveles.nivel = escenaPantallaCarga;
        ControladorListasNivel.nombreSiguienteNivel = nombreNivel;
        AnimationHud.detectar_echar.SetTrigger("Detectar_Echar");
    }
}
