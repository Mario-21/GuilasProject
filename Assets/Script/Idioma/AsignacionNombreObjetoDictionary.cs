using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsignacionNombreObjetoDictionary : MonoBehaviour
{
    // Start is called before the first frame update
    public int indexObjeto;
    public bool accederObjeto;
    public List<InformacionObjetosID> objetosNivel;

    void Start()
    {
        EstablecerInventarioDictionary();
        //EstablecerInventarioDictionaryLista();
    }

    private void Update()
    {
        if (accederObjeto)
        {
            /*
            IdiomasItems idiomasItems = new IdiomasItems();
            DataPersistenceManager.instance.itemDataLanguage.itemsName.TryGetValue(SaveScene.instancia.listaItemsNivelGuardar[indexObjeto].idObjeto, out idiomasItems);

            SaveScene.instancia.listaItemsNivelGuardar[indexObjeto].nombreObjetoEspañol = idiomasItems.spanish;
            SaveScene.instancia.listaItemsNivelGuardar[indexObjeto].nombreObjetoIngles = idiomasItems.english;

            accederObjeto = false;*/
        }

    }
    void EstablecerInventarioDictionary()
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
                Debug.Log("Esto esta relleno y soy " + SaveScene.instancia.listaItemsNivelGuardar[i].nombreObjeto);
                DataPersistenceManager.instance.itemDataLanguage.itemsName.TryGetValue(SaveScene.instancia.listaItemsNivelGuardar[i].idObjeto, out idiomasItems);
                SaveScene.instancia.listaItemsNivelGuardar[i].nombreObjetoEspañol = idiomasItems.spanish;
                SaveScene.instancia.listaItemsNivelGuardar[i].nombreObjetoIngles = idiomasItems.english;
            }
        }
    }

    void EstablecerInventarioDictionaryLista()
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
}
