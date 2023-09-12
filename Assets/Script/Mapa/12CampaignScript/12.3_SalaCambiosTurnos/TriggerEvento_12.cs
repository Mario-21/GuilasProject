using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using FMOD.Studio;

public class TriggerEvento_12 : MonoBehaviour
{
    public int indexMod;
    public enum evento_12
    {
        Explosion,
        Overcharge,
        TanqueAgua
    }
    public evento_12 myEvent;
    [Header("Explosion Info")]
    public CinemachineVirtualCamera mainCamera;
    public float shakeForce;
    float durationShake;
    public float durationShakeLimit;
    [Header("Overcharge Info")]
    public GameObject luz;
    float timeBlink;
    public float timeBlinkLimit;
    int countBlink;
    public int countBlinkLimit;
    [Header("TanqueAgua Info")]
    public GameObject gotas;

    PlayerHere player;
    bool eventOn;

    EventInstance Sfx_event;
    int soundOnce;
    private void Awake()
    {
        player = GetComponent<PlayerHere>();
    }
    void Start()
    {
        if (StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion)
        {
            this.enabled = false; 
        }
        switch (myEvent)
        {
            case evento_12.Explosion:
                Sfx_event = AudioManager.instancia.CreateEventInstance(FMODEvent.instancia.explosion);
                break;
        }
    }
    void Update()
    {
        if (player.playerImHere) 
        {
            if (Input.GetButtonDown("Action"))
            {
                eventOn = true;
            }
        }
        if (eventOn)
        {
            SelectEvento();
        }
    }
    void SelectEvento()
    {
        StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion = true;
        //Selecciona de manera manual que evento quieres
        switch (myEvent)
        {
            case evento_12.Explosion:
                Explosion explosion = new Explosion();
                explosion.ShakeExplosion(mainCamera, ref shakeForce, ref durationShake, durationShakeLimit);
                if(soundOnce < 1)
                {
                    Sfx_event.start();
                    soundOnce++;
                }
                if(shakeForce <= 0)
                {
                    Sfx_event.stop(STOP_MODE.ALLOWFADEOUT);
                    shakeForce = 0;
                    this.enabled = false;
                }
                break;
            case evento_12.Overcharge:
                Overcharge overcharge = new Overcharge();
                overcharge.BlinkLight(luz, ref timeBlink, timeBlinkLimit, ref countBlink, countBlinkLimit);
                if(soundOnce < 1)
                {
                    AudioManager.instancia.PlayOneShot(FMODEvent.instancia.failLight);
                    soundOnce++;
                }
                if(countBlink >= countBlinkLimit)
                {
                    this.enabled = false;
                }
                break;
            case evento_12.TanqueAgua:
                TanqueAgua waterTank = new TanqueAgua();
                waterTank.WaterBreakTank(gotas);
                this.enabled = false;
                break;
        }
    }
}
