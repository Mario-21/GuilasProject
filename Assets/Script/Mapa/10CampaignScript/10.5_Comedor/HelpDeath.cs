using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelpDeath : MonoBehaviour
{
    public int indexMod;

    [Header("Soldados Help")]
    public int indexSoldado1;
    public GameObject soldado1;
    public int indexSoldado2;
    public GameObject soldado2;

    [HideInInspector] public bool soldierExit;
    void Awake()
    {
        //Si el veneno se activa y los dos tios estan vivo significara que se habrán ido con el soldado envenenado
        if (StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion)
        {
            if(SoldierActiveInScene.instancia.soldiersStatus[indexSoldado1].statusVida > 0 &&
               SoldierActiveInScene.instancia.soldiersStatus[indexSoldado2].statusVida > 0)
            {
                soldado1.SetActive(false);
                soldado2.SetActive(false);
                ExtraVariable.extras.helpSoldados = true;
            }
        }
    }
}
