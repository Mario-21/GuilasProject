using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseControler : MonoBehaviour
{
    [Header("DataPausa")]
    [SerializeField] BloquearMovimientoPlayer bloqPause;

    int once;
    private void Awake()
    {
        bloqPause = FindObjectOfType<BloquearMovimientoPlayer>();
    }
    void Update()
    {
        TogglePause();
    }
    void TogglePause()
    {
        //Si el juego esta pausado
        if(Time.timeScale == 0)
        {
            bloqPause.PausarGame();

            once = 0;
        }
        else
        {
            if(once < 1)
            {
                //Activar Armas Solo si no estoy escondido
                bloqPause.ReanudarGame();

                once++;
            }
        }
    }
}
