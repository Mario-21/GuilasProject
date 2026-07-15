using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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
    private void Start()
    {
        //FileDataHandler.DesencriptaObjetos(readFromFilePathEspañol, nombre_Archivo, DataPersistenceManager.instance.listItemLanguage.listaTodosObjetosEspañol);
        DesencriptaObjetos(readFromFilePathIngles, name_Archive, DataPersistenceManager.instance.listItemLanguage.listAllItemsEnglish);
        DesencriptaObjetos(readFromFilePathEspañol,nombre_Archivo, DataPersistenceManager.instance.listItemLanguage.listaTodosObjetosEspañol);

        //FileDataHandler.DesencriptaObjetos(readFromFilePathIngles, name_Archive, DataPersistenceManager.instance.listItemLanguage.listAllItemsEnglish);
    }
    private void Update()
    {
        Debug.Log("Hola, esto IdiomaGlobalManager y has seleccionado el idioma " + idiomaActual);
        
    }

    public static void EstablecerIdiomaStatic(string idiomaSeleccionado)
    {
        new AlmacenarIdiomas(idiomaSeleccionado);
    }
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


    void DesencriptaObjetos(string path, string nameArchivo, List<string> listObjetos)
    {
        string fullPath = Path.Combine(path, nameArchivo);

        if (File.Exists(fullPath))
        {
            Debug.Log("Existo,por tanto, no tengo que hacer nada");
            File.WriteAllText(fullPath, FileDataHandler.EncryptDecrypt(File.ReadAllText(fullPath)));
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
                        for (int e = 0; e < listObjetos.Count; e++)
                        {
                            writer.WriteLine(listObjetos[e]);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Debug.LogError("Error al intentar crear el archivo" + fullPath + "\n" + e);
            }
        }
    }

    private void OnApplicationQuit()
    {
        DesencriptaObjetos(readFromFilePathIngles, name_Archive, DataPersistenceManager.instance.listItemLanguage.listAllItemsEnglish);
        DesencriptaObjetos(readFromFilePathEspañol, nombre_Archivo, DataPersistenceManager.instance.listItemLanguage.listaTodosObjetosEspañol);
    }
    public class AlmacenarIdiomas 
    {
        public string idiomaActual;
        
        public AlmacenarIdiomas(string idiomaSeleccionado)
        {
            this.idiomaActual = idiomaSeleccionado;
            Debug.Log("Hola, esto IdiomaGlobalManager y has seleccionado el idioma " + idiomaActual);
        }
    }
}
