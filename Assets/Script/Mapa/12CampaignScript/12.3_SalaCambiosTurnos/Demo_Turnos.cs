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
                Debug.Log("Este Soldado esta vivo " + soldados[i].name);
            }
        }
    }
    public void ChangeTurnos (int indexTurno)
    {
        switch (indexTurno)
        {
            case 0:
                turnoActual = TurnosTrabajo.AB;
                Debug.Log("Turno Actual " + turnoActual);
                break;
            case 1:
                turnoActual = TurnosTrabajo.AC;
                Debug.Log("Turno Actual " + turnoActual);
                break;
            case 2:
                turnoActual = TurnosTrabajo.CB;
                Debug.Log("Turno Actual " + turnoActual);
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

