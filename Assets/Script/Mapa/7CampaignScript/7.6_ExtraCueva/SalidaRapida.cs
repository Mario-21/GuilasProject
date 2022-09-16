using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SalidaRapida : MonoBehaviour
{
    public int indexNote; 
    public int indexMod;
    [SerializeField] GameObject viajeRapido;
    void Start()
    {
        if (StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion) this.enabled = false;
    }
    void Update()
    {
        TakeNote();
    }
    void TakeNote()
    {
        if (ListaItemsUI.listaItemsUI.listaAllItemUI[indexNote].itemUICatch && !StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion)
        {
            viajeRapido.SetActive(true);
        }
    }
}
