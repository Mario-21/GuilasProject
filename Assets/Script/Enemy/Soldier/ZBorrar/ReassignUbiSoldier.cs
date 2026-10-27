using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReassignUbiSoldier : MonoBehaviour
{
    [Header("Soldado Data Ubicaciones")]
    [SerializeField] SoldadoNormal soldado;
    [SerializeField] SoldierLife soldadoVida;
    [Header("New Ubicaciones")]
    [SerializeField] List<Transform> newUbi;
    void Start()
    {
        if(soldadoVida.vida > 0)
        {
            soldado.ubicacionesDirigir = newUbi;
        }
    }
}
