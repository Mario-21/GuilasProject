using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReviveLiquidButton : MonoBehaviour
{
    public ReviveLiquid reviveLiquid;
    void Start()
    {
        if(reviveLiquid == null)
        {
            reviveLiquid = FindObjectOfType<ReviveLiquid>();
        }
    }

    public void LiquidReviveButton()
    {
        if (reviveLiquid != null) 
        {
            reviveLiquid.LiquidRevivir();
        }
    }
}
