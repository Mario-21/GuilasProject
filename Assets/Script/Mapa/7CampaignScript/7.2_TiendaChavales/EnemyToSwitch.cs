using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyToSwitch : MonoBehaviour
{
    [SerializeField] CeiilingFan ceiiling;
    [Header("Original Position")]
    [SerializeField] Transform originalPos;
    [Header("Switch Position")]
    [SerializeField] Transform switchPos;
    [Header("Soldier Switch")]
    [SerializeField] SoldadoNormal soldado;

    float timeCeilingFan;

    // Update is called once per frame
    void Update()
    {
        //The Soldier go to switch
        SoldierGoSwitch();
    }
    void SoldierGoSwitch()
    {
        if (!ceiiling.onCeilingFan)
        {
            timeCeilingFan += Time.deltaTime;
            if(timeCeilingFan >= 3)
            {
                soldado.ubicacionesDirigir[0] = switchPos;
            }
        }
        else
        {
            timeCeilingFan = 0;
            soldado.ubicacionesDirigir[0] = originalPos;
        }
        
    }
}
