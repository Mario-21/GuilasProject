using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ValvulaConGenerador : MonoBehaviour
{
    public int indexGenMadre;
    public int indexMantenimiento;
    public int indexDrenaje;
    [Header("InfoAgua")]
    [SerializeField] WaterData aguaPrincipal;
    [Header("InfoValvulas")]
    [SerializeField] List<GameObject> listaCascadasValvula;
    void Start()
    {
        //Esto es para que no se vuelva loco el orden con los otros scripts
        Invoke("CondicionesValvulaGenerador", 0.5f);
    }
    void CondicionesValvulaGenerador()
    {
        //Si la palanca de mantenimiento no esta activa
        if (!StatusGameobjectsVariables.statusGameobject.modificacion[indexMantenimiento].modificacion)
        {
            //Si activas el generador madre establece las cascadas como inicialmente se encuentran encendidas, pero sin poder manipularlas
            if (StatusGameobjectsVariables.statusGameobject.modificacion[indexGenMadre].modificacion)
            {
                foreach (GameObject cascada in listaCascadasValvula)
                {
                    cascada.SetActive(true);
                }
                //Adicionalmente si el drenaje se encuentra abierto, es de suponer que la zona se habrá vaciado.
                if (!StatusGameobjectsVariables.statusGameobject.modificacion[indexDrenaje].modificacion)
                {
                    ListWaters.listWaters.infoAguas[aguaPrincipal.indexWater].porcentajeAgua = 100;
                    aguaPrincipal.transform.position = new Vector3(aguaPrincipal.transform.position.x, aguaPrincipal.alturaMax.position.y, aguaPrincipal.transform.position.z);

                }
            }
        }
    }
}
