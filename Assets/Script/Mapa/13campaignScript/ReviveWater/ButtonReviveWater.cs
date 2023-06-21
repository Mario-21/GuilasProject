using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonReviveWater : MonoBehaviour
{
    ReviveWater reviveWater;

    private void Start()
    {
        if(reviveWater == null)
        {
            reviveWater = FindObjectOfType<ReviveWater>();
        }
        
    }
    public void ButtonResetWater()
    {
        if(reviveWater != null)
        {
            reviveWater.ResetearWater();
        }
    }
}
