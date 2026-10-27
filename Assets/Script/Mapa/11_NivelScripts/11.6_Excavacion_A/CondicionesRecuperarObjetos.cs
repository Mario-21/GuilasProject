using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CondicionesRecuperarObjetos : MonoBehaviour
{
    [Header("Informacion Objeto")]
    public int indexObjeto;
    public int variableObjeto;
    public GameObject objetoReaparecer;
    void Start()
    {
        if(SaveScene.instancia.listaItemsNivelGuardar[indexObjeto].vecesUsadoObjeto > 0 && !StatusGameobjectsVariables.statusGameobject.modificacion[variableObjeto].modificacion)
        {
            objetoReaparecer.SetActive(true);
        }
    }
}
