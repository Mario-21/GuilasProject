using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System;
public class IdiomaGlobalManager : MonoBehaviour, IDataPersistenceNoCrypted
{
    public static IdiomaGlobalManager instanciaIdioma;

    public string idiomaActual;

    //Ruta de los Objetos idiomas
    public static string readFromFilePathEspañolCompleto;
    public static string readFromFilePathEspañol;
    public static string readFromFilePathInglesComplete;
    public static string readFromFilePathIngles;
    //Ruta de las Pantallas de Carga
    public static string rutaPantallaCargaSpanish;
    public static string rutaLoadScreenEnglish;
    [Header("Nombre Archivos Objetos Idiomas")]
    public string nombre_Archivo = "Lista_Objetos.txt";
    public string name_Archive = "List_Items.txt";
    //Ruta de los Tutoriales
    public string rutaTutorialSpanish;
    public string routeTutorialEnglish;
    private void Awake()
    {
        //instanciaIdioma = this;
        
        if (IdiomaGlobalManager.instanciaIdioma == null)
        {
            IdiomaGlobalManager.instanciaIdioma = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        RutasIdiomasObjetos();
        RutaIdiomaPantallaCarga();
        RutaIdiomaTutoriales();
    }
    public void LoadDataNoCrypted(NoEncryptedGameData noEncryptedGameData)
    {
        this.idiomaActual = noEncryptedGameData.idioma;
        Debug.Log("Idioma Establecido " + noEncryptedGameData.idioma);
    }
    public void SavaDataNoCrypted(ref NoEncryptedGameData noEncryptedGameData)
    {
        noEncryptedGameData.idioma = this.idiomaActual;
        Debug.Log("Idioma Guardado");
    }
    private void Update()
    {
        Debug.Log("Hola, esto IdiomaGlobalManager y has seleccionado el idioma " + idiomaActual);
    }
/*
    public static void EstablecerIdiomaStatic(string idiomaSeleccionado)
    {
        new AlmacenarIdiomas(idiomaSeleccionado);
    }
*/
    void RutasIdiomasObjetos()
    {
        readFromFilePathEspañolCompleto = Application.dataPath + "/Idiomas/Español/Objetos/Lista_Objetos.txt";
        readFromFilePathEspañol = Application.dataPath + "/Idiomas/Español/Objetos/";
        readFromFilePathInglesComplete = Application.dataPath + "/Idiomas/Ingles/Items/List_Items.txt";
        readFromFilePathIngles = Application.dataPath + "/Idiomas/Ingles/Items/";
    }
    void RutaIdiomaPantallaCarga()
    {
        rutaPantallaCargaSpanish = Application.dataPath + "/Idiomas/Español/Pantalla_Carga/";
        rutaLoadScreenEnglish = Application.dataPath + "/Idiomas/Ingles/LoadScreen/";
    }
    void RutaIdiomaTutoriales()
    {
        rutaTutorialSpanish = Application.dataPath + "/Idiomas/Español/Tutoriales/";
        routeTutorialEnglish = Application.dataPath + "/Idiomas/Ingles/Tutorials/";
    }

    public void SelectorTextoIdioma(ref string idiomaGuardado, Text textItems, string spanishContent, string englishContent)
    {
        if (idiomaActual != idiomaGuardado) 
        {
            switch (idiomaActual)
            {
                case "Español":
                    textItems.text = spanishContent;
                    idiomaGuardado = idiomaActual;
                    break;
                case "English":
                    textItems.text = englishContent;
                    idiomaGuardado = idiomaActual;
                    break;
            }

        }
    }
    public void SelectorTextoIdiomaConstante(Text textItems, string spanishContent, string englishContent)
    {
        switch (idiomaActual)
        {
            case "Español":
                textItems.text = spanishContent;
                break;
            case "English":
                textItems.text = englishContent;
                break;
        }
    }

    public void EstablecerTextosIdiomas(SerializableDictionary<string, SerializableDictionary<string, string>> interfaceData, string id, Text texto, ref string idiomaGuardado)
    {
        if(idiomaActual != idiomaGuardado)
        {
            if (interfaceData.TryGetValue(idiomaActual, out SerializableDictionary<string, string> secondDictionary))
            {
                if (secondDictionary.TryGetValue(id, out string resultadoTraducido))
                {
                    texto.text = resultadoTraducido;
                    idiomaGuardado = idiomaActual;
                }
            }
        }
    }
    /*
    public class AlmacenarIdiomas 
    {
        public string idiomaActual;
        
        public AlmacenarIdiomas(string idiomaSeleccionado)
        {
            this.idiomaActual = idiomaSeleccionado;
            Debug.Log("Hola, esto IdiomaGlobalManager y has seleccionado el idioma " + idiomaActual);
        }
    }*/
}
