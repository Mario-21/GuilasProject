using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesacticarTrampas : MonoBehaviour
{
    public int objetoAObtener;
    bool here;
    private void Update()
    {
        if (SaveScene.instancia.listaItemsNivelGuardar[objetoAObtener].objetoObtenido)
        {
            ExtraVariable.extras.activarTrampasTemplo = false;
        }
        if (!ExtraVariable.extras.activarTrampasTemplo)
        {
            if (here)
            {
                Debug.Log("Necesitas activar el mecanismo, para poder coger el orbe");
            }
        }
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) here = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) here = false;
    }

}
