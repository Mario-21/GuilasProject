using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Nombre_Item : MonoBehaviour
{
    public int idObjetoListaNivel;
    public string nombre_Item;
    public Text nombre_Item_Text;

    string idiomaGuardado;
    public GameObject contornoItems;
    public void Escribir_Nombre()
    {
        Debug.Log("Supuesto Nombre del Objeto UI " + SaveScene.instancia.listaItemsNivelGuardar[idObjetoListaNivel].nombreObjetoEspañol);
        IdiomaGlobalManager.instanciaIdioma.SelectorTextoIdiomaConstante(nombre_Item_Text, 
            SaveScene.instancia.listaItemsNivelGuardar[idObjetoListaNivel].nombreObjetoEspañol, 
            SaveScene.instancia.listaItemsNivelGuardar[idObjetoListaNivel].nombreObjetoIngles);
        MostrarContornoObjeto();
    }
    public void MostrarContornoObjeto()
    {
        contornoItems.SetActive(true);
    }
    public void QuitarContornoObjeto()
    {
        contornoItems.SetActive(false);
    }
    private void OnDisable()
    {
        contornoItems.SetActive(false);
    }


}

