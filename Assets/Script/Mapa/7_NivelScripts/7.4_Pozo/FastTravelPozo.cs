using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FastTravelPozo : MonoBehaviour
{
    public int indexMod;
    public int indexItem;
    private void Start()
    {
        if (StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion) this.enabled = false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (SaveScene.instancia.listaItemsNivelGuardar[indexItem].objetoObtenido)
            {
                StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion = true;
            }
        }
    }
}
