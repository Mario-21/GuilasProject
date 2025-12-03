using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class DoorGenerator : MonoBehaviour
{
    public int indexMod;
    [Header("Iconos Info")]
    public GameObject iconoZone;
    [SerializeField] SpriteRenderer iconeZoneSprite;
    [SerializeField] Sprite icon;
    [Header("Generator Info")]
    [SerializeField] SpriteRenderer luzGenerator;
    [Header("Door Info")]
    [SerializeField] SpriteRenderer luzDoor;
    [SerializeField] GameObject doorCerrada;
    [SerializeField] GameObject doorOpen;
    [SerializeField] BoxCollider2D colliderDoor;
    [SerializeField] BoxCollider2D triggerB8;
    [SerializeField] EventReference sonidoOpenDoor;

    PlayerHere player;

    bool onDoor;
    int reproduceAudio;
    bool iconSee;

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
            iconeZoneSprite.sprite = icon;
            iconoZone.SetActive(true);
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
            iconoZone.SetActive(false);
            this.enabled = false;
        }
    }
    void OpenDoorWithGenerator()
    {
        triggerB8.enabled = false;
        //On Light
        luzDoor.color = Color.green;
        luzGenerator.color = Color.green;
        //Open Door
        doorCerrada.SetActive(false);
        doorOpen.SetActive(true);
        colliderDoor.enabled = false;
        //Mod
        StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion = true;
    }
    void DoorGeneratorSound()
    {
        if(reproduceAudio < 1)
        {
            AudioManager.instancia.PlayOneShot(sonidoOpenDoor);
            reproduceAudio++;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            iconoZone.SetActive(false);
        }
    }
}
