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

    void Start()
    {
        player = GetComponent<PlayerHere>();
        if (StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion)
        {
            onDoor = true;
        }
    }

    void Update()
    {
        if (player.playerImHere)
        {
            if (Input.GetKeyDown(KeyCode.Z))
            {
                onDoor = true;
            }
        }
        OpenDoorWithGenerator();
    }

    void OpenDoorWithGenerator()
    {
        if (onDoor)
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
    }
}
