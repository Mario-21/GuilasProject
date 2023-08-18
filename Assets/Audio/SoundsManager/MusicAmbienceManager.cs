using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;
using FMOD.Studio;

public class MusicAmbienceManager : MonoBehaviour
{
    public static MusicAmbienceManager instance;
    [Header("Music Start")]
    [SerializeField] EventReference musicStart;
    public EventInstance musicInstance;
    [Header("Ambience Start")]
    [SerializeField] EventReference ambienceStart;
    public EventInstance ambienceInstance;
    public AmbienceArea ambiente;

    private void Awake()
    {
        if (MusicAmbienceManager.instance == null)
        {
            MusicAmbienceManager.instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        InitializeMusic(musicStart);
        InitializeAmbience(ambienceStart);
        SetearAmbience(ambiente);
    }
    void InitializeAmbience(EventReference ambientEventReference)
    {
        ambienceInstance = AudioManager.instancia.CreateEventInstance(ambientEventReference);
        ambienceInstance.start();
    }
    public void ChangeAmbienceManager(AmbienceArea areaSetAmbience)
    {
        PLAYBACK_STATE playbackState;
        ambienceInstance.getPlaybackState(out playbackState);
        ambienceInstance.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        ambienceInstance.release();

        InitializeAmbience(ambienceStart);

        SetearAmbience(areaSetAmbience);
    }
    public void SetearAmbience(AmbienceArea area)
    {
        ambienceInstance.setParameterByName("areaAmbience", (float)area);
        AmbienceActual.ambienceNow = area;
    }
    public void SetAmbienceParameterValue(string parameterName, float parameterValue)
    {
        ambienceInstance.setParameterByName(parameterName, parameterValue);
    }
    void InitializeMusic(EventReference musicEventReference)
    {
        musicInstance = AudioManager.instancia.CreateEventInstance(musicEventReference);
        musicInstance.start();
    }
    public void SetMusicArea(MusicArea area)
    {
        musicInstance.setParameterByName("area", (float)area);
    }

}
