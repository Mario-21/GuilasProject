using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using FMODUnity;

public class SoldierLife : MonoBehaviour
{
    //Soldado normal 1;
    //Soldado Armadura 3;
    [Header("Vida Soldado Data")]
    public int vida;
    [HideInInspector] public int vidaMax;
    ActualStatus status;


    [Header("Animacion Dormir")]
    public ParticleSystem particularDormir;
    Animator anim;

    SoldadoNormal soldado;
    int restarSoldados;

    [Header("CambiarLayer")]
    [SerializeField] LayerMask dormido;
    [SerializeField]GameObject cuerpo;

    Rigidbody2D rB2D;

    [Header("Enemy Sound Emitter")]
    public StudioEventEmitter sleepEmitter;
    public GameObject itemSleepEmissor;
    StudioEventEmitter stepsEmitter;

    private void Awake()
    {
        //Tipo de enemigo
        soldado = GetComponent<SoldadoNormal>();

        //Particulas de sueño
        particularDormir = GetComponentInChildren<ParticleSystem>();
        anim = GetComponent<Animator>();

        status = GetComponent<ActualStatus>();

        rB2D = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        stepsEmitter = AudioManager.instancia.InitializeEventEmitter(FMODEvent.instancia.stepsEnemy, this.gameObject);

        sleepEmitter = AudioManager.instancia.InitializeEventEmitter(FMODEvent.instancia.sleepEnemy, itemSleepEmissor);

        //Setear la vidaMax Actual
        vidaMax = vida;

        anim.SetLayerWeight(1, 0);
        restarSoldados = 0;

        //Status Animacion
        anim.SetInteger("Status Life", vida);

        //Si al entrar ya estoy muerto, tiene que saltar el audio sleep
        if(vida <= 0)
        {
            sleepEmitter.Play();
        }
    }
    void Update()
    {
        if (vida <= 0)
        {
            stepsEmitter.Stop();

            anim.SetLayerWeight(1, 1);
            //Anula el estado de uno de los dos tipos de enemigos

            RestarSoldadoActivo();
            soldado.contorno.SetActive(false);

            //Activar animacion de noqueo
            anim.SetBool("Sleeping", true);

            //Tras haber quedado dormmido tu layer cambia
            cuerpo.layer = 12;

            //Rigibody 2D
            rB2D.drag = 0;

        }
    }
    public void Daño(int daño)
    {
        vida -= daño;
        status.indexCasco -= daño;
        //Ir guardando su vida
        DiferenciaVida();

    }
    public void DiferenciaVida()
    {
        if(vida != vidaMax)
        {
            AudioManager.instancia.PlayOneShot(FMODEvent.instancia.dañarEnemy);
            Debug.Log("Doer");
            SoldierActiveInScene.instancia.soldiersStatus[status.iD].statusVida = vida;
            vidaMax = vida;
        }
    }
    //Evento Animacion
    public void SleepingParticles()
    {
        sleepEmitter.Play();
        particularDormir.Play();
    }
    void RestarSoldadoActivo()
    {
        if (restarSoldados < 1)
        {
            if (soldado.berserker)
            {
                soldado.berserker = false;
                soldado.enabled = false;
            }
            else { soldado.enabled = false; }
            restarSoldados++;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ObjetoCaer"))
        {
            Daño(3);
        }
    }



}
