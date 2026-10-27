using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeepText
{
    public static string[] cadenaTexto;

    public void ColocarTextoNota(Text textoNote)
    {
        textoNote.text = cadenaTexto[0];
    }
    public void KeepTextCadena (string[] otraCadena)
    {
        cadenaTexto = otraCadena;
    }
    public void DebugCadenaTextos()
    {
        Debug.Log("El contenido de la cadena dice " + cadenaTexto[0]);
        Debug.Log("La cantidad de cadenas guardadas es de " + cadenaTexto.Length);
    }
}
