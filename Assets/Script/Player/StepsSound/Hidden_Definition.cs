using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hidden_Definition : MonoBehaviour
{
    Stairs_Hidden hiddenPlayerControler;
    PlayerHere playerHere;
    public GameObject animEscondite;
    public enum Type_Hidden
    {
        Arbusto,
        Taquilla,
        Puerta,
        Caja,
        Basura,
        Container,
        Default
    }
    public Type_Hidden hiddenDefine; 
    private void Awake()
    {
        playerHere = GetComponent<PlayerHere>();
        hiddenPlayerControler = FindObjectOfType<Stairs_Hidden>();
    }
    void Update()
    {
        //Si el jugador se encuentra dentro de la zona
        if (playerHere.playerImHere)
        {
            //Si me escondo, sale la animacion
            if (hiddenPlayerControler.imHidden)
            {
                animEscondite.SetActive(true);
            }
            //Si salgo del escondite, la animacion se cancela
            else
            {
                animEscondite.SetActive(false);
            }
        }
        else
        {
            animEscondite.SetActive(false);
        }
    }
    void DefinitionHiddenSpot()
    {
        switch (hiddenDefine)
        {
            case Type_Hidden.Arbusto:
                hiddenPlayerControler.hiddenSound = FMODEvent.instancia.arbustoHidden;
                break;
            case Type_Hidden.Basura:
                hiddenPlayerControler.hiddenSound = FMODEvent.instancia.basuraHidden;
                break;
            case Type_Hidden.Caja:
                hiddenPlayerControler.hiddenSound = FMODEvent.instancia.cajaHidden;
                break;
            case Type_Hidden.Puerta:
                hiddenPlayerControler.hiddenSound = FMODEvent.instancia.puertaHidden;
                break;
            case Type_Hidden.Taquilla:
                hiddenPlayerControler.hiddenSound = FMODEvent.instancia.taquillaHidden;
                break;
            case Type_Hidden.Container:
                hiddenPlayerControler.hiddenSound = FMODEvent.instancia.containerHidden;
                break;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            DefinitionHiddenSpot();
        }
        
    }
}
