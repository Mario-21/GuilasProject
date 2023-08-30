using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorGenerator : MonoBehaviour
{
    public int indexMod;
    [Header("Generator Info")]
    [SerializeField] SpriteRenderer luzGenerator;
    [Header("Door Info")]
    [SerializeField] SpriteRenderer luzDoor;
    [SerializeField] SpriteRenderer door;
    [SerializeField] Sprite doorOpen;
    [SerializeField] BoxCollider2D colliderDoor;
    [SerializeField] BoxCollider2D triggerB8;

    PlayerHere player;

    bool onDoor;
    int reproduceAudio;

    void Start()
    {
        player = GetComponent<PlayerHere>();
        if (StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion)
        {
            OpenDoorWithGenerator();
            this.enabled = false;
        }
    }

    void Update()
    {
        if (player.playerImHere)
        {
            if (Input.GetButtonDown("Action"))
            {
                AudioManager.instancia.PlayOneShot(FMODEvent.instancia.botonGeneral);
                onDoor = true;
            }
        }
        if (onDoor)
        {
            OpenDoorWithGenerator();
            DoorGeneratorSound();
        }
    }
    void OpenDoorWithGenerator()
    {
        triggerB8.enabled = false;
        //On Light
        luzDoor.color = Color.green;
        luzGenerator.color = Color.green;
        //Open Door
        door.sprite = doorOpen;
        colliderDoor.enabled = false;
        //Mod
        StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion = true;
    }
    void DoorGeneratorSound()
    {
        if(reproduceAudio < 1)
        {
            AudioManager.instancia.PlayOneShot(FMODEvent.instancia.puertaHidden);
            reproduceAudio++;
        }
    }
}
