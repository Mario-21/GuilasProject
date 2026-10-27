using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnP3 : MonoBehaviour
{
    public int indexMod;
    [SerializeField] Image button;

    void Start()
    {
        if (StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion)
        {
            StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion = true;
            button.color = Color.green;
        }   
    }
    public void ActiveP3()
    {
        AudioManager.instancia.PlayOneShot(FMODEvent.instancia.botonGeneral);
        StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion = true;
        button.color = Color.green;
    }
}
