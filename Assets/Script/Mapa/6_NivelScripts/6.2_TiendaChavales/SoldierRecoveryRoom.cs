using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierRecoveryRoom : MonoBehaviour
{
    [Header("Soldier Switch")]
    [SerializeField] SoldierLife soldierSwitch;
    [SerializeField] GameObject soldierBodySwitch;
    [Header("Soldier Normal")]
    [SerializeField] SoldadoNormal soldadoNormal;
    [Header("Soldier Normal Go Switch")]
    [SerializeField] Transform soldadoNormalOP;
    [SerializeField] Transform soldadoNormalSP;
    public float timeWaitToGoLimit;
    public float timeWaitToGo;

    void Update()
    {
        ConditionsGoSwitch();
    }
    void ConditionsGoSwitch()
    {
        if(soldierSwitch.vida <= 0)
        {
            timeWaitToGo += Time.deltaTime;
            if(timeWaitToGo >= timeWaitToGoLimit)
            {
                soldierSwitch.enabled = false;
                soldierBodySwitch.layer = 17;
                soldadoNormal.ubicacionesDirigir[0] = soldadoNormalSP;
            }
        }
    }
}
