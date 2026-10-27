using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Posion_Gas : MonoBehaviour
{
    [SerializeField] ChangeSkinPlayer playerSkin;
    public GameObject triggerGas;
    

    void Update()
    {
        GasPoisonDamage();
    }
    void GasPoisonDamage()
    {
        if(!playerSkin.putSkin)
        {
            triggerGas.SetActive(true);
        }
        else
        {
            triggerGas.SetActive(false);
        }
    }
}
