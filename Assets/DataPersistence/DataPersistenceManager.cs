using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System.IO;
public class DataPersistenceManager : MonoBehaviour
{
    [Header("File Storage Config")]
    //Solo faltaria colocarle un nombre
    //[SerializeField] private string fileName;

    [SerializeField] private bool useEncryptionSave;
    [SerializeField] private bool useEncryptionLoad;
    //[SerializeField] private bool guardarGameData;

    //public GameData gameData;
    //private List<IDataPersistence> dataPersistencesObjects;
    //private FileDataHandler dataHandler;
    public static DataPersistenceManager instance { get; private set; }
    [Header("File Item Game")]
    public ListAllItemsLanguage listItemLanguage;
    [Header("File LoadScreen")]
    public InfoTodasPantallasCargar InfoTodasPantallasCagar;
    [Header("File No Encrypt")]
    [SerializeField] private string fileNameNoEncrypt;

    public NoEncryptedGameData gamedataNoEncrypt;
    private List<IDataPersistenceNoCrypted> dataPersistencesObjectsNoCrypted;
    private FileDataHandlerNoEncrypt dataHandlerNoEncrypt;
    [Header("File Language")]
    [SerializeField] private string fileNameLanguage;

    public LanguageData languageData;
    private List<IDataLanguage> languageDatas;
    private FileDataHandlerNoEncrypt dataHandlerLanguage;
    [Header("Dictionary Item Language")]
    [SerializeField] private string fileDictionaryItem;



    public ItemDataLanguage itemDataLanguage;
    private List<IDataItemName> dataPersistenceObjectsName;
    private FileDataHandler dataHandlerItemName;
    void Awake()
    {
        
        if(instance != null)
        {
            Debug.LogError("Se ha encontrado más de Data Persistence Manager en escena");
            //Destroy(gameObject);
        }
        instance = this;
    }
    //NOTA: ESTO ES UNA MERA PRUEBA COMO EN EL TUTORIAL SEGUIDO.

    void Start()
    {
        //Crypted Items
        //this.dataHandler = new FileDataHandler(Application.persistentDataPath, fileName,useEncryptionSave,useEncryptionLoad);
        //this.dataPersistencesObjects = FindAllDataPersistenceObjects();
        //LoadGame();
        //No Crypted Items
        this.dataHandlerNoEncrypt = new FileDataHandlerNoEncrypt(Application.persistentDataPath, fileNameNoEncrypt);
        this.dataPersistencesObjectsNoCrypted = FindAllDataPersistenceObjectsNoCrypted();
        LoadGameNoEncrypt();
        //No Crypted Language 
        this.dataHandlerLanguage = new FileDataHandlerNoEncrypt(Application.persistentDataPath, fileNameLanguage);
        this.languageDatas = FindAllDataPersistanceObjectsLanguage();
        LoadLanguage();
        //Name Items Language
        string pathDataHandlerItemName = Application.dataPath + "/Idiomas/Aleman/";
        this.dataHandlerItemName = new FileDataHandler(pathDataHandlerItemName, fileDictionaryItem, useEncryptionSave, useEncryptionLoad);
        this.dataPersistenceObjectsName = FindAllDataPersistanceItemsName();
        LoadItemDataLanguage();
        

    }
    /*
    public void NewGame()
    {
        this.gameData = new GameData();
    }
    public void LoadGame()
    {
        //Carga el archivo de la respectiva carpeta data handler
        this.gameData = dataHandler.Load();
        //Si no hay datos crea unos nuevos
        if(this.gameData == null)
        {
            Debug.Log("no hay archivos. Creando unos nuevos predeterminados");
            NewGame();
        }
        //Cargar todos los archivos necesarios 
        foreach(IDataPersistence dataPersistenceObj in dataPersistencesObjects)
        {
            dataPersistenceObj.LoadData(gameData);
        }
    }
    public void SaveGame()
    {
        //Guarda los datos en una carpeta usando un data handler
        //Pasar los datos a otros script
        foreach (IDataPersistence dataPersistenceObj in dataPersistencesObjects)
        {
            dataPersistenceObj.SaveData(ref gameData);
            Debug.Log("Guardado con SaveData");
        }
        dataHandler.Save(this.gameData);
    }
    */
    public void NewGameNoEncrypt()
    {
        this.gamedataNoEncrypt = new NoEncryptedGameData();
    }
    public void LoadGameNoEncrypt()
    {
        //Carga el archivo de la respectiva carpeta data handler
        this.gamedataNoEncrypt = dataHandlerNoEncrypt.LoadNoEncrypt();
        //Si no hay datos crea unos nuevos
        if (this.gamedataNoEncrypt == null)
        {
            Debug.Log("no hay archivos. Creando unos nuevos predeterminados");
            NewGameNoEncrypt();
        }
        //Cargar todos los archivos necesarios 
        foreach (IDataPersistenceNoCrypted dataPersistenceObjNoEnc in dataPersistencesObjectsNoCrypted)
        {
            dataPersistenceObjNoEnc.LoadDataNoCrypted(gamedataNoEncrypt);
        }
    }
    public void SaveGameNoEncrypt()
    {
        //Guarda los datos en una carpeta usando un data handler
        //Pasar los datos a otros script
        
        foreach (IDataPersistenceNoCrypted dataPersistenceObjNoEnc in dataPersistencesObjectsNoCrypted)
        {
            dataPersistenceObjNoEnc.SavaDataNoCrypted(ref gamedataNoEncrypt);
        }
        dataHandlerNoEncrypt.SaveNoEncrypt(this.gamedataNoEncrypt);
    }

