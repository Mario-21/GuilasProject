using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flechas_Indicativas_Ascensor : MonoBehaviour
{
    [Header("Ascensor Seleccionado")]
    [SerializeField] AscensorMinero ascensor;
    [Header("Flechas Indicativas")]
    [SerializeField] SpriteRenderer flecha_Up;
    [SerializeField] SpriteRenderer flecha_Down;
    [SerializeField] Color colorStandar;
    [SerializeField] Color colorIndicativo;

    float directionFlechas;
    void Update()
    {
        ColoresIndicativos();
    }
    void ColoresIndicativos()
    {
        directionFlechas = transform.position.y - ascensor.posiciones[ascensor.piso].position.y;
        //Cuando la plataforma comience a moverse se enciende la flecha en base a donde te  diriges
        if (ascensor.movimiento)
        {
            //EStas subiendo
            if (directionFlechas < 0)
            {
                flecha_Up.color = colorIndicativo;
                flecha_Down.color = colorStandar;
            }
            //Estoy bajando
            else
            {
                flecha_Down.color = colorIndicativo;
                flecha_Up.color = colorStandar;
            }
        }
        //Cuando la plataforma llega a su destino las flechas se apagan
        else
        {
            flecha_Down.color = colorStandar;
            flecha_Up.color = colorStandar;
        }

    }
}
