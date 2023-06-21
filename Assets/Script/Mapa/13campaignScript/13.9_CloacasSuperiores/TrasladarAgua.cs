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
    public int indexDrenajeUp;
    public int indexDrenajeDown;

    int countSuma;
    void Start()
    {
        //Si al pasar a la escena de arriba el drenaje ya esta abierto, el conteo se establece en 1 como si ya se hubiera usado, ya que si no lo colocas así te lo vuelve a calcular
        //provocando que el agua de abajo se drene aun teniendo el drenaje cerrado
        if (StatusGameobjectsVariables.statusGameobject.modificacion[indexDrenajeUp].modificacion)
        {
            countSuma = 1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Si se ha encendido el drenaje y además el drenaje de abajo esta cerrado, se trasladara el agua
        if (StatusGameobjectsVariables.statusGameobject.modificacion[indexDrenajeUp].modificacion && !StatusGameobjectsVariables.statusGameobject.modificacion[indexDrenajeDown].modificacion)
        {
            //Aqui esta el error, cuando yo subo y me encuentro con el boton cerrada te vuelve a trasladar el agua, que en este caso es 0 lo que provoca que abajo se vacie aun teniendo el drenaje cerrado
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
        else if(!StatusGameobjectsVariables.statusGameobject.modificacion[indexDrenajeUp].modificacion)
        {
            countSuma = 0;
        }
    }
}