    public void NewLanguage()
    {
        this.languageData = new LanguageData();
    }
    public void LoadLanguage()
    {
        //Carga el archivo de la respectiva carpeta data handler
        this.languageData = dataHandlerLanguage.LoadLanguage();
        //Si no hay datos crea unos nuevos
        if (this.languageData == null)
        {
            Debug.Log("No hay archivos relacionado con el idioma. Creando unos nuevos predeterminados");
            NewLanguage();
        }
        //Cargar todos los archivos necesarios 
        foreach (IDataLanguage dataPersistenceObjNoEnc in languageDatas)
        {
            dataPersistenceObjNoEnc.LoadDataLanguage(languageData);
        }
        Debug.Log("Lenguaje Cargado");
    }
    public void SaveLanguage()
    {
        //Guarda los datos en una carpeta usando un data handler
        //Pasar los datos a otros script
        Debug.Log("Lenguaje Guardado");
        foreach (IDataLanguage dataPersistenceObjNoEnc in languageDatas)
        {
            dataPersistenceObjNoEnc.SaveDataLanguage(ref languageData);
        }
        dataHandlerLanguage.SaveLanguage(this.languageData);
    }

    public void NewItemDataLanguage()
    {
        this.itemDataLanguage = new ItemDataLanguage();
        EscribirTodoDictionary();
    }
    public void LoadItemDataLanguage()
    {
        //Carga el archivo de la respectiva carpeta data handler
        this.itemDataLanguage = dataHandlerItemName.LoadItem();
        //Si no hay datos crea unos nuevos
        if (this.itemDataLanguage == null)
        {
            Debug.Log("no hay archivos. Creando unos nuevos predeterminados");
            NewItemDataLanguage();
        }
        //Cargar todos los archivos necesarios 
        foreach (IDataItemName dataPersistenceObjName in dataPersistenceObjectsName)
        {
            dataPersistenceObjName.LoadDataItemName(itemDataLanguage);
        }
    }

    public void SaveItemDataLanguage()
    {
        //Guarda los datos en una carpeta usando un data handler
        //Pasar los datos a otros script
        foreach (IDataItemName dataPersistenceObj in dataPersistenceObjectsName)
        {
            dataPersistenceObj.SaveDataItemName(ref itemDataLanguage);
        }
        dataHandlerItemName.SaveItem(this.itemDataLanguage);
    }

    void EscribirTodoDictionary()
    {

        for (int i = 0; i < listItemLanguage.listaDataObjetosTodosIdiomas.Count; i++)
        {
            IdiomasItems idiomasListaObjetos = new IdiomasItems();
            idiomasListaObjetos.spanish = listItemLanguage.listaDataObjetosTodosIdiomas[i].nombresObjetosIdiomas.spanish;
            idiomasListaObjetos.english = listItemLanguage.listaDataObjetosTodosIdiomas[i].nombresObjetosIdiomas.english;

            string itemID = listItemLanguage.listaDataObjetosTodosIdiomas[i].idObjeto;

            itemDataLanguage.itemsName.Add(itemID, idiomasListaObjetos);
        }
    }

    //NOTA: ESTO ES UNA MERA PRUEBA COMO EN EL TUTORIAL SEGUIDO.
    //POSTERIOR AL TUTORIAL ESTE VOID HABRÁ QUE QUITARLO DADO QUE YO NO QUIERO QUE AQUÍ ME GUARDE LOS DATOS, SINO A LA HORA DE PASARTE UN NIVEL
    void OnApplicationQuit()
    {
        //if(guardarGameData)SaveGame();
        SaveGameNoEncrypt();
        SaveItemDataLanguage();
        //SaveLanguage();
        //Debug.Log("Biletito de Ten in to the pocket");

    }
    private List<IDataPersistence> FindAllDataPersistenceObjects()
    {
        IEnumerable<IDataPersistence> dataPersistencesObjects = FindObjectsOfType<MonoBehaviour>().OfType<IDataPersistence>();
        return new List<IDataPersistence>(dataPersistencesObjects);
    }
    private List<IDataPersistenceNoCrypted> FindAllDataPersistenceObjectsNoCrypted()
    {
        IEnumerable<IDataPersistenceNoCrypted> dataPersistencesObjects = FindObjectsOfType<MonoBehaviour>().OfType<IDataPersistenceNoCrypted>();
        return new List<IDataPersistenceNoCrypted>(dataPersistencesObjects);
    }
    private List<IDataLanguage> FindAllDataPersistanceObjectsLanguage()
    {
        IEnumerable<IDataLanguage> dataPersistencesObjects = FindObjectsOfType<MonoBehaviour>().OfType<IDataLanguage>();
        return new List<IDataLanguage>(dataPersistencesObjects);
    }
    private List<IDataItemName> FindAllDataPersistanceItemsName()
    {
        IEnumerable<IDataItemName> dataPersistencesObjects = FindObjectsOfType<MonoBehaviour>().OfType<IDataItemName>();
        return new List<IDataItemName>(dataPersistencesObjects);
    }
}
