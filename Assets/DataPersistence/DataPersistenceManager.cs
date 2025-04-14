using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class DataPersistenceManager : MonoBehaviour
{
    [Header("File Storage Config")]
    //Solo faltaria colocarle un nombre
    [SerializeField] private string fileName;

    [SerializeField] private bool useEncryptionSave;
    [SerializeField] private bool useEncryptionLoad;


    public GameData gameData;
    private List<IDataPersistence> dataPersistencesObjects;
    private FileDataHandler dataHandler;
    public static DataPersistenceManager instance { get; private set; }

    [Header("File No Encrypt")]
    [SerializeField] private string fileNameNoEncrypt;

    public NoEncryptedGameData gamedataNoEncrypt;
    private List<IDataPersistenceNoCrypted> dataPersistencesObjectsNoCrypted;
    private FileDataHandlerNoEncrypt dataHandlerNoEncrypt;
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
        this.dataHandler = new FileDataHandler(Application.persistentDataPath, fileName,useEncryptionSave,useEncryptionLoad);
        this.dataPersistencesObjects = FindAllDataPersistenceObjects();
        LoadGame();
        //No Crypted Items
        this.dataHandlerNoEncrypt = new FileDataHandlerNoEncrypt(Application.persistentDataPath, fileNameNoEncrypt);
        this.dataPersistencesObjectsNoCrypted = FindAllDataPersistenceObjectsNoCrypted();
        LoadGameNoEncrypt();

    }
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
        }
        dataHandler.Save(this.gameData);
    }
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

    //NOTA: ESTO ES UNA MERA PRUEBA COMO EN EL TUTORIAL SEGUIDO.
    //POSTERIOR AL TUTORIAL ESTE VOID HABRÁ QUE QUITARLO DADO QUE YO NO QUIERO QUE AQUÍ ME GUARDE LOS DATOS, SINO A LA HORA DE PASARTE UN NIVEL
    void OnApplicationQuit()
    {
        //SaveGame();
        SaveGameNoEncrypt();
        
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
}
