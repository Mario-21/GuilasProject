using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerHere))]
public class DispositivoElectrico : MonoBehaviour
{
    public int indexMod;

    public int gastoElectrico;

    int once;
    bool luzOn;
    PlayerHere player;
    void Start()
    {
        player = GetComponent<PlayerHere>();
        luzOn = StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion;
        once = 1;
    }

    // Update is called once per frame
    void Update()
    {
        PressLuz();
    }
    void PressLuz()
    {
        if (Input.GetKeyDown(KeyCode.Z)) 
        {
            luzOn = !luzOn;
            once = 0;
            SwitchLuz();
        }
    }
    void SwitchLuz()
    {
        if (luzOn)
        {
            StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion = true;
            if (once < 1)
            {
                ExtraVariable.extras.valorGenerador += gastoElectrico;
                once++;
            }
        }
        else 
        {
            StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion = false;
            if (once < 1) 
            {
                ExtraVariable.extras.valorGenerador -= gastoElectrico;
                once++;
            }
        }
    }
}
