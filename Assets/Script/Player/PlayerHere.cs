using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHere : MonoBehaviour
{
     public bool playerImHere;
    /*NOTA: El segundo tag existe para evitar que bug con el sonido del escondite y la entrada a cinematicas con el uso de cajas.
     El problema yace en que como el Player tiene ciertos Trigger que detectan cosas externas, el suelo, el agua, un objeto que te puedas poner como ropa;
     genera que el personaje tenga un collider mayor, lo que permite a los suso dichos anteriormente detectarlos, pero sin establecer los cambios debidos,
     no reproducir bien un sonido, no entrar a una cinemática. 
     La solución más optima que se me ha ocurrido es hacer que este script detecte un segundo tag, esto en parte es para evitar que si tu colocas el tag; Player
     en los trigger detectores, el Player reciba más daño del debido. Por eso la implementacion de un nuevo tag.*/
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) playerImHere = true;
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) playerImHere = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) 
        {
            playerImHere = false; 
            //Debug.Log("El player ha salido del trigger");
        }
    }

}
