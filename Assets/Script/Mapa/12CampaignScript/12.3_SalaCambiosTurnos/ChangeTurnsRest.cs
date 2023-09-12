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
        for (int i = 0; i < marcosTurns.Count; i++)
        {
            if (i == TurnosWorked.extras.turnosWork)
            {
                marcosTurns[i].color = Color.green;
            }
            else
            {
                marcosTurns[i].color = Color.red;
            }
        }
    }
}
