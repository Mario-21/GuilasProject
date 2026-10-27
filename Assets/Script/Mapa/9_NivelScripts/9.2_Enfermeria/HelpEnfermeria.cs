using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelpEnfermeria : MonoBehaviour
{
    public int indexModVenenoGlass; // Equivale al 5
    public int indexMod; // Index propio del script
    [Header("Soldados Ayuda Veneno")]
    public GameObject ap_des_HelpPoison;
    public int indexSoldado1;
    public int indexSoldado2;
    void Start()
    {
        if (StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion)
        {
            ap_des_HelpPoison.SetActive(true);
            this.enabled = false;
            Debug.Log("Katana Fuera");
        }

        if(StatusGameobjectsVariables.statusGameobject.modificacion[indexModVenenoGlass].modificacion && !StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion)
        {
            if(SoldierActiveInScene.instancia.soldiersStatus[indexSoldado1].statusVida > 0 && SoldierActiveInScene.instancia.soldiersStatus[indexSoldado2].statusVida > 0)
            {
                SoldierActiveInScene.instancia.soldiersStatus[indexSoldado1].berserkerStatus = false;
                SoldierActiveInScene.instancia.soldiersStatus[indexSoldado2].berserkerStatus = false;
                StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion = true;
                ap_des_HelpPoison.SetActive(true);
                Debug.Log("Katana 0");
            }
            else if (SoldierActiveInScene.instancia.soldiersStatus[indexSoldado1].statusVida <= 0 && SoldierActiveInScene.instancia.soldiersStatus[indexSoldado2].statusVida <= 0)
            {
                ap_des_HelpPoison.SetActive(false);
                Debug.Log("Katana No Existe");
            }
        }
    }


}
