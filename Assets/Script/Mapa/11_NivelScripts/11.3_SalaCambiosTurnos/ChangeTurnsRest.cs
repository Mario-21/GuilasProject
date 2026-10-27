using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerHere))]
public class ChangeTurnsRest : MonoBehaviour
{
    public int limitTurnos; 
    PlayerHere player;

    [SerializeField] List<SpriteRenderer> marcosTurns;
    void Start()
    {
        player = GetComponent<PlayerHere>();
        MarcoColor();
    }

    // Update is called once per frame
    void Update()
    {
        Demo_Turnos turnosCambio = new Demo_Turnos();
        turnosCambio.ChangeTurnos(TurnosWorked.extras.turnosWork);

        PressButtonChangeTurn();
        TurnoReset();
    }
    void PressButtonChangeTurn()
    {
        if (player.playerImHere)
        {
            if (Input.GetButtonDown("Action"))
            {
                AudioManager.instancia.PlayOneShot(FMODEvent.instancia.botonGeneral);
                TurnosWorked.extras.turnosWork++;
                MarcoColor();
            }
        }
    }
    void TurnoReset()
    {
        if(TurnosWorked.extras.turnosWork >= limitTurnos)
        {
            TurnosWorked.extras.turnosWork = 0;
            MarcoColor();
        }
    }
    void MarcoColor()
    {
        switch (TurnosWorked.extras.turnosWork)
        {
            case 0:
                //Turno_0 = A y B en verde, C en rojo.
                //A
                marcosTurns[0].color = Color.green;
                //B
                marcosTurns[1].color = Color.green;
                //C
                marcosTurns[2].color = Color.red;
                break;
            case 1:
                //Turno_1 = A y C en verde, B en rojo.
                //A
                marcosTurns[0].color = Color.green;
                //B
                marcosTurns[1].color = Color.red;
                //C
                marcosTurns[2].color = Color.green;
                break;
            case 2:
                //Turno_2 = C y B en verde, A en rojo
                //A
                marcosTurns[0].color = Color.red;
                //B
                marcosTurns[1].color = Color.green;
                //C
                marcosTurns[2].color = Color.green;
                break;
        }
    }
}
