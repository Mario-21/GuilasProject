using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class DetectTypeFloor : MonoBehaviour
{
    public JugadorMovimiento playerControl;
    [Header("Player_Steps")]
    public EventReference actualStepsSound;
    public enum TypeFloor
    {
        Sand,
        Forest,
        Metal,
        Concrete,
        Wood,
        Cave,
        Wet,
        Water,
        Mud,
        Rama,
        Default
    }
    public TypeFloor actualFloor;
    public TypeFloor floorNow;



    //EVent REference que vaya cambiando dependiendo del suelo Event REference = FmodEvent.intancia.x
    private void Awake()
    {
        playerControl = GetComponentInParent<JugadorMovimiento>();
    }
    void Start()
    {
        floorNow = TypeFloor.Default;
    }

    // Update is called once per frame
    void Update()
    {
        DefinitionFloor();
        ChangeSteps();
    }
    void DefinitionFloor()
    {
        switch (actualFloor)
        {
            case TypeFloor.Sand:
                actualStepsSound = FMODEvent.instancia.sandSteps;
                break;
            case TypeFloor.Forest:
                actualStepsSound = FMODEvent.instancia.grassSteps;
                break;
            case TypeFloor.Concrete:
                actualStepsSound = FMODEvent.instancia.concreteSteps;
                break;
            case TypeFloor.Metal:
                actualStepsSound = FMODEvent.instancia.metalSteps;
                break;
            case TypeFloor.Wood:
                actualStepsSound = FMODEvent.instancia.woodSteps;
                break;
            case TypeFloor.Cave:
                actualStepsSound = FMODEvent.instancia.caveSteps;
                break;
            case TypeFloor.Wet:
                actualStepsSound = FMODEvent.instancia.wetSteps;
                break;
            case TypeFloor.Mud:
                actualStepsSound = FMODEvent.instancia.mudSteps;
                break;
            case TypeFloor.Water:
                actualStepsSound = FMODEvent.instancia.swimSteps;
                break;
            case TypeFloor.Rama:
                actualStepsSound = FMODEvent.instancia.ramaSteps;
                break;
        }
    }
    void ChangeSteps()
    {
        if (playerControl.onGround)
        {
            if (floorNow != actualFloor)
            {
                switch (actualFloor)
                {
                    case TypeFloor.Sand:
                        playerControl.playerStepsGrass.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
                        playerControl.playerStepsGrass.release();
                        playerControl.playerStepsGrass = AudioManager.instancia.CreateEventInstance(FMODEvent.instancia.sandSteps);
                        floorNow = TypeFloor.Sand;
                        break;
                    case TypeFloor.Forest:
                        playerControl.playerStepsGrass.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
                        playerControl.playerStepsGrass.release();
                        playerControl.playerStepsGrass = AudioManager.instancia.CreateEventInstance(FMODEvent.instancia.grassSteps);
                        floorNow = TypeFloor.Forest;
                        break;
                    case TypeFloor.Concrete:
                        playerControl.playerStepsGrass.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
                        playerControl.playerStepsGrass.release();
                        playerControl.playerStepsGrass = AudioManager.instancia.CreateEventInstance(FMODEvent.instancia.concreteSteps);
                        floorNow = TypeFloor.Concrete;
                        break;
                    case TypeFloor.Metal:
                        playerControl.playerStepsGrass.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
                        playerControl.playerStepsGrass.release();
                        playerControl.playerStepsGrass = AudioManager.instancia.CreateEventInstance(FMODEvent.instancia.metalSteps);
                        floorNow = TypeFloor.Metal;
                        break;
                    case TypeFloor.Wood:
                        playerControl.playerStepsGrass.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
                        playerControl.playerStepsGrass.release();
                        playerControl.playerStepsGrass = AudioManager.instancia.CreateEventInstance(FMODEvent.instancia.woodSteps);
                        floorNow = TypeFloor.Wood;
                        break;
                    case TypeFloor.Cave:
                        playerControl.playerStepsGrass.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
                        playerControl.playerStepsGrass.release();
                        playerControl.playerStepsGrass = AudioManager.instancia.CreateEventInstance(FMODEvent.instancia.caveSteps);
                        floorNow = TypeFloor.Cave;
                        break;
                    case TypeFloor.Mud:
                        playerControl.playerStepsGrass.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
                        playerControl.playerStepsGrass.release();
                        playerControl.playerStepsGrass = AudioManager.instancia.CreateEventInstance(FMODEvent.instancia.mudSteps);
                        floorNow = TypeFloor.Mud;
                        break;
                    case TypeFloor.Wet:
                        playerControl.playerStepsGrass.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
                        playerControl.playerStepsGrass.release();
                        playerControl.playerStepsGrass = AudioManager.instancia.CreateEventInstance(FMODEvent.instancia.wetSteps);
                        floorNow = TypeFloor.Wet;
                        break;
                    case TypeFloor.Rama:
                        playerControl.playerStepsGrass.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
                        playerControl.playerStepsGrass.release();
                        playerControl.playerStepsGrass = AudioManager.instancia.CreateEventInstance(FMODEvent.instancia.ramaSteps);
                        floorNow = TypeFloor.Rama;
                        break;
                }
            }
        }
        if (playerControl.onWater)
        {
            if (floorNow != actualFloor)
            {
                playerControl.playerStepsGrass.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
                playerControl.playerStepsGrass.release();
                playerControl.playerStepsGrass = AudioManager.instancia.CreateEventInstance(FMODEvent.instancia.swimSteps);
                floorNow = TypeFloor.Water;
            }
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        
        if (playerControl.onGround)
        {
            if (collision.gameObject.CompareTag("Sand"))
            {
                Debug.Log("Sand");
                actualFloor = TypeFloor.Sand;
            }
            else if (collision.gameObject.CompareTag("Concrete"))
            {
                Debug.Log("Concrete");
                actualFloor = TypeFloor.Concrete;
            }
            else if (collision.gameObject.CompareTag("Forest"))
            {
                Debug.Log("Forest");
                actualFloor = TypeFloor.Forest;
            }
            else if (collision.gameObject.CompareTag("Metal"))
            {
                Debug.Log("Metal");
                actualFloor = TypeFloor.Metal;
            }
            else if (collision.gameObject.CompareTag("Wood"))
            {
                Debug.Log("Wood");
                actualFloor = TypeFloor.Wood;
            }
            else if (collision.gameObject.CompareTag("Cave"))
            {
                Debug.Log("Cave");
                actualFloor = TypeFloor.Cave;
            }
            else if (collision.gameObject.CompareTag("Wet"))
            {
                Debug.Log("Wet");
                actualFloor = TypeFloor.Wet;
            }
            else if (collision.gameObject.CompareTag("Mud"))
            {
                Debug.Log("Mud");
                actualFloor = TypeFloor.Mud;
            }
            else if (collision.gameObject.CompareTag("Rama"))
            {
                Debug.Log("Rama");
                actualFloor = TypeFloor.Rama;
            }

        }
        if (playerControl.onWater)
        {
            if (collision.gameObject.CompareTag("Water"))
            {
                Debug.Log("Water");
                actualFloor = TypeFloor.Water;
            }
        }
        

    }
}
