using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelpDeath : MonoBehaviour
{
    public int indexModVenenoGlass;
    public int indexModHelp;

    [Header("Soldados Help")]
    public int indexSoldado1;
    public GameObject soldado1;
    public int indexSoldado2;
    public GameObject soldado2;

    [HideInInspector] public bool soldierExit;
    void Start()
    {
        //Si el veneno se activa y los dos tios estan vivo significara que se habrán ido con el soldado envenenado
        if (StatusGameobjectsVariables.statusGameobject.modificacion[indexModVenenoGlass].modificacion)
        {
            if(SoldierActiveInScene.instancia.soldiersStatus[indexSoldado1].statusVida > 0 &&
               SoldierActiveInScene.instancia.soldiersStatus[indexSoldado2].statusVida > 0 ||
               StatusGameobjectsVariables.statusGameobject.modificacion[indexModHelp].modificacion)
            {
                soldado1.SetActive(false);
                soldado2.SetActive(false);
            }
        }
    }
}
