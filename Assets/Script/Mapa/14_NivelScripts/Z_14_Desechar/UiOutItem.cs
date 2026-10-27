using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiOutItem : MonoBehaviour
{
    public int indexUIMod;
    public GameObject uiItem;

    void Update()
    {
        if (ListaItemsUI.listaItemsUI.listaAllItemUI[indexUIMod].itemUICatch) uiItem.SetActive(false);
    }
}
