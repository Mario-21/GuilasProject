using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeTurnsRest : MonoBehaviour
{
    public int limitTurnos; 
    PlayerHere player;
    void Start()
    {
        player = GetComponent<PlayerHere>();
    }

    // Update is called once per frame
    void Update()
    {
        Demo_Turnos turnosCambio = new Demo_Turnos();
        turnosCambio.ChangeTurnos(ExtraVariable.extras.turnosWork);

        PressButtonChangeTurn();
        TurnoReset();
    }
    void PressButtonChangeTurn()
    {
        if (player.playerImHere)
        {
            if (Input.GetKeyDown(KeyCode.Z))
            {
                ExtraVariable.extras.turnosWork++;
            }
        }
    }
    void TurnoReset()
    {
        if(ExtraVariable.extras.turnosWork >= limitTurnos)
        {
            ExtraVariable.extras.turnosWork = 0;
        }
    }
}
