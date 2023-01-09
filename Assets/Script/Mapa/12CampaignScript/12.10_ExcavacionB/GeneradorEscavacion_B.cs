using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneradorEscavacion_B : MonoBehaviour
{
    public int indexMod;

    public int valorElectricoMaximo;
    void Update()
    {
        if (ExtraVariable.extras.valorGenerador >= valorElectricoMaximo) 
        {
            StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion = true;
        }
    }
}
