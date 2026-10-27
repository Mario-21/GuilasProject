using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerInfarmary : MonoBehaviour
{
    [Header("Soldados")]
    [SerializeField] SoldadoNormal soldadoNormal;
    [SerializeField] Transform soldadoSwitch;
    [Header("Triggers")]
    [SerializeField] BoxCollider2D triggerInfarmary_1;
    [SerializeField] BoxCollider2D triggerInfarmary_2;

    public bool triggerPlace;
    // Update is called once per frame
    void Update()
    {
        ChooseTrigger();
        
    }
    public void RecoveryRoomTrigger()
    {
        if (!soldadoNormal.berserker && !soldadoNormal.busquedaMode && soldadoNormal.GetComponent<SoldierLife>().vida > 0)
        {
            ActiveTrigger();
        }
        else if (soldadoNormal.berserker || soldadoNormal.busquedaMode || soldadoNormal.GetComponent<SoldierLife>().vida <= 0)
        {
            triggerInfarmary_1.enabled = false;
            triggerInfarmary_2.enabled = false;
        }
    }
    void ChooseTrigger()
    {
        if(SoldadoDistanceTrigger().x > 0)
        {
            triggerPlace = true;
        }
        else
        {
            triggerPlace = false;
        }
    }
    void ActiveTrigger()
    {
        Debug.Log("OnTirgger");
        if (triggerPlace)
        {
            triggerInfarmary_1.enabled = true;
        }
        else
        {
            triggerInfarmary_2.enabled = true;
        }
    }

    Vector2 SoldadoDistanceTrigger()
    {
        Vector2 soldadoTrigger;
        return soldadoTrigger = soldadoSwitch.position - transform.position;
    }
}
