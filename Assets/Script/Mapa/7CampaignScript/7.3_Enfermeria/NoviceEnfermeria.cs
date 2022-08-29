using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoviceEnfermeria : MonoBehaviour
{
    public int indexMod;
    public int indexSoldier;
    void Start()
    {
        if (SaveScene.instancia.wakeUpDoctorNovice < 1) WakeUpDoctorNoviceSoldier();
    }
    void WakeUpDoctorNoviceSoldier()
    {
        if (StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion)
        {
            SoldierActiveInScene.instancia.soldiersStatus[indexSoldier].statusVida = 1;
            SaveScene.instancia.wakeUpDoctorNovice++;
        }
    }
}
