using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System.IO;
using System;

public class PruebaIdiomaManager : MonoBehaviour
{
    [SerializeField] bool cambiarIdioma;
    [SerializeField] bool DebugIdiomaActual;

    [SerializeField] bool activarDictionary;

    public string nombreArchivoAleman;

    public string idBuscada;
    public string nombreBuscado;


    public bool addDataItemsGlobal;
    public bool ingles;
    public IdiomasItems idiomaItemsNew;

    public SerializableDictionary<string, string> objetosDatos;
    //public Dictionary<string, string> objetosDatos;
    List<string> listaIdObjetosAleman;
    List<string> listaNombreObjetosAleman;
    void Start()
    {
        /*
        EstablecerDictionary();
        //objetosDatos = new SerializableDictionary<string, string>();
        
        for (int i = 0; i < listaIdObjetosAleman.Count; i++)
        {
            objetosDatos.Add(listaIdObjetosAleman[i], listaNombreObjetosAleman[i]);
            Debug.Log(objetosDatos.Count);
        }*/
        
    }
    // Update is called once per frame
    void Update()
    {
        if (activarDictionary)
        {
            //objetosDatos.TryGetValue(idBuscada, out nombreBuscado);
            DataPersistenceManager.instance.itemDataLanguage.spanishItemsName.TryGetValue(idBuscada, out nombreBuscado);
        }
        if (addDataItemsGlobal)
        {
            //DataPersistenceManager.instance.itemDataLanguage.itemsName.Add(idBuscada, idiomaItemsNew);

            IdiomasItems idiomaNombreItem = new IdiomasItems();

            DataPersistenceManager.instance.itemDataLanguage.itemsName.TryGetValue(idBuscada, out idiomaItemsNew);

            if (ingles)
            {
                nombreBuscado = idiomaItemsNew.english;
            }
            else
            {
                nombreBuscado = idiomaItemsNew.spanish;
            }
            
            

            //addDataItemsGlobal = false;
        }
        /*
        if (cambiarIdioma)
        {
            IdiomaGlobalManager.todosIdiomas = IdiomaGlobalManager.TodosIdiomas.Ingles;
        }
        else 
        {
            IdiomaGlobalManager.todosIdiomas = IdiomaGlobalManager.TodosIdiomas.Español;
        }*/
        if (DebugIdiomaActual)
        {
            Debug.Log("El idioma Actual elegido es " + IdiomaGlobalManager.instanciaIdioma.idiomaActual);
            //IdiomaGlobalManager.EstablecerIdiomaStatic(IdiomaGlobalManager.todosIdiomas.ToString());
        }
    }
    [ContextMenu("Limpia el dictionary del DataPersistance")]
    public void ClearDictionary()
    {
        DataPersistenceManager.instance.itemDataLanguage.itemsName.Clear();
    }

    void EstablecerDictionary()
    {
        string readFromFilePathAlemanId;
        readFromFilePathAlemanId = Application.dataPath + "/Idiomas/Aleman/Id_ObjetosAleman.txt";
        listaIdObjetosAleman = File.ReadAllLines(readFromFilePathAlemanId).ToList();
        string readFromFilePathAlemanNombre;
        readFromFilePathAlemanNombre = Application.dataPath + "/Idiomas/Aleman/Nombre_ObjetosAleman.txt";
        listaNombreObjetosAleman = File.ReadAllLines(readFromFilePathAlemanNombre).ToList();
    }

    void CrearArchivoAleman()
    {
        string path = Application.dataPath + "/Idiomas/Aleman/";

        string fullPath = Path.Combine(path, nombreArchivoAleman);

        if (File.Exists(fullPath))
        {
            Debug.Log("Existo,por tanto, no tengo que hacer nada");
            //File.WriteAllText(fullPath, FileDataHandler.EncryptDecrypt(File.ReadAllText(fullPath)));
        }
        else
        {
            try
            {
                Debug.Log("Soy el " + path + " y estoy siendo creado");
                Directory.CreateDirectory(Path.GetDirectoryName(fullPath));
                using (FileStream stream = new FileStream(fullPath, FileMode.Create))
                {
                    using (StreamWriter writer = new StreamWriter(stream))
                    {
                        writer.Write(objetosDatos);
                    }
                }
            }
            catch (Exception e)
            {
                Debug.LogError("Error al intentar crear el archivo" + fullPath + "\n" + e);
            }
        }
    }
}
