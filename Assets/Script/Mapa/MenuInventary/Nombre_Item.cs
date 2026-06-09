using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Nombre_Item : MonoBehaviour
{
    public int idObjetoListaNivel;
    public string nombre_Item;
    public Text nombre_Item_Text;
    public void Escribir_Nombre()
    {
        Debug.Log("Supuesto Nombre del Objeto UI " + SaveScene.instancia.listaItemsNivelGuardar[idObjetoListaNivel].nombreObjetoEspañol);
        switch (IdiomaGlobalManager.instanciaIdioma.idiomaActual)
        {
            case "Español":
                nombre_Item_Text.text = SaveScene.instancia.listaItemsNivelGuardar[idObjetoListaNivel].nombreObjetoEspañol;
                break;
            case "English":
                nombre_Item_Text.text = SaveScene.instancia.listaItemsNivelGuardar[idObjetoListaNivel].nombreObjetoIngles;
                break;
        }

    }

    
    
}

