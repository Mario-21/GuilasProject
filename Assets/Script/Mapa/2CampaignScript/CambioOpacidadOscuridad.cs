using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CambioOpacidadOscuridad : MonoBehaviour
{
    public SpriteRenderer item;
    public Color opacidadColorPersonalizado;

    bool cambiaOpacidad;

    private void Update()
    {
        if (cambiaOpacidad)
        {
            item.color = opacidadColorPersonalizado;
            this.enabled = false;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            cambiaOpacidad = true;
        }
    }
}
