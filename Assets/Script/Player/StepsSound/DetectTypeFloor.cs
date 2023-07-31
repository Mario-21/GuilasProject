using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class DetectTypeFloor : MonoBehaviour
{
    public JugadorMovimiento playerControl;

    public EventReference actualStepsSound;

    public enum TypeFloor
    {
        Sand,
        Forest,
        Metal,
        Concrete,
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
                }
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

        }
        

    }
}
