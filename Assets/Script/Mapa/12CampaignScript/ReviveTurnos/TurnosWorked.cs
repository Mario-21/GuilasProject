using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnosWorked : MonoBehaviour
{
    public static TurnosWorked extras;

    #region Nivel 12 Turnos
    //Objeto No destruible
    public int turnosWork;
    int turnosWorkInicial;
    #endregion
    #region Sobrecarga (12.10_Excavacion_B)
    public int valorGenerador;
    int valorGeneradorInicial;
    #endregion

    private void Awake()
    {
        if (TurnosWorked.extras == null)
        {
            TurnosWorked.extras = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        turnosWorkInicial = turnosWork;
        valorGeneradorInicial = valorGenerador;
    }
    public void ResetearTurnoWorker() 
    {
        turnosWork = turnosWorkInicial;
        valorGenerador = valorGeneradorInicial;
    }
}
