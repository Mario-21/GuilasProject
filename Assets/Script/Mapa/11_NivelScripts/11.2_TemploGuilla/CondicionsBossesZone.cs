using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CondicionsBossesZone : MonoBehaviour
{
    public int indexSoldierBoss;

    public GameObject soldierBoss;
    void Start()
    {
        if (SoldierActiveInScene.instancia.soldiersStatus[indexSoldierBoss].statusVida > 0)
        {
            soldierBoss.SetActive(true);
        }
    }
}
