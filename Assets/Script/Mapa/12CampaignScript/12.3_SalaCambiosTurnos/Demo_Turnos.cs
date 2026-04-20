using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Demo_Turnos
{
    public enum TurnosTrabajo 
    {
        AB,
        AC,
        CB
    }
    public TurnosTrabajo turnoActual;
    public virtual void TurnosDemo (List<SoldierLife> soldados, TurnosTrabajo trabajo, Demo_Turnos.TurnosTrabajo turnoZona)
    {
        for (int i = 0; i < soldados.Count; i++)
        {
            if (soldados[i].vida > 0)
            {
                soldados[i].gameObject.SetActive(false);
                //Debug.Log("Este Soldado esta vivo " + soldados[i].name);
            }
        }
    }
    public virtual void DescansoSinTurnos(List<SoldierLife> soldados)
    {
        for (int i = 0; i < soldados.Count; i++)
        {
            //if (soldados[i].vida > 0)
            if (SoldierActiveInScene.instancia.soldiersStatus[soldados[i].status.iD].statusVida > 0)
            {
                soldados[i].gameObject.SetActive(false);
                Debug.Log("Este Soldado esta vivo por parte de DemosTurnos " + soldados[i].name);
            }
        }
    }


    /// <summary>
    /// Confimar si hay un soldado vivo para poder apagar los motores
    /// </summary>
    /// <param name="soldadosIndex"> Numero total de soldados relacionas a un dispositivo</param>
    /// <param name="vivo"> Confirma que se puede apagar un apararo</param>
    public virtual void OffAparatosTurnos (List<int> soldadosIndex, ref bool vivo)
    {
        for (int i = 0; i < soldadosIndex.Count; i++)
        {
            if (SoldierActiveInScene.instancia.soldiersStatus[soldadosIndex[i]].statusVida > 0)
            {
                vivo = true;
                break;
            }
        }
    }
    public void ChangeTurnos (int indexTurno)
    {
        switch (indexTurno)
        {
            case 0:
                turnoActual = TurnosTrabajo.AB;
                //AB pasa a VErde los demas Rojo
                Debug.Log("Turno Actual " + turnoActual);
                //Aqui se daria la explosion
                break;
            case 1:
                turnoActual = TurnosTrabajo.AC;
                //AC VERDE
                Debug.Log("Turno Actual " + turnoActual);
                //Aqui se daria el tanque
                break;
            case 2:
                turnoActual = TurnosTrabajo.CB;
                //CB VERDE
                Debug.Log("Turno Actual " + turnoActual);
                //Aqui la sobreCarga
                break;
        }
    }
}
//Clases de Turno_Zona y Turno_Excavacion
class Turno_Zona : Demo_Turnos
{
    public override void TurnosDemo(List<SoldierLife> soldados, TurnosTrabajo trabajo, TurnosTrabajo turnoZona)
    {
        //Si es mi turno de descanso, descanso.
        if (trabajo != turnoZona)
        {
            base.TurnosDemo(soldados, trabajo, turnoZona);
            Debug.Log("Estoy en turno Zona " + turnoZona);
        }
    }
}
class Turno_Excavacion : Demo_Turnos
{
    public override void TurnosDemo(List<SoldierLife> soldados, TurnosTrabajo trabajo, TurnosTrabajo turnoZona)
    {
        //Si no es mi turno de descanso, trabajo
        if(trabajo == turnoZona)
        {
            base.TurnosDemo(soldados, trabajo, turnoZona);
            Debug.Log("Estoy en turno Excavacion " + turnoZona);
        }
    }
}
class ItemsTurnos : Demo_Turnos
{
    public void ItemsTurno(List<GameObject> itemsSameTurn, List<GameObject> itemsDifTurn, TurnosTrabajo trabajo, TurnosTrabajo turnoZona)
    {
        if(trabajo != turnoZona)
        {
            Debug.Log("Soy un turno de Trabajo, remunerado como el culo");
            ItemsOut(itemsDifTurn);
            
        }
        else
        {
            ItemsOut(itemsSameTurn);
            Debug.Log("Soy un turno de Descanso, de 2 segundo, AAAAAAAAAAAAAAAH!");
        }
    }
    void ItemsOut(List<GameObject> items)
    {
        for(int i = 0; i < items.Count; i++)
        {
            items[i].SetActive(false);
        }
    }
}

