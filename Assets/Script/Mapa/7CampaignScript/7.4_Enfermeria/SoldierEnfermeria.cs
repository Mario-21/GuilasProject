using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierEnfermeria : MonoBehaviour
{
    [Header("Condicions Recovery Room")]
    public int indexModOther;
    [Header("Variable Revive")]
    public int indexMod;
    [Header("Doctor Main")]
    public int indexDoctorMain;
    void Start()
    {
        //Si todavia no ha revivido, entonces aun tengo la oportunidad de revivir
        if (!StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion)
        {
            WakeUpDoctorSwitchSoldier();
        }
    }
    void WakeUpDoctorSwitchSoldier()
    {
        //Si se electrocuta el soldado y has muerto previamente puedes revivir
        if (StatusGameobjectsVariables.statusGameobject.modificacion[indexModOther].modificacion)
        {
            //Seguidamene activara la segunda variable en la que revivir solo se ejecutara una vezç
            SoldierActiveInScene.instancia.soldiersStatus[indexDoctorMain].statusVida = 1;
            SoldierActiveInScene.instancia.soldiersStatus[indexDoctorMain].berserkerStatus = false;
            StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion = true;
        }
    }
}
