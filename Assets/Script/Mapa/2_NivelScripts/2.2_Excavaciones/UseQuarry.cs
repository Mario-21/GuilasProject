using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class UseQuarry : MonoBehaviour
{
    PlayerHere player;
    public AscensorMinero ascensor;

    void Start()
    {
        player = GetComponent<PlayerHere>();
    }

    void Update()
    {
        UsarQuarry();
    }
    void UsarQuarry()
    {
        Debug.Log("Ascensor posiciones " + ascensor.posiciones.Length);
        if (player.playerImHere)
        {
            if (Input.GetButtonDown("Action"))
            {
                AudioManager.instancia.PlayOneShot(FMODEvent.instancia.botonGeneral);
                if(ascensor.piso < ascensor.posiciones.Length - 1)
                {
                    ascensor.piso++;
                }
                else if (ascensor.piso >= ascensor.posiciones.Length - 1)
                {
                    ascensor.piso = 0;
                }
                
            }
            
        }
    }
}
