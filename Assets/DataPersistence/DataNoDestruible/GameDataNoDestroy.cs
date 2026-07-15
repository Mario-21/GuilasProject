using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System.IO;
public class GameDataNoDestroy : MonoBehaviour
{
    [Header("File Storage Config")]
    //Solo faltaria colocarle un nombre
    [SerializeField] private string fileName;

    [SerializeField] private bool useEncryptionSave;
    [SerializeField] private bool useEncryptionLoad;
    [SerializeField] private bool guardarGameData;


    public GameData gameData;
    private List<IDataPersistence> dataPersistencesObjects;
    private FileDataHandler dataHandler;
    public static GameDataNoDestroy instance { get; private set; }
    // Start is called before the first frame update


    private void Awake()
    {
        if (GameDataNoDestroy.instance == null)
        {
            GameDataNoDestroy.instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        this.dataHandler = new FileDataHandler(Application.persistentDataPath, fileName, useEncryptionSave, useEncryptionLoad);
        this.dataPersistencesObjects = FindAllDataPersistenceObjects();
        LoadGame();
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
        if (this.gameData == null)
        {
            Debug.Log("no hay archivos. Creando unos nuevos predeterminados");
            NewGame();
        }
        //Cargar todos los archivos necesarios 
        foreach (IDataPersistence dataPersistenceObj in dataPersistencesObjects)
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
    public void CambiarGuardadoReliquia(int indexReliquia, bool reliquiaObtenido)
    {
        if (gameData.reliquiasCollected.ContainsKey(ListaReliquias.instancia.listaReliquiasTotal[indexReliquia].idReliquia))
        {
            gameData.reliquiasCollected.Remove(ListaReliquias.instancia.listaReliquiasTotal[indexReliquia].idReliquia);
            //GameDataNoDestroy.instance.gameData.nivelesComplete.Add(idReliquia, reliquiaRecogida);
        }
        gameData.reliquiasCollected.Add(ListaReliquias.instancia.listaReliquiasTotal[indexReliquia].idReliquia, reliquiaObtenido);
    }
    private void OnApplicationQuit()
    {
        if(guardarGameData)SaveGame();
    }
    //No va a funcionar, porque no los va a buscar inicialmente, necesitas que esto busque constantemente los scripts con los que se asocia la carga
    private List<IDataPersistence> FindAllDataPersistenceObjects()
    {
        IEnumerable<IDataPersistence> dataPersistencesObjects = FindObjectsOfType<MonoBehaviour>().OfType<IDataPersistence>();
        return new List<IDataPersistence>(dataPersistencesObjects);
    }

}
