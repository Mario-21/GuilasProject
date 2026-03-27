using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMOD.Studio;
using FMODUnity;

public class AudioMenu : MonoBehaviour, IDataPersistenceNoCrypted
{
    public static AudioMenu instancia;

    [Header("Volumen")]
    [Range(0, 1)]
    public float masterVolume;
    [Range(0, 1)]
    public float musicVolume;
    [Range(0, 1)]
    public float ambienceVolume;
    [Range(0, 1)]
    public float sfxItems;
    [Range(0, 1)]
    public float sfxEnemy;
    [Range(0, 1)]
    public float sfxPlayer; 

    private Bus masterBus;
    private Bus musicBus;
    private Bus ambienceBus;
    private Bus sfxItemsBus;
    private Bus sfxEnemyBus;
    private Bus sfxPlayerBus;

    public void LoadDataNoCrypted(NoEncryptedGameData noEncryptedGameData)
    {
        this.masterVolume = noEncryptedGameData.masterVolume;
        this.musicVolume = noEncryptedGameData.musicVolume;
        this.ambienceVolume = noEncryptedGameData.ambienceVolume;
        this.sfxItems = noEncryptedGameData.itemsVolume;
        this.sfxEnemy = noEncryptedGameData.enemyVolume;
        this.sfxPlayer = noEncryptedGameData.playerVolume;
    }

    public void SavaDataNoCrypted(ref NoEncryptedGameData noEncryptedGameData)
    {
        noEncryptedGameData.masterVolume = this.masterVolume;
        noEncryptedGameData.musicVolume = this.musicVolume;
        noEncryptedGameData.ambienceVolume = this.ambienceVolume;
        noEncryptedGameData.itemsVolume = this.sfxItems;
        noEncryptedGameData.enemyVolume = this.sfxEnemy;
        noEncryptedGameData.playerVolume = this.sfxPlayer;
    }
    private void Start()
    {
    }
    private void Awake()
    {
        
        if (AudioMenu.instancia == null)
        {
            AudioMenu.instancia = this;
            //DonDestroyOnLoad hacia que en muchas ocasiones no funcionara la configuracion de audio al cambiar entre escenas
            //DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        /*
        if (instancia != null)
        {
            Debug.LogError("Se ha encontrado más de un Audio manager");
        }
        instancia = this;
        */
        masterBus = RuntimeManager.GetBus("bus:/");
        musicBus = RuntimeManager.GetBus("bus:/Music");
        ambienceBus = RuntimeManager.GetBus("bus:/Ambience");
        sfxItemsBus = RuntimeManager.GetBus("bus:/SFX");
        sfxEnemyBus = RuntimeManager.GetBus("bus:/Enemy_SFX");
        sfxPlayerBus = RuntimeManager.GetBus("bus:/Player_SFX");
    }
    private void Update()
    {
        masterBus.setVolume(masterVolume);
        musicBus.setVolume(musicVolume);
        ambienceBus.setVolume(ambienceVolume);
        sfxItemsBus.setVolume(sfxItems);
        sfxEnemyBus.setVolume(sfxEnemy);
        sfxPlayerBus.setVolume(sfxPlayer);
    }
}
