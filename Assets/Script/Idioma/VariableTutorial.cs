using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VariableTutorial : MonoBehaviour
{
    public int indexModTuto;
    void Start()
    {
        StatusGameobjectsVariables.statusGameobject.modificacion[indexModTuto].modificacion = true;
    }
}
