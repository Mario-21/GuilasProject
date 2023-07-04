using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesacticarTrampas : MonoBehaviour
{
    public int indexModTrampasOn;
    public int indexModTrampasOff;

    [Header("What happen When off Trampas")]
    [SerializeField] GameObject baldosaStart;
    [SerializeField] GameObject baldosaFinish;
    [SerializeField] Transform ubiBaldosa;

    [Header("Item Off Trampas")]
    public int objetoAObtener;


    private void Update()
    {
        if (SaveScene.instancia.listaItemsNivelGuardar[objetoAObtener].objetoObtenido)
        {
            StatusGameobjectsVariables.statusGameobject.modificacion[indexModTrampasOn].modificacion = false;
            StatusGameobjectsVariables.statusGameobject.modificacion[indexModTrampasOff].modificacion = true;

            baldosaStart.SetActive(false);
            baldosaFinish.SetActive(true);

            baldosaFinish.transform.position = ubiBaldosa.position;
            
        }
        
    }

}
