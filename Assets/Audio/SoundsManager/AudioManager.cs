using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;
using FMOD.Studio;

public class AudioManager : MonoBehaviour
{

    List<EventInstance> eventInstances;

    List<StudioEventEmitter> eventEmitters;

    private EventInstance musicEventInstance;

    public static AudioManager instancia;

    int numEmissor;
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

    private void Update()
    {
        //Debug.Log("Instance " + eventInstances.Count);
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
    public void PauseAudios()
    {
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
    public void CleanUp()
    {
        CleanUpInstances();
        CleanUpEmitters();
    }
    public void CleanUpInstances()
    {
        foreach (EventInstance eventInstance in eventInstances)
        {
            //Para el audio
            eventInstance.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
            //Cuando lo para, lo destruye
            eventInstance.release();
        }
    }
    public void CleanUpEmitters()
    {
        foreach (StudioEventEmitter eventEmitter in eventEmitters)
        {
            eventEmitter.Stop();
        }
    }
    private void OnDestroy()
    {
        CleanUpEmitters();
    }
}
