using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerHere))]
public class Interruptor : MonoBehaviour
{
    [Header("Atributos del Interruptor")]
    [SerializeField] SpriteRenderer interruptor;
    [SerializeField] Sprite onSwitch;
    [SerializeField] Sprite offSwitch;

    [Header("Estado del Interruptor")]
    [SerializeField] bool estadoInterruptor;
    [SerializeField] SpriteRenderer luzEstadoSwitch;

    PlayerHere player;
    void Start()
    {
        player = GetComponent<PlayerHere>();
        StatusSwitch();
    }

    // Update is called once per frame
    void Update()
    {
        ChangeSwitch();
    }
    void ChangeSwitch()
    {
        if (player.playerImHere)
        {
            if (Input.GetButtonDown("Action"))
            {
                AudioManager.instancia.PlayOneShot(FMODEvent.instancia.botonGeneral);
                switch (estadoInterruptor)
                {
                    case true:
                        interruptor.sprite = offSwitch;
                        estadoInterruptor = false;
                        luzEstadoSwitch.color = Color.red;
                        break;
                    case false:
                        interruptor.sprite = onSwitch;
                        estadoInterruptor = true;
                        luzEstadoSwitch.color = Color.green;
                        break;
                }
            }
        }
    }
    void StatusSwitch()
    {
        if (estadoInterruptor)
        {
            interruptor.sprite = onSwitch;
            luzEstadoSwitch.color = Color.green;
        }
        else
        {
            interruptor.sprite = offSwitch;
            luzEstadoSwitch.color = Color.red;
        }
    }
}
