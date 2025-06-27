using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetUpScience : MonoBehaviour
{
    public int indexMod;
    [Header("Lista Soldados Up")]
    public List<int> indexSoldados;
    void Start()
    {
        if(StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion)
        {
            this.enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Esto se colocara en las cinemáticas, ya que las cinemáticas solo ocurren una vez por nivel, a no ser que repitas el nivel.
        GetUpScientific();
    }
    void GetUpScientific()
    {
        for (int i = 0; i < indexSoldados.Count; i++)
        {
            Debug.Log( i + " " + "Soldao");
            SoldierActiveInScene.instancia.soldiersStatus[indexSoldados[i]].statusVida = 1;
            SoldierActiveInScene.instancia.soldiersStatus[indexSoldados[i]].berserkerStatus = false;
            StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion = true;
        }
    }
}
