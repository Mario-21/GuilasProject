using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdminLlamadaChef : MonoBehaviour
{
    public int indexLlamada;

    [Header("Condiciones_Generales")]
    public int indexSoldadoChef;
    public int indexDormir;
    [Header("Condicion_1:Chef Dia")]
    public int indexModDia;
    public GameObject cambioAreaCin;
    //Soldado vivo
    //Dia
    [Header("Condicion_1:Chef Muerto")]
    public int indexModChefMuerto;
    public GameObject emisorComunicando;
    //Soldado muerto
    [Header("Condicion_1:Chef Noche")]
    public int indexModNoche;
    public GameObject emisorEructo;
    //Sodado vivo
    //Noche
    void Start()
    {
        if (StatusGameobjectsVariables.statusGameobject.modificacion[indexModDia].modificacion ||
            StatusGameobjectsVariables.statusGameobject.modificacion[indexModChefMuerto].modificacion ||
            StatusGameobjectsVariables.statusGameobject.modificacion[indexModNoche].modificacion) 
        {
            this.enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (StatusGameobjectsVariables.statusGameobject.modificacion[indexLlamada].modificacion)
        {
            // Si el chef esta vivo
            if (SoldierActiveInScene.instancia.soldiersStatus[indexSoldadoChef].statusVida >= 1) 
            {
                //Si es de dia
                if (!StatusGameobjectsVariables.statusGameobject.modificacion[indexDormir].modificacion)
                {
                    //StatusGameobjectsVariables.statusGameobject.modificacion[indexModDia].modificacion = true;
                    cambioAreaCin.SetActive(true);
                    this.enabled = false;
                }
                //Si es de Noche
                else
                {
                    StatusGameobjectsVariables.statusGameobject.modificacion[indexModNoche].modificacion = true;
                    emisorEructo.SetActive(true);
                    this.enabled = false;
                }


            }
            //Si el soldado ha muerto
            else if (SoldierActiveInScene.instancia.soldiersStatus[indexSoldadoChef].statusVida < 1)
            {
                StatusGameobjectsVariables.statusGameobject.modificacion[indexModChefMuerto].modificacion = true;
                emisorComunicando.SetActive(true);
                this.enabled = false;
            }
        }
    }
}
