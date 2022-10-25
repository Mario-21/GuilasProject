using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockDoorScience : MonoBehaviour
{
    public int indexMod;
    [Header("Type Unlock")]
    public TypeUnlock unlockWith;
    public enum TypeUnlock
    {
        ItemVariable,
        UI
    }
    [Header("Unlock")]
    public Camino_CambiarZona doorScience;
    void Start()
    {
        switch (unlockWith)
        {
            case TypeUnlock.ItemVariable:
                if (StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion) doorScience.enabled = true;
                break;
            case TypeUnlock.UI:
                if(ListaItemsUI.listaItemsUI.listaAllItemUI[indexMod].itemUICatch) doorScience.enabled = true;
                break;
        }
    }
}
