using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncreaseUseItems : MonoBehaviour
{
    public int indexMod;
    [Header("Pala Info")]
    [SerializeField] SaveButton itemIncrease;
    public int numIncrease;
    void Update()
    {
        if (StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion)
        {
            itemIncrease.usosLimitados = numIncrease;
        }
    }
}
