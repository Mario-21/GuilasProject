using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PasarNivel : MonoBehaviour
{
    EstructuraNiveles cambiarZona = new EstructuraNiveles();

    public void CambiarZona()
    {
        int nivelDirigir = EstructuraNiveles.nivel;


        cambiarZona.PasarNivelAnimacion(nivelDirigir);
        Time.timeScale = 1;

        Debug.Log("Cargando el nivel real número: " + nivelDirigir);
    }

}
