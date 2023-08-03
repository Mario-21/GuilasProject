using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;
using FMOD.Studio;

public class AudioManager : MonoBehaviour
{

    List<EventInstance> eventInstances;

    List<StudioEventEmitter> eventEmitters;

    private EventInstance ambienceEventInstance;

    private EventInstance musicEventInstance;

    public static AudioManager instancia;
    private void Awake()
    {
        if(AudioManager.instancia == null)
        {
            AudioManager.instancia = this;
        }
        else
        {
            Destroy(gameObject);
            Debug.Log("Hay más de un audio");
        }

        eventInstances = new List<EventInstance>();
        eventEmitters = new List<StudioEventEmitter>();
    }
    private void Start()
    {
        //StartAudios();
    }
    private void Update()
    {

    }



    private void InitializeAmbience(EventReference ambientEventReference)
    {
        ambienceEventInstance = CreateEventInstance(ambientEventReference);
        ambienceEventInstance.start();
    }
    private void InitializeMusic(EventReference musicEventReference)
    {
        musicEventInstance = CreateEventInstance(musicEventReference);
        musicEventInstance.start();
    }
    public void ReanudaMusicAmbience()
    {
        foreach (EventInstance eventInstance in eventInstances)
        {
            //Para el audio
            eventInstance.setPaused(PauseMenu.pause);
            Debug.Log("Audios Continue");
        }
        foreach (StudioEventEmitter eventEmitter in eventEmitters)
        {
            eventEmitter.EventInstance.setPaused(PauseMenu.pause);
        }
    }
    public void SetAmbienceParameter(string parameterName, float parameterValue)
    {
        ambienceEventInstance.setParameterByName(parameterName,parameterValue);
    }
    public void SetAmbienceArea(AmbienceArea area)
    {
        ambienceEventInstance.setParameterByName("areaAmbience", (float)area);
    }
    public void AmbienceStopNew(AmbienceArea areaAmbiente)
    {
        Debug.Log("Ambience parado");
        //Para el sonido de ambiente para evitar que se acumule los audios nuevos
        PLAYBACK_STATE playbackState;
        ambienceEventInstance.getPlaybackState(out playbackState);
        ambienceEventInstance.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        //Initialize el ambiente una vez para que no se acumule
        InitializeAmbience(FMODEvent.instancia.wind);
        //Vuelve a setear el ambiente con el nuevo area
        SetAmbienceArea(areaAmbiente);

        /*
         * Si a continuado haz esto
       if (!playbackState.Equals(PLAYBACK_STATE.STOPPED))
       {
           Debug.Log("Se me paro wey");
       }
       */
    }
    public void SetMusicArea(MusicArea area)
    {
        musicEventInstance.setParameterByName("area", (float) area);
    }
    public void PlayOneShot(EventReference sound)
    {
        RuntimeManager.PlayOneShot(sound);
    }
    public EventInstance CreateEventInstance(EventReference eventReference)
    {
        EventInstance eventInstance = RuntimeManager.CreateInstance(eventReference);
        eventInstances.Add(eventInstance);
        return eventInstance;
    }
    public StudioEventEmitter InitializeEventEmitter (EventReference eventReference, GameObject emitterGameObject)
    {
        StudioEventEmitter eventEmitter = emitterGameObject.GetComponent<StudioEventEmitter>();
        eventEmitter.EventReference = eventReference;
        eventEmitters.Add(eventEmitter);
        return eventEmitter;
    }
    public void StopAudios()
    {
        /*
        foreach (EventInstance eventInstance in eventInstances)
        {
            //Para el audio
            eventInstance.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
            Debug.Log("Audios Pausados");
        }
        foreach (StudioEventEmitter eventEmitter in eventEmitters)
        {
            eventEmitter.Stop();
        }
        */
        
        foreach (EventInstance eventInstance in eventInstances)
        {
            //Para el audio
            eventInstance.setPaused(PauseMenu.pause);

            Debug.Log("Audios Pausados");
        }
        foreach (StudioEventEmitter eventEmitter in eventEmitters)
        {
            eventEmitter.EventInstance.setPaused(PauseMenu.pause);
        }
        
    }
    public void StartAudios()
    {
        //Crea la instancia para reproducir el sonido de ambiente
        InitializeAmbience(FMODEvent.instancia.wind);
        //Si a cambiado el ambiente con respecto al inicial lo seteara
        SetAmbienceArea(AmbienceActual.ambienceNow);
        InitializeMusic(FMODEvent.instancia.music);
    }
    public void CleanUp()
    {
        foreach(EventInstance eventInstance in eventInstances)
        {
            //Para el audio
            eventInstance.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
            //Cuando lo para, lo destruye
            eventInstance.release();
        }
        foreach(StudioEventEmitter eventEmitter in eventEmitters)
        {
            eventEmitter.Stop();
        }
    }
    private void OnDestroy()
    {
        CleanUp();
    }
}
