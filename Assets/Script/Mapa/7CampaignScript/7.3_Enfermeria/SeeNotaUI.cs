using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeeNotaUI : MonoBehaviour
{
    public int indexUIMod;
    void Start()
    {
        if (ListaItemsUI.listaItemsUI.listaAllItemUI[indexUIMod].itemUICatch) this.gameObject.SetActive(true);
        else this.gameObject.SetActive(false);
    }
}
