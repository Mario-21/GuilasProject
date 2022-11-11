using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChefDeath : MonoBehaviour
{
    public int indexMod;

    public int indexChef;

    [SerializeField] Aparecer_DesAp_Obj chefAp_Des;
    private void Awake()
    {
        if (StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion)
        {
            if(SoldierActiveInScene.instancia.soldiersStatus[indexChef].statusVida > 0)
            {
                chefAp_Des.enabled = true;
            }
        }
    }

}
