using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SameSoldier : MonoBehaviour
{
    public int indexSoldadoDescarga;
    [SerializeField] GameObject descargaSoldier;
    public int indexBell;
    void Start()
    {
        if (SoldierActiveInScene.instancia.soldiersStatus[indexSoldadoDescarga].statusVida > 0 && StatusGameobjectsVariables.statusGameobject.modificacion[indexBell].modificacion) 
        {
            descargaSoldier.gameObject.SetActive(true);
        } 
    }
}
