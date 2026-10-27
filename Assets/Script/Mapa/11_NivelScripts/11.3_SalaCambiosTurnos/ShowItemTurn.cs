using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowItemTurn : MonoBehaviour
{
    public enum ZonaItems
    {
        A,
        B,
        C
    }
    public ZonaItems zoneItem;
    [Header("Items Same Turn")]
    [Tooltip("En el mismo turno del descanso el objeto desaparece")]
    public List<GameObject> itemsSame;
    [Header("Items Diferent Turn")]
    [Tooltip("En un turno trabajo el objeto desaparece")]
    public List<GameObject> itemsDifferent;
    void Start()
    {
        ItemsTurnos items = new ItemsTurnos();
        Demo_Turnos turno = new Demo_Turnos();
        turno.ChangeTurnos(TurnosWorked.extras.turnosWork);
        Debug.Log("EN show item el turno es " + turno.turnoActual);
        switch (zoneItem)
        {
            case ZonaItems.A:
                items.ItemsTurno(itemsSame, itemsDifferent, turno.turnoActual, Demo_Turnos.TurnosTrabajo.CB);
                break;
            case ZonaItems.B:
                items.ItemsTurno(itemsSame, itemsDifferent, turno.turnoActual, Demo_Turnos.TurnosTrabajo.AC);
                break;
            case ZonaItems.C:
                items.ItemsTurno(itemsSame, itemsDifferent, turno.turnoActual, Demo_Turnos.TurnosTrabajo.AB);
                break;
        }
    }
}
