using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrasladarAgua : MonoBehaviour
{
    [Header("Agua want Trasladar")]
    public int indexAgua_1;
    [Header("Agua Trasladada")]
    public int indexAgua_2;
    [Header("Data Drenaje Zona")]
    public int indexDrenaje;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Si se ha encendido el drenaje
        if (StatusGameobjectsVariables.statusGameobject.modificacion[indexDrenaje].modificacion)
        {
            ListWaters.listWaters.infoAguas[indexAgua_1].porcentajeAgua = ListWaters.listWaters.infoAguas[indexAgua_2].porcentajeAgua;
        }
    }
}
