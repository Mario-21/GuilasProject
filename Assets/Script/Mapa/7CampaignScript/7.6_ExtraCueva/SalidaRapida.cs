using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SalidaRapida : MonoBehaviour
{
    public int indexNote; 
    public int indexMod;
    [SerializeField] GameObject viajeRapido;
    public enum ModeExit
    {
        itemUI,
        itemNormal
    }
    public ModeExit mode;
    void Start()
    {
        if (StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion) this.enabled = false;
    }
    void Update()
    {
        switch (mode)
        {
            case ModeExit.itemUI:
                TakeNote();
                break;
            case ModeExit.itemNormal:
                TakeItem();
                break;
        }
    }
    void TakeNote()
    {
        if (ListaItemsUI.listaItemsUI.listaAllItemUI[indexNote].itemUICatch && !StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion)
        {
            viajeRapido.SetActive(true);
        }
    }
    void TakeItem()
    {
        if (SaveScene.instancia.listaItemsNivelGuardar[indexNote].objetoObtenido && !StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion)
        {
            viajeRapido.SetActive(true);
        }
    }
}
