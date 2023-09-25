using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

[RequireComponent(typeof(PlayerHere))]
public class ButtonMadre : MonoBehaviour
{
    public int indexMod;
    [Header("Color Encendido")]
    [SerializeField] Color colorOn;
    [Header("SFX Encendido")]
    [SerializeField] EventReference sfx_On;
    SpriteRenderer buttonSprite;
    PlayerHere player;
    private void Awake()
    {
        buttonSprite = GetComponent<SpriteRenderer>();
        player = GetComponent<PlayerHere>();
    }
    void Start()
    {
        if (StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion)
        {
            OnMotherButton();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (player.playerImHere)
        {
            if (Input.GetButtonDown("Action"))
            {
                AudioManager.instancia.PlayOneShot(sfx_On);
                StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion = true;
                OnMotherButton();
            }
        }
    }
    
    void OnMotherButton()
    {
        buttonSprite.color = colorOn;
        this.enabled = false;
    }
}
