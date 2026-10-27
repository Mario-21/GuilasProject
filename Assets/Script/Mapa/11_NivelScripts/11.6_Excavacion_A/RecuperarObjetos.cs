using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;
using UnityEngine.UI;
using UnityEngine.EventSystems;

[RequireComponent(typeof(SpawnItemIcon))]
[RequireComponent(typeof(PlayerHere))]
public class RecuperarObjetos : MonoBehaviour
{
    [Header("Boton Data")]
    [SerializeReference] Image imageButton;
    [SerializeField] Button button;
    public EventTrigger eventButtonTrigger;
    [Header("Index del Objeto")]
    public int objetoARecoger;
    [Header("Item en Escena")]
    public GameObject objectCatch;
    [Header("FeedBack Pick Item")]
    SpawnItemIcon feedbackItem;
    [Header("Sound Effect Item")]
    [SerializeField] EventReference soundItem;


    PlayerHere dentroDeZona;
    private void Awake()
    {
        feedbackItem = GetComponent<SpawnItemIcon>();
        dentroDeZona = GetComponent<PlayerHere>();
        //Only when object is close

    }
    private void Start()
    {

    }
    private void Update()
    {
        if (dentroDeZona.playerImHere) PickUpObject();
    }
    void PickUpObject()
    {
        if (Input.GetButtonDown("Take"))
        {
            Pick();
        }

    }
    public void Pick()
    {
        //Sonido item
        AudioManager.instancia.PlayOneShot(soundItem);
        feedbackItem.SpawnIcon();
        //Take The object
        //listaItemNivel.listaItemsNivel[objetoARecoger].objetoObtenido = true;
        SaveScene.instancia.listaItemsNivelGuardar[objetoARecoger].vecesUsadoObjeto = 0;
        //Habilitar boton
        imageButton.color = new Color(1f, 1f, 1f, 1f);
        button.enabled = true;
        eventButtonTrigger.enabled = true;
        //Disappaer the object
        objectCatch.SetActive(false);
    }
}
