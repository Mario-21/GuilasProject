using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FastTravelOnce : MonoBehaviour
{
    public int indexMod;
    public int indexNote;
    private void Start()
    {
        if (StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion) this.enabled = false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (ListaItemsUI.listaItemsUI.listaAllItemUI[indexNote].itemUICatch)
            {
                StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion = true;
            }
        }
    }

}
