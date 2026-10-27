using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class GeneradorVentilador : MonoBehaviour
{
    [SerializeField] VentiladorBombilla estadoVentilador;
    [SerializeField] SpriteRenderer botonGenerador;
    [SerializeField] GameObject emisorGenerador;
    [SerializeField] bool sePuedeMojar;
    void Start()
    {
        
    }

    void Update()
    {
        if (estadoVentilador.onCeilingFan)
        {
            botonGenerador.color = Color.green;
            emisorGenerador.SetActive(true);

        }
        else
        {
            botonGenerador.color = Color.red;
            emisorGenerador.SetActive(false);
        }
    }
}
