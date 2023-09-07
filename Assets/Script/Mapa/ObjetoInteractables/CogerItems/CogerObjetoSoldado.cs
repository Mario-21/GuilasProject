using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class CogerObjetoSoldado : MonoBehaviour
{
    SoldierLife soldadoVida;

    public int objetoARecoger;
    public GameObject objectToPickUp;

    PlayerHere zona;

    public GameObject buttonObjectInventory;

    SpawnItemIcon iconItem;

    public enum TypeItem
    {

        NormalItem,
        UiItem
    }
    public TypeItem typeItem;

    [Header("Item SFX")]
    public EventReference itemSound;


    private void Awake()
    {
        iconItem = GetComponent<SpawnItemIcon>();

        zona = GetComponent<PlayerHere>();

        soldadoVida = GetComponentInParent<SoldierLife>();
    }
    private void Start()
    {
        ConfirmItem();
    }
    private void Update()
    {
        if (zona.playerImHere) ObjetoSoldado();
    }
    void ObjetoSoldado()
    {
        if (soldadoVida.vida <= 0)
        {
            Debug.Log("Puedes coger el Objeto con T");
            //Si todavia no has recogido el objeto puedes cogerlo
            ItemType();
        }
    }
    void CatchObjectNormal()
    {
        if (Input.GetButtonDown("Take") && !SaveScene.instancia.listaItemsNivelGuardar[objetoARecoger].objetoObtenido)
        {
            AudioManager.instancia.PlayOneShot(itemSound);

            iconItem.SpawnIcon();

            SaveScene.instancia.listaItemsNivelGuardar[objetoARecoger].objetoObtenido = true;

            buttonObjectInventory.GetComponent<RectTransform>().localPosition = InventoryManager.instanciaInventory.inventoryPosition[InventoryManager.instanciaInventory.indexInventoryPosition];
            SaveScene.instancia.listaItemsNivelGuardar[objetoARecoger].ubiPosButton = InventoryManager.instanciaInventory.indexInventoryPosition;
            buttonObjectInventory.SetActive(true);
            InventoryManager.instanciaInventory.indexInventoryPosition++;
            Debug.Log("Has cogido la llave");
            objectToPickUp.SetActive(false);
        }
    }
    void CatchItemUI()
    {
        if (Input.GetButtonDown("Take"))
        {
            AudioManager.instancia.PlayOneShot(itemSound);
            buttonObjectInventory.SetActive(true);
            objectToPickUp.SetActive(false);
            ListaItemsUI.listaItemsUI.listaAllItemUI[objetoARecoger].itemUICatch = true;
            this.gameObject.SetActive(false);
        }
    }
    void ItemType()
    {
        switch (typeItem)
        {
            case TypeItem.NormalItem:
                CatchObjectNormal();
                break;
            case TypeItem.UiItem:
                CatchItemUI();
                break;
        }
    }
    void ConfirmItem()
    {
        switch (typeItem)
        {
            case TypeItem.NormalItem:
                if (SaveScene.instancia.listaItemsNivelGuardar[objetoARecoger].objetoObtenido)
                {
                    objectToPickUp.SetActive(false);
                    this.enabled = false;
                }
                break;
            case TypeItem.UiItem:
                if (ListaItemsUI.listaItemsUI.listaAllItemUI[objetoARecoger].itemUICatch)
                {
                    objectToPickUp.SetActive(false);
                    this.enabled = false;
                }
                break;
        }
    }

}
