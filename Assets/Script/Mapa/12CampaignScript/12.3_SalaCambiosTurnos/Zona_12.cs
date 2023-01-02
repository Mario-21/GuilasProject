using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zona_12 : MonoBehaviour
{
    public List<SoldierLife> lista_Soldados;

    public enum Zona
    {
        zona_A,
        Excavacion_A,
        zona_B,
        Excavacion_B,
        zona_C,
        Excavacion_C,
    }
    public Zona zonaNivel;
    void Start()
    {
        Demo_Turnos turno = new Demo_Turnos();
        turno.ChangeTurnos(ExtraVariable.extras.turnosWork);
        Turno_Zona turno_Zona = new Turno_Zona();
        Turno_Excavacion turno_Excavacion = new Turno_Excavacion();
        switch (zonaNivel)
        {
            case Zona.zona_A:
                turno_Zona.TurnosDemo(lista_Soldados, turno.turnoActual, Demo_Turnos.TurnosTrabajo.CB);
                break;
            case Zona.Excavacion_A:
                turno_Excavacion.TurnosDemo(lista_Soldados, turno.turnoActual, Demo_Turnos.TurnosTrabajo.CB);
                break;
            case Zona.zona_B:
                turno_Zona.TurnosDemo(lista_Soldados, turno.turnoActual, Demo_Turnos.TurnosTrabajo.AC);
                break;
            case Zona.Excavacion_B:
                turno_Excavacion.TurnosDemo(lista_Soldados, turno.turnoActual, Demo_Turnos.TurnosTrabajo.AC);
                break;
            case Zona.zona_C:
                turno_Zona.TurnosDemo(lista_Soldados, turno.turnoActual, Demo_Turnos.TurnosTrabajo.AB);
                break;
            case Zona.Excavacion_C:
                turno_Excavacion.TurnosDemo(lista_Soldados, turno.turnoActual, Demo_Turnos.TurnosTrabajo.AB);
                break;

        }

    }
}
