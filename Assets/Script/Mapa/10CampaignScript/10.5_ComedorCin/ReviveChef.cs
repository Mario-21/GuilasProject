using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReviveChef : MonoBehaviour
{
    public int indexChef;
    void Start()
    {
        if (!ExtraVariable.extras.soldadosDeathComedor)
        {
            SoldierActiveInScene.instancia.soldiersStatus[indexChef].statusVida = 1;
            Debug.Log("Revive");
        }
        else
        {
            SoldierActiveInScene.instancia.soldiersStatus[indexChef].statusVida = 0;
        }
    }
}
