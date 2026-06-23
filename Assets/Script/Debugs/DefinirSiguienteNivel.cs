using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefinirSiguienteNivel : MonoBehaviour
{
    [Tooltip("Con este nombre podrás saber a que nivel te diriges, haciendo que en la siguiente pantalla de carga se administren todos los objetos del nivel")]
    public string siguienteNivelNombre;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ControladorListasNivel.nombreSiguienteNivel = siguienteNivelNombre;
        //EstablecerSiguienteNivel(siguienteNivelNombre);
    }
    void EstablecerSiguienteNivel(string nombreNivel)
    {
        ControladorListasNivel.nombreSiguienteNivel = siguienteNivelNombre;
    }
}
