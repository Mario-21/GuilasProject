using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConditionsKeepMoto : MonoBehaviour
{
    public int indexSleep;
    public int indexOcultacionMoto;

    public int indexBotonMoto;
    void Start()
    {
        //Si has dormido, pero no ocultaste la moto con la lona. Reinicia el boton de sacar la moto.
        if(StatusGameobjectsVariables.statusGameobject.modificacion[indexSleep].modificacion 
           && !StatusGameobjectsVariables.statusGameobject.modificacion[indexOcultacionMoto].modificacion)
        {
            StatusGameobjectsVariables.statusGameobject.modificacion[indexBotonMoto].modificacion = false;
        }
        //Si has escondido la moto entonces no hagas nada
        else if (StatusGameobjectsVariables.statusGameobject.modificacion[indexSleep].modificacion
           && StatusGameobjectsVariables.statusGameobject.modificacion[indexOcultacionMoto].modificacion)
        {
            this.enabled = false;
        }
    }
}
