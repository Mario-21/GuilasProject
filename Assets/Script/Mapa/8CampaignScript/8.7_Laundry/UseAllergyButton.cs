using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseAllergyButton : MonoBehaviour
{
    public int indexModAllergy;
    public SaveButton jarraLlena;
    public SaveButton jarraVacia;
    void Start()
    {
        if (StatusGameobjectsVariables.statusGameobject.modificacion[indexModAllergy].modificacion)
        {
            LimitUse();
        }
    }

    public void LimitUse()
    {
        jarraVacia.usosLimitados = 1;
        jarraLlena.usosLimitados = 1;
    }
}
