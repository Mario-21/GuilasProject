using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class FocoRoto : MonoBehaviour
{
    [Header("Datos Objeto Foco")]
    [SerializeField] GameObject luzFoco;
    public float repeticionParpadeo;
    public GameObject focoObject;
    [Header("Sonido del Foco")]
    [SerializeField] EventReference sonidoLuz;

    StudioEventEmitter emissorFoco;
    Animator animatorFoco;
    void Start()
    {
        emissorFoco = AudioManager.instancia.InitializeEventEmitter(sonidoLuz, focoObject);
        animatorFoco = GetComponent<Animator>();

        InvokeRepeating("ParpadeosPorSegundo", 4f, repeticionParpadeo);
    }
    void ParpadeosPorSegundo()
    {
        //quiza puedo colocarlo en la animacion el sonido mediante un evento 
        animatorFoco.SetTrigger("Parpadeo");
        //Nota: quiero comprobar si con el oneshot puedo alejar al jugador y hacer que se vaya alejando el sonido.
        //con la opcion del Fmod. Porque si esto no funciona reproducira de manera continua el sonido siempre con el mismo
        //volumen, independiente de la distancia del jugador
        //Sino colocar el sonido en emitter y probar.
    }
    public void ParpadeoSound()
    {
        emissorFoco.Play();
    }
}
