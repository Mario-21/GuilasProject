using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[System.Serializable]
public class EstructuraNiveles
{
    public static int nivel;
    public static string nombreNivel;
    public void PasarNivelAnimacion(int indexNivel)
    {
        SceneManager.LoadScene(indexNivel);
    }
    public void PasarNivelNombreAnimacion(string nombre)
    {
        //Es probable que necesite un ref, me suena mucho que al hacer algo así los nombre no los pillaba bien o algo
        SceneManager.LoadScene(nombre);
    }
}
