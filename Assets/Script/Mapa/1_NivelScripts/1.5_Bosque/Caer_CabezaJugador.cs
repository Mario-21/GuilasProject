using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMOD.Studio;
using FMODUnity;
public class Caer_CabezaJugador : MonoBehaviour
{
    // Start is called before the first frame update
    Caer_Cabeza caerJugadorCabeza;
    [Header("Datos Player")]
    [SerializeField] VidaPlayer playerVida;
    [Header("Datos Daño")]
    public float damage;
    void Start()
    {
        caerJugadorCabeza = GetComponentInParent<Caer_Cabeza>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //Estableces la variable
            StatusGameobjectsVariables.statusGameobject.modificacion[caerJugadorCabeza.indexModificar].modificacion = true;
            //Se visualiza el objeto caido en el suelo, mientras desaparece el que estaba cayendo
            caerJugadorCabeza.caidaObjeto.ObjetoInGround();
            //Sonido del impacto en la cabeza del player
            AudioManager.instancia.PlayOneShot(caerJugadorCabeza.impacto);
            //Quitas daño al jugador
            playerVida.Daño(damage);
        }
    }
}
