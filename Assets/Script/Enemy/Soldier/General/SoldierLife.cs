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
    int vidaMax;
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

    StudioEventEmitter emitterSteps;

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
        emitterSteps = AudioManager.instancia.InitializeEventEmitter(FMODEvent.instancia.stepsEnemy, this.gameObject);

        //Setear la vidaMax Actual
        vidaMax = vida;

        anim.SetLayerWeight(1, 0);
        restarSoldados = 0;

        //Status Animacion
        anim.SetInteger("Status Life", vida);
    }

    
    void Update()
    {

        if(vida <= 0)
        {
            emitterSteps.Stop();

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
            SoldierActiveInScene.instancia.soldiersStatus[status.iD].statusVida = vida;
            vidaMax = vida;
        }
    }
    public void SleepingParticles()
    {
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
