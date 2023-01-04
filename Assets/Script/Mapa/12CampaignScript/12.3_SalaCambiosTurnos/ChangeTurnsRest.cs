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
                MarcoColor();
            }
        }
    }
    void TurnoReset()
    {
        if(ExtraVariable.extras.turnosWork >= limitTurnos)
        {
            ExtraVariable.extras.turnosWork = 0;
            MarcoColor();
        }
    }
    void MarcoColor()
    {
        for (int i = 0; i < marcosTurns.Count; i++)
        {
            if (i == ExtraVariable.extras.turnosWork)
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
