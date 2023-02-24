using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrasladarAgua : MonoBehaviour
{
    [Header("Agua want Trasladar")]
    public WaterData waterInfo;
    [Header("Agua Trasladada")]
    public int indexAgua_2;
    [Header("Data Drenaje Zona")]
    public int indexDrenaje;

    int countSuma;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Si se ha encendido el drenaje
        if (StatusGameobjectsVariables.statusGameobject.modificacion[indexDrenaje].modificacion)
        {
            if(countSuma < 1 && ListWaters.listWaters.infoAguas[indexAgua_2].porcentajeAgua < 100)
            {
                ListWaters.listWaters.infoAguas[indexAgua_2].porcentajeAgua += waterInfo.porcentajeAgua;
                countSuma++;
            }
            else if (ListWaters.listWaters.infoAguas[indexAgua_2].porcentajeAgua >= 100)
            {
                ListWaters.listWaters.infoAguas[indexAgua_2].porcentajeAgua = 100;
            }
        }
        else
        {
            countSuma = 0;
        }
    }
}
