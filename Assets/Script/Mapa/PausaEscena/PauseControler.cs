using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseControler : MonoBehaviour
{
    [Header("DataPausa")]
    [SerializeField] BloquearMovimientoPlayer bloqPause;

    public int once;
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
        Debug.Log("Toggle");
        if (Time.timeScale == 0)
        {
            bloqPause.PausarGame();
            once = 0;
            Debug.Log("Cero");
        }
        else
        {
            if(once < 1)
            {
                //Activar Armas Solo si no estoy escondido
                Debug.Log("Guau");
                bloqPause.ReanudarGame();
                once++;
            }
        }
    }
}
