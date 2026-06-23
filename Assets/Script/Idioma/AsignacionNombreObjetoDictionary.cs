using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsignacionNombreObjetoDictionary : MonoBehaviour
{
    void Start()
    {
        //EstablecerNombresObjetosNivel();
        Invoke("EstablecerNombresObjetosNivel", 1f);
    }
    private void Update()
    {
        /*
        DataPersistenceManager.instance.itemDataLanguage.itemsName.TryGetValue(SaveScene.instancia.listaItemsNivelGuardar[indexSavedata].idObjeto, out idioma);
        SaveScene.instancia.listaItemsNivelGuardar[indexSavedata].nombreObjetoEspañol = idioma.spanish;
        SaveScene.instancia.listaItemsNivelGuardar[indexSavedata].nombreObjetoIngles = idioma.english;
        */
    }
    void EstablecerNombresObjetosNivel()
    {
        for (int i = 0; i < SaveScene.instancia.listaItemsNivelGuardar.Count; i++)
        {
            IdiomasItems idiomasItems = new IdiomasItems();

            if(SaveScene.instancia.listaItemsNivelGuardar[i].idObjeto == "")
            {
                Debug.Log("Esto esta vacio y soy " + SaveScene.instancia.listaItemsNivelGuardar[i].nombreObjeto);
            }
            else
            {
                //idioma = new IdiomasItems();
                Debug.Log("Esto esta relleno y soy " + SaveScene.instancia.listaItemsNivelGuardar[i].nombreObjeto);
                DataPersistenceManager.instance.itemDataLanguage.itemsName.TryGetValue(SaveScene.instancia.listaItemsNivelGuardar[i].idObjeto, out idiomasItems);
                SaveScene.instancia.listaItemsNivelGuardar[i].nombreObjetoEspañol = idiomasItems.spanish;
                SaveScene.instancia.listaItemsNivelGuardar[i].nombreObjetoIngles = idiomasItems.english;
            }
        }
    }

    /*
    void EstablecerObjetosNivelLista()
    {
        for (int i = 0; i < objetosNivel.Count; i++)
        {
            IdiomasItems idiomasItems = new IdiomasItems();

            DataPersistenceManager.instance.itemDataLanguage.itemsName.TryGetValue(objetosNivel[i].idObjeto, out idiomasItems);

            SaveScene.instancia.listaItemsNivelGuardar[objetosNivel[i].idListaNivelObjetos].nombreObjetoEspañol = idiomasItems.spanish;
            SaveScene.instancia.listaItemsNivelGuardar[objetosNivel[i].idListaNivelObjetos].nombreObjetoIngles = idiomasItems.english;
            //DataPersistenceManager.instance.itemDataLanguage.itemsName.TryGetValue(SaveScene.instancia.listaItemsNivelGuardar[i].idObjeto, out idiomasItems);
            //SaveScene.instancia.listaItemsNivelGuardar[i].nombreObjetoEspañol = idiomasItems.spanish;
            //SaveScene.instancia.listaItemsNivelGuardar[i].nombreObjetoIngles = idiomasItems.english;
        }
    }
    */
}
