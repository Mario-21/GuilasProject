using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReviveTurnos : MonoBehaviour
{
    public int turnoStart;
    public int valorGeneradorStart;
    void Start()
    {
        turnoStart = TurnosWorked.extras.turnosWork;
        valorGeneradorStart = TurnosWorked.extras.valorGenerador;
    }
    public void TurnosRevivir()
    {
        TurnosWorked.extras.turnosWork = turnoStart;
        TurnosWorked.extras.valorGenerador = valorGeneradorStart;
    }

}
