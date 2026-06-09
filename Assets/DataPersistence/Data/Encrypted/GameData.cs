using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class GameData
{

    public int ammoActual;

    public SerializableDictionary<string, bool> reliquiasCollected;

    public SerializableDictionary<string, bool> nivelesComplete;

    public GameData()
    {
        this.ammoActual = 10;
        
        reliquiasCollected = new SerializableDictionary<string, bool>();

        nivelesComplete = new SerializableDictionary<string, bool>();

    }
}

[System.Serializable]
public class ItemDataLanguage
{
    public SerializableDictionary<string, string> spanishItemsName;
    public SerializableDictionary<string, string> englishItemsName;

    public SerializableDictionary<string, IdiomasItems> itemsName;

    public ItemDataLanguage()
    {
        spanishItemsName = new SerializableDictionary<string, string>();

        englishItemsName = new SerializableDictionary<string, string>();

        //List<IdiomasItems> idiomas = new List<IdiomasItems>();

        itemsName = new SerializableDictionary<string, IdiomasItems>();

        //itemsName["hello World"] = new List<string>(("hello world").Split(' '));
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
    public List<string> listaTodosObjetosEspañol;
    public List<string> listAllItemsEnglish;
}
[System.Serializable]
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
