using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReviveChef : MonoBehaviour
{
    public int indexDeathComedor;
    public int indexChef;
    void Start()
    {
        if (!StatusGameobjectsVariables.statusGameobject.modificacion[indexDeathComedor].modificacion)
        {
            SoldierActiveInScene.instancia.soldiersStatus[indexChef].statusVida = 1;
            SoldierActiveInScene.instancia.soldiersStatus[indexChef].berserkerStatus = false;
            Debug.Log("Revive");
        }
        else
        {
            SoldierActiveInScene.instancia.soldiersStatus[indexChef].statusVida = 0;
        }
    }
}
