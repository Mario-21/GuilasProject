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
    [SerializeField] BoxCollider2D recoveryRoom;

    // Update is called once per frame
    void Update()
    {
        ConditionsGoSwitch();
    }
    void ConditionsGoSwitch()
    {
        if(soldierSwitch.vida <= 0)
        {
            RecoveryRoom();
            timeWaitToGo += Time.deltaTime;
            if(timeWaitToGo >= timeWaitToGoLimit)
            {
                soldadoNormal.ubicacionesDirigir[0] = soldadoNormalSP;
            }
        }
    }
    void RecoveryRoom()
    {
        if(!soldadoNormal.berserker && !soldadoNormal.busquedaMode && soldadoNormal.GetComponent<SoldierLife>().vida > 0)
        {
            recoveryRoom.enabled = true;
        }
        else if(soldadoNormal.berserker || soldadoNormal.busquedaMode || soldadoNormal.GetComponent<SoldierLife>().vida <= 0)
        {
            recoveryRoom.enabled = false;
        }
    }
}
