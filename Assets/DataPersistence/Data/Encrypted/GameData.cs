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
public class NoEncryptedGameData
{
    [Header("Opciones de Sonido")]
    public float masterVolume;
    public float musicVolume;
    public float ambienceVolume;
    public float itemsVolume;
    public float enemyVolume;
    public float playerVolume;

    public enum Idioma
    {
        Español,
        English,
        Aleman
    }
    [Header("Idioma")]
    public Idioma idioma;
    public NoEncryptedGameData()
    {
        //Volumen data
        this.masterVolume = 1;
        this.musicVolume = 1;
        this.ambienceVolume = 1;
        this.itemsVolume = 1;
        this.enemyVolume = 1;
        this.playerVolume = 1;

        idioma = Idioma.Aleman;
    }
}
