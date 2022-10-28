using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CogerObjeto : MonoBehaviour
{
    [Header("Index del Objeto")]
    public int objetoARecoger;
    [Header("Item en Escena")]
    public GameObject objectCatch;
    [Header("Inventory Button")]
    public GameObject objetcButtonInventory;

    PlayerHere dentroDeZona;
    private void Awake()
    {
        dentroDeZona = GetComponent<PlayerHere>();
        //Only when object is close

    }
    private void Start()
    {
        if(SaveScene.instancia.listaItemsNivelGuardar[objetoARecoger].objetoObtenido) objectCatch.SetActive(false);
    }
    private void Update()
    {
        if (dentroDeZona.playerImHere) PickUpObject();
    }
    void PickUpObject()
    {
        if (Input.GetKeyDown(KeyCode.T) && !SaveScene.instancia.listaItemsNivelGuardar[objetoARecoger].objetoObtenido)
        {
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
}
