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

    public float directionFlechas;
    void Update()
    {
        directionFlechas = ascensor.transform.position.y - ascensor.posiciones[ascensor.piso].position.y;
        ColoresIndicativos();
        ResetearColoresFlechas();
    }
    void ColoresIndicativos()
    {
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
    }
    void ResetearColoresFlechas()
    {
        //Cuando la plataforma llega a su destino las flechas se apagan
        if (!ascensor.movimiento)
        {
            flecha_Down.color = colorStandar;
            flecha_Up.color = colorStandar;
        }
    }
}
