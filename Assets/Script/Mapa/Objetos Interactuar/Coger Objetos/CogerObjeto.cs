using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class CogerObjeto : MonoBehaviour
{
    [Header("Index del Objeto")]
    public int objetoARecoger;
    [Header("Item en Escena")]
    public GameObject objectCatch;
    [Header("Inventory Button")]
    public GameObject objetcButtonInventory;
    [Header("FeedBack Pick Item")]
    SpawnItemIcon feedbackItem;
    [Header("Sound Effect Item")]
    [SerializeField] EventReference soundItem;

    PlayerHere dentroDeZona;

    RectTransform transformRectItemr;
    private void Awake()
    {
        feedbackItem = GetComponent<SpawnItemIcon>();
        dentroDeZona = GetComponent<PlayerHere>();
        //Only when object is close

    }
    private void Start()
    {
        if(SaveScene.instancia.listaItemsNivelGuardar[objetoARecoger].objetoObtenido) objectCatch.SetActive(false);
        transformRectItemr = objetcButtonInventory.GetComponent<RectTransform>();
        Debug.Log(objetcButtonInventory.GetComponent<RectTransform>().localPosition);
    }
    private void Update()
    {
        if (dentroDeZona.playerImHere) PickUpObject();
    }
    void PickUpObject()
    {
        if (Input.GetButtonDown("Take") && !SaveScene.instancia.listaItemsNivelGuardar[objetoARecoger].objetoObtenido)
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
        SaveScene.instancia.listaItemsNivelGuardar[objetoARecoger].objetoObtenido = true;
        //Set the button position and active
        objetcButtonInventory.GetComponent<RectTransform>().localPosition = InventoryManager.instanciaInventory.inventoryPosition[InventoryManager.instanciaInventory.indexInventoryPosition];
        SaveScene.instancia.listaItemsNivelGuardar[objetoARecoger].ubiPosButton = InventoryManager.instanciaInventory.indexInventoryPosition;
        objetcButtonInventory.SetActive(true);
        //Increaso to the next position for the following object
        InventoryManager.instanciaInventory.indexInventoryPosition++;
        //Disappaer the object
        objectCatch.SetActive(false);
    }
}
