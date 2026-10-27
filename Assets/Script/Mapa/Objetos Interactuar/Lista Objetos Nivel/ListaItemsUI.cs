using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListaItemsUI : MonoBehaviour
{
    public static ListaItemsUI listaItemsUI;
    public List<ListAllItemUI> listaAllItemUI;
    private void Awake()
    {

        if (ListaItemsUI.listaItemsUI == null)
        {
            ListaItemsUI.listaItemsUI = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void ResetearItemUI()
    {
        for(int i = 0; i < listaAllItemUI.Count; i++)
        {
            listaAllItemUI[i].itemUICatch = false;
        }
    }
}
