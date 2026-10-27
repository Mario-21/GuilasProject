using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrasladarWithValvula : MonoBehaviour
{
    [Header("Drenaje")]
    public int indexDrenaje;
    public int indexDrenajeDown;
    [Header("Agua Trasladada")]
    public int indexAgua;

    Valvula valvula;
    float cooldownSumaPercent;
    public float cooldownSumaPercentLimit;
    bool cooldownOn;
    PlayerHere player;
    private void Awake()
    {
        valvula = GetComponent<Valvula>();
        player = GetComponent<PlayerHere>();
    }
    private void Start()
    {
        cooldownSumaPercentLimit = valvula.timeLimitValvula;
    }
    void Update()
    {
        if (player.playerImHere) 
        {
            if (Input.GetButtonDown("Action"))
            {
                if (StatusGameobjectsVariables.statusGameobject.modificacion[indexDrenaje].modificacion && !StatusGameobjectsVariables.statusGameobject.modificacion[indexDrenajeDown].modificacion && !cooldownOn)
                {
                    ListWaters.listWaters.infoAguas[indexAgua].porcentajeAgua += (int)valvula.porcentajeAgua;
                    cooldownOn = true;
                    
                }
            }
        }
        if (cooldownOn)
        {
            if(cooldownSumaPercent < cooldownSumaPercentLimit)
            {
                cooldownSumaPercent += Time.deltaTime;
            }
            else
            {
                cooldownOn = false;
            }
        }
        else
        {
            cooldownSumaPercent = 0;
        }
    }
}
