using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoAllergyBath : MonoBehaviour
{
    [Header("Soldier Info")]
    [SerializeField] SoldierLife laundrySoldierLife;
    [SerializeField] SoldadoNormal laundrySoldier;
    [Header("Allergy_Or_Bath")]
    [SerializeField] Allergy_Or_Bath allergy_Or_Bath;
    void Update()
    {
        ConditionsBathAllergy();
    }
    void ConditionsBathAllergy()
    {
        if(laundrySoldierLife.vida <= 0 || laundrySoldier.berserker)
        {
            allergy_Or_Bath.enabled = false;
        }
    }
}
