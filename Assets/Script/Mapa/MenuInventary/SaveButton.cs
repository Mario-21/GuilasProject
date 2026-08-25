using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class SaveButton : MonoBehaviour
{
    public int indexButton;
    public int indexPos;

    [Header("Usos del objeto")]
    public int usosLimitados;
    [HideInInspector] public int usos;
    [Header("Boton Data")]
    [SerializeReference] Image imageButton;
    [SerializeField] Button button;
    public EventTrigger eventButtonTrigger;
    void Start()
    {
        CallButtonAppear();
        LimitarUsos();
    }
    public void CallButtonAppear()
    {

        if (SaveScene.instancia.listaItemsNivelGuardar[indexButton].objetoObtenido) 
        {
            this.gameObject.SetActive(true);
            
            this.gameObject.GetComponent<RectTransform>().localPosition =  InventoryManager.instanciaInventory.inventoryPosition[SaveScene.instancia.listaItemsNivelGuardar[indexButton].ubiPosButton];
        } 
        else this.gameObject.SetActive(false);
    }
    public void LimitarUsos()
    {
        //Coge los usos que estan permitidos usar en la lista y los iguala
        //If you call one time desactive the button always
        usos = SaveScene.instancia.listaItemsNivelGuardar[indexButton].vecesUsadoObjeto;
        if (usos >= usosLimitados)
        {
            UsosGastados();
        }
    }
    public void UsosGastados()
    {
        //Inactive the button
        imageButton.color = new Color(1f, 1f, 1f, 0.25f);
        button.enabled = false;
        eventButtonTrigger.enabled = false;
    }
    public void HabilitarUsos()
    {
        //Restablecer el objeto sin haber abierto el inventario
        if(imageButton == null)
        {
            imageButton = GetComponent<Image>();
            button = GetComponent<Button>();
        }
        //Habilitar boton
        imageButton.color = new Color(1f, 1f, 1f, 1f);
        button.enabled = true;
        eventButtonTrigger.enabled = true;
    }
    


}
