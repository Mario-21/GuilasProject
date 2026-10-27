using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class SeleccionIdiomaUI : MonoBehaviour
{
    public Dropdown dD;

    //public DataPersistenceManager dataPersistenceManager;
    // Start is called before the first frame update
    private void Start()
    {
        // Validación de seguridad por si acaso
        if (IdiomaGlobalManager.instanciaIdioma == null)
        {
            Debug.LogWarning("IdiomaGlobalManager.instanciaIdioma es nulo en el Start de la UI.");
            return;
        }
        //dataPersistenceManager = FindObjectOfType<DataPersistenceManager>().GetComponent<DataPersistenceManager>();

        switch (IdiomaGlobalManager.instanciaIdioma.idiomaActual)
        {
            case "Español":
                dD.value = 0;
                break;
            case "English":
                dD.value = 1;
                break;
        }
    }
    public void EstablecerIdiomaUI()
    {
        //IdiomaGlobalManager.EstablecerIdiomaStatic(IdiomaGlobalManager.todosIdiomas.ToString());
        //Debug.Log("El Idioma establecido es " + IdiomaGlobalManager.todosIdiomas.ToString());
        if (IdiomaGlobalManager.instanciaIdioma == null) return;

        switch (dD.value)
        {
            case 0:
                IdiomaGlobalManager.instanciaIdioma.idiomaActual = "Español";
                DataPersistenceManager.instance.SaveGameNoEncrypt();
                //DataPersistenceManager.instance.gamedataNoEncrypt.idioma = IdiomaGlobalManager.instanciaIdioma.idiomaActual;
                //DataPersistenceManager.instance.languageData.language = IdiomaGlobalManager.instanciaIdioma.idiomaActual;
                Debug.Log("El Idioma establecido es " + IdiomaGlobalManager.instanciaIdioma.idiomaActual);
                /*IdiomaGlobalManager.instanciaIdioma.todosIdiomas = IdiomaGlobalManager.TodosIdiomas.Español;
                Debug.Log("El Idioma establecido es " + IdiomaGlobalManager.instanciaIdioma.todosIdiomas.ToString());*/
                break;
            case 1:
                IdiomaGlobalManager.instanciaIdioma.idiomaActual = "English";
                DataPersistenceManager.instance.SaveGameNoEncrypt();
                Debug.Log("El Idioma establecido es " + IdiomaGlobalManager.instanciaIdioma.idiomaActual);
                /*
                IdiomaGlobalManager.instanciaIdioma.todosIdiomas = IdiomaGlobalManager.TodosIdiomas.English;
                Debug.Log("El Idioma establecido es " + IdiomaGlobalManager.instanciaIdioma.todosIdiomas.ToString());*/
                break;

        }
    }
    public void GuardarIdioma()
    {
        DataPersistenceManager.instance.SaveGameNoEncrypt();
    }
}
