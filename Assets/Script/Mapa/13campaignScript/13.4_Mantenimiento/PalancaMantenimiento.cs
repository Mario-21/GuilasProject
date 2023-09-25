using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class PalancaMantenimiento : MonoBehaviour
{
    public int indexMod;
    [Header("Palanca Mantenimiento On")]
    [SerializeField] Sprite palancaOn;
    [SerializeField] SpriteRenderer verdeButton;
    [SerializeField] Color verdeOn;
    [SerializeField] SpriteRenderer rojoButton;
    [SerializeField] Color rojoOff;
    [Header("SFX Palanca")]
    [SerializeField] EventReference leverMantenimiento; 

    SpriteRenderer palancaMaintenance;
    PlayerHere player;
    private void Start()
    {
        palancaMaintenance = GetComponent<SpriteRenderer>();
        player = GetComponent<PlayerHere>();
        if (StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion)
        {
            PalancaActive();
        }
    }
    void Update()
    {
        if (player.playerImHere)
        {
            if (Input.GetButtonDown("Action"))
            {
                AudioManager.instancia.PlayOneShot(leverMantenimiento);
                PalancaActive();
            }
        }
    }
    void PalancaActive()
    {
        //Cambiar el aspecto del sprite
        palancaMaintenance.sprite = palancaOn;
        //Cambiar los colores de los botones para encenderlo
        verdeButton.color = verdeOn;
        rojoButton.color = rojoOff;
        StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion = true;
        this.enabled = false;

    }
}
