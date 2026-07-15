using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class GameData
{

    public int ammoActual;

    public SerializableDictionary<string, bool> reliquiasCollected;

    public SerializableDictionary<string, bool> nivelesComplete;

    public SerializableDictionary<string, bool> missionsComplete;

    public SerializableDictionary<string, bool> tutorialesCollected;

    //Añadir el apartado de missiones
    public GameData()
    {

        this.ammoActual = 10;
        
        reliquiasCollected = new SerializableDictionary<string, bool>();

        nivelesComplete = new SerializableDictionary<string, bool>();

        missionsComplete = new SerializableDictionary<string, bool>();

        tutorialesCollected = new SerializableDictionary<string, bool>();
    }
}

[System.Serializable]
public class ItemDataLanguage
{
    public SerializableDictionary<string, IdiomasItems> itemsName;
    public ItemDataLanguage()
    {
        itemsName = new SerializableDictionary<string, IdiomasItems>();
    }
}
[System.Serializable]
public class IdiomasItems
{
    public string spanish;
    public string english;
}
[System.Serializable]
public class ListAllItemsLanguage
{
    [HideInInspector] public List<string> listaTodosObjetosEspañol;
    [HideInInspector] public List<string> listAllItemsEnglish;

    public List<ListaDataObjetosTodosIdiomas> listaDataObjetosTodosIdiomas;
}
[System.Serializable]
public class ListaDataObjetosTodosIdiomas
{
    public string idObjeto;
    public IdiomasItems nombresObjetosIdiomas;
}
[System.Serializable]
public class InfoTodasPantallasCargar
{
    public List<ListaPantallasCarga> infoTodasPantallasCarga;
}
[System.Serializable]
public class ListaPantallasCarga
{
    public string nombrePantallaCarga;
    [TextArea(1, 10)]
    public string textoPantallaCarga;
}
public class LanguageData
{
    public string language;
    public LanguageData()
    {
        this.language = "English";
    }
}

[System.Serializable]
public class NoEncryptedGameData
{
    [Header("Opciones de Sonido")]
    public float masterVolume;
    public float musicVolume;
    public float ambienceVolume;
    public float itemsVolume;
    public float enemyVolume;
    public float playerVolume;

    [Header("Idioma")]
    public string idioma;
    public NoEncryptedGameData()
    {
        //Volumen data
        this.masterVolume = 1;
        this.musicVolume = 1;
        this.ambienceVolume = 1;
        this.itemsVolume = 1;
        this.enemyVolume = 1;
        this.playerVolume = 1;

        this.idioma = "English";
    }
}
