using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierDeathPlatform : MonoBehaviour
{
    public int indexSoldier;

    public GameObject soldierDeath;
    void Start()
    {
        if(SoldierActiveInScene.instancia.soldiersStatus[indexSoldier].statusVida > 0)
        {
            soldierDeath.SetActive(true);
            this.enabled = false;
        }
    }

}
