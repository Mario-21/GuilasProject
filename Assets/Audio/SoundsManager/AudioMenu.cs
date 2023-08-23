using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMOD.Studio;
using FMODUnity;

public class AudioMenu : MonoBehaviour
{
    public static AudioMenu instancia;

    [Header("Volumen")]
    [Range(0, 1)]
    public float masterVolume = 1;
    [Range(0, 1)]
    public float musicVolume = 1;
    [Range(0, 1)]
    public float ambienceVolume = 1;
    [Range(0, 1)]
    public float sfxItems = 1;
    [Range(0, 1)]
    public float sfxEnemy = 1;
    [Range(0, 1)]
    public float sfxPlayer = 1;



    private Bus masterBus;
    private Bus musicBus;
    private Bus ambienceBus;
    private Bus sfxItemsBus;
    private Bus sfxEnemyBus;
    private Bus sfxPlayerBus;
    private void Awake()
    {
        if (AudioMenu.instancia == null)
        {
            AudioMenu.instancia = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
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
