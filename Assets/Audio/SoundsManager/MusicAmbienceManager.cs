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

    List<EventInstance> ambiencesInstances;

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
        ambiencesInstances = new List<EventInstance>();
        InitializeMusic(musicStart);
        InitializeAmbience(ambienceStart);
        SetearAmbience(ambiente);
    }
    public EventInstance CreateEventAmbienceInstance(EventReference eventReference)
    {
        EventInstance eventInstance = RuntimeManager.CreateInstance(eventReference);
        ambiencesInstances.Add(eventInstance);
        return eventInstance;
    }
    void InitializeAmbience(EventReference ambientEventReference)
    {
        //ambienceInstance = AudioManager.instancia.CreateEventInstance(ambientEventReference);
        ambienceInstance = CreateEventAmbienceInstance(ambientEventReference);
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
        //musicInstance = AudioManager.instancia.CreateEventInstance(musicEventReference);
        musicInstance = CreateEventAmbienceInstance(musicEventReference);
        musicInstance.start();
    }
    public void SetMusicArea(MusicArea area)
    {
        musicInstance.setParameterByName("area", (float)area);
    }
    public void CleanAmbienceMusic()
    {
        foreach (EventInstance eventInstance in ambiencesInstances)
        {
            //Para el audio
            eventInstance.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
            //Cuando lo para, lo destruye
            eventInstance.release();
        }
    }
}
