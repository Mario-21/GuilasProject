using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathZoneMultipleSoldier : MonoBehaviour
{
    public int indexMod;

    [SerializeField] List<InformeSoldado> soldados;

    int soldadosMorirVariableTotal;
    int soldadosMuertos;
    void Start()
    {
        soldadosMorirVariableTotal = soldados.Count;
        AnalizarVidaSoldados();
        if (StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion)
        {
            this.enabled = false;
        }
    }

    void Update()
    {
        if(soldadosMuertos < soldadosMorirVariableTotal)
        {
            AnalizarVidaSoldados();
        }
        else if(soldadosMuertos >= soldadosMorirVariableTotal)
        {
            StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion = true;
            this.enabled = false;
        }
    }
    void AnalizarVidaSoldados()
    {
        for (int i = 0; i < soldados.Count; i++)
        {
            if(soldados[i].vidaInicial != SoldierActiveInScene.instancia.soldiersStatus[soldados[i].indexSoldado].statusVida)
            {
                if(SoldierActiveInScene.instancia.soldiersStatus[soldados[i].indexSoldado].statusVida <= 0)
                {
                    soldadosMuertos++;
                    soldados.RemoveAt(i);
                }
                else if(SoldierActiveInScene.instancia.soldiersStatus[soldados[i].indexSoldado].statusVida > 0)
                {
                    soldados[i].vidaInicial = SoldierActiveInScene.instancia.soldiersStatus[soldados[i].indexSoldado].statusVida;
                }
            }
        }
    }

}
[System.Serializable]
public class InformeSoldado
{
    public string nombreSoldado;
    public int indexSoldado;
    public int vidaInicial;
}
