using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConditionsPutReliquia : MonoBehaviour
{
    public int indexReliquiaUI;
    [SerializeField] IconItem iconeItem;
    void Start()
    {
        if (ListaItemsUI.listaItemsUI.listaAllItemUI[indexReliquiaUI].itemUICatch)
        {
            iconeItem.enabled = true;
        }
    }
}
