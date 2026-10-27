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
    [SerializeField] EventReference button_On;
    [SerializeField] EventReference compuertasOpen;
    SpriteRenderer buttonSprite;
    PlayerHere player;
    [Header("Datos Resetear Zona")]
    [SerializeField] BloquearMovimientoPlayer bloqPlayer;
    [SerializeField] int spawnPanelMadre;
    [SerializeField] int escenaGeneradorMadre;
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
            this.enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (player.playerImHere)
        {
            if (Input.GetButtonDown("Action"))
            {
                AudioManager.instancia.PlayOneShot(button_On);
                StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion = true;
                OnMotherButton();
            }
        }
        if (StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion)
        {
            AudioManager.instancia.PlayOneShot(compuertasOpen);
            //Parar el Movimiento del Player
            bloqPlayer.BloquearMovPlayer();
            //Cambiar Zona
            CheckPointController.numeroCheckPoint = spawnPanelMadre;
            EstructuraNiveles.nivel = escenaGeneradorMadre;
            AnimationHud.detectar_echar.SetTrigger("Detectar_Echar");
        }
    }
    
    void OnMotherButton()
    {
        buttonSprite.color = colorOn;
        this.enabled = false;
    }
}
