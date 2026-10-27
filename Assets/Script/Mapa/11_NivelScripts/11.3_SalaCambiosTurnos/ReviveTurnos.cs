using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReviveTurnos : MonoBehaviour
{
    public int turnoStart;
    public int valorGeneradorStart;
    public float barraGenerator;
    
    void Start()
    {
        turnoStart = TurnosWorked.extras.turnosWork;
        valorGeneradorStart = TurnosWorked.extras.valorGenerador;
        barraGenerator = GeneradorEscavacion_B.barraGenNumber;
    }
    public void TurnosRevivir()
    {
        TurnosWorked.extras.turnosWork = turnoStart;
        TurnosWorked.extras.valorGenerador = valorGeneradorStart;
        GeneradorEscavacion_B.barraGenNumber = barraGenerator;
    }

}
