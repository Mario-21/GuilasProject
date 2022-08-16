using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        if (player.playerImHere)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                ascensor.interruptorBajar = !ascensor.interruptorBajar;
            }
            
        }
    }
}
