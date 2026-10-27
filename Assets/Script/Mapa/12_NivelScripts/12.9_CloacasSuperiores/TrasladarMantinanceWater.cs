using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrasladarMantinanceWater : MonoBehaviour
{
    public int indexDrenajeArriba;
    public int indexMantenimiento;
    public int indexMod;
    [Header("Particles Gotas")]
    public GameObject gotas;
    //[Header("Reposition Platforms")]
    //public List<SpawnPlatform> platformsWater;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Si la zona del mantenimiento no se ha encendido la palanca y además en la zona de arriba la valvula de drenaje se ha quedado abierta
        //Se tiene que invertir por la condicion del Drenaje
        if(!StatusGameobjectsVariables.statusGameobject.modificacion[indexMantenimiento].modificacion && StatusGameobjectsVariables.statusGameobject.modificacion[indexDrenajeArriba].modificacion)
        {
            StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion = false;
            gotas.SetActive(true);
        }
        else
        {
            StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion = true;
            gotas.SetActive(false);
        }

        
    }
}
