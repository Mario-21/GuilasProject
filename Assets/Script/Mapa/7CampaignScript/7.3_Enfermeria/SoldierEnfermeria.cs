using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierEnfermeria : MonoBehaviour
{
    public int indexMod;
    [SerializeField] SoldierLife soldadoDoctor;
    void Start()
    {
        if (SaveScene.instancia.wakeUpDoctorSwitch < 1) WakeUpDoctorSwitchSoldier();
    }
    void WakeUpDoctorSwitchSoldier()
    {
        if (StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion)
        {
            soldadoDoctor.vida = 1;
            SaveScene.instancia.wakeUpDoctorSwitch++;
        }
    }
}
