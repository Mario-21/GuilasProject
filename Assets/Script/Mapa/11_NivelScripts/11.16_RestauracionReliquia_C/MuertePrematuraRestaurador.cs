using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuertePrematuraRestaurador : MonoBehaviour
{
    [SerializeField] int indexMod;
    [Header("Id Soldado Restaurador")]
    [SerializeField] int idSoldadoRestaurador;
    [Header("Variable Tanque Agua")]
    [SerializeField] int varBreakTank;
    [Header("Puerta de Restauracion B")]
    [SerializeField] GameObject doorRestauracionOpen;
    [SerializeField] GameObject doorRestauracionClose;
    [Header("Sonido Manguera")]
    [SerializeField] GameObject sonidoManguera;
    void Start()
    {
        ComprobarTankBreak();
        SonidoManguera();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void ComprobarTankBreak()
    {
        //Si sea destruido el tanque después de que el soldado muera
        if (StatusGameobjectsVariables.statusGameobject.modificacion[varBreakTank].modificacion)
        {
            //Si "muerte prematura" todavía no se ha activado, significa que la puerta permanecera abierta 
            if (!StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion)
            {
                doorRestauracionClose.SetActive(false);
                doorRestauracionOpen.SetActive(true);
            }
            //Si "muerte prematura" esta activada, quiere decir que la puerta permanecera cerrada permanentemente
        }
        //Si el soldado ha muerto antes de la destrucción del tanque
        else
        {
            //Tras morir el soldado activa la variable "Muerte Prematura"
            if(SoldierActiveInScene.instancia.soldiersStatus[idSoldadoRestaurador].statusVida <= 0)
            {
                StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion = true;
            }
        }
    }
    void SonidoManguera()
    {
        if (StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion)
        {
            sonidoManguera.SetActive(false);
        }
    }
}
