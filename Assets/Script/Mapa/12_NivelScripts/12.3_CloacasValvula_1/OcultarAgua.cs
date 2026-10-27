using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OcultarAgua : MonoBehaviour
{
    //Anular la caja de collisiones no el objeto
    public int indexAgua;
    [Tooltip("Si el porcentaje del aguas es inferior a este límite, desactiva el collider del agua")]
    public int porcentajeLimite;
    [SerializeField] BoxCollider2D colliderAgua;
    void Update()
    {
        AguaOculta();
    }
    void AguaOculta()
    {
        if(ListWaters.listWaters.infoAguas[indexAgua].porcentajeAgua <= porcentajeLimite)
        {
            colliderAgua.enabled = false;
        }
        else if(ListWaters.listWaters.infoAguas[indexAgua].porcentajeAgua > porcentajeLimite)
        {
            colliderAgua.enabled = true;
        }
    }
}
