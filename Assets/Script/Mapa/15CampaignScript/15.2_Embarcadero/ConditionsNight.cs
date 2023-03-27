using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConditionsNight : MonoBehaviour
{
    public int indexNoche;
    void Start()
    {
        //Si es de noche 
        if (StatusGameobjectsVariables.statusGameobject.modificacion[indexNoche].modificacion)
        {
            //La moto Esta o no.
                //No: No hace nada.
                //Sí: REvisa si tiene la lona puesta.
                    //No Lona: Desaparece
                    //Si Lona: Esta Todo, pero la Lona esta se tiene que poder Quitar.
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
