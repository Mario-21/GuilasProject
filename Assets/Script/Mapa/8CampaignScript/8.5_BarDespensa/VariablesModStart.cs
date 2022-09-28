using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VariablesModStart : MonoBehaviour
{
    public int indexMod;
    void Start()
    {
        StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion = true;
    }
}
