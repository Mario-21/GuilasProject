using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierRecoveryRoom : MonoBehaviour
{
    [Header("Soldier Switch")]
    [SerializeField] SoldierLife soldierSwitch;
    [Header("Soldier Normal")]
    [SerializeField] SoldadoNormal soldadoNormal;
    [Header("Soldier Normal Go Switch")]
    [SerializeField] Transform soldadoNormalOP;
    [SerializeField] Transform soldadoNormalSP;
    public float timeWaitToGoLimit;
    public float timeWaitToGo;
    [Header("Trigger Recovery Room")]
    [SerializeField] TriggerInfarmary infarmaryTrigger;

    void Update()
    {
        ConditionsGoSwitch();
    }
    void ConditionsGoSwitch()
    {
        if(soldierSwitch.vida <= 0)
        {
            infarmaryTrigger.RecoveryRoomTrigger();
            timeWaitToGo += Time.deltaTime;
            if(timeWaitToGo >= timeWaitToGoLimit)
            {
                soldadoNormal.ubicacionesDirigir[0] = soldadoNormalSP;
            }
        }
    }
}
