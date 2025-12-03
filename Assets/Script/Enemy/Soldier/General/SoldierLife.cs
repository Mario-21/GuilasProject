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
    public Animator animBody;
    public Animator animHead;

    SoldadoNormal soldado;
    int restarSoldados;

    [Header("CambiarLayer")]
    [SerializeField] LayerMask dormido;
    [SerializeField] GameObject cuerpo;

    Rigidbody2D rB2D;

    [Header("Enemy Sound Emitter")]
    public StudioEventEmitter sleepEmitter;
    public GameObject itemSleepEmissor;
    StudioEventEmitter stepsEmitter;

    [Header("Raycast Death")]
    [SerializeField] GameObject rayoInstancia;
    [SerializeField] float distanceRay;
    [SerializeField] LayerMask layerGround;
    bool rayCara;
    bool rayEspalda;

    private void Awake()
    {
        //Tipo de enemigo
        soldado = GetComponent<SoldadoNormal>();

        //Particulas de sueño
        particularDormir = GetComponentInChildren<ParticleSystem>();
        animBody = GetComponent<Animator>();

        status = GetComponent<ActualStatus>();

        rB2D = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        stepsEmitter = AudioManager.instancia.InitializeEventEmitter(FMODEvent.instancia.stepsEnemy, this.gameObject);

        sleepEmitter = AudioManager.instancia.InitializeEventEmitter(FMODEvent.instancia.sleepEnemy, itemSleepEmissor);

        //Setear la vidaMax Actual
        vidaMax = vida;

        //animBody.SetLayerWeight(1, 0);
        restarSoldados = 0;

        //Status Animacion (Antiguo)
        //animBody.SetInteger("Status Life", vida);

        //Si al entrar ya estoy muerto, tiene que saltar el audio sleep
        if(vida <= 0)
        {
            //  sleepEmitter.Play();
        }
    }
    void Update()
    {
        if (vida <= 0)
        {
            stepsEmitter.Stop();

            //Las capas solo lo tiene la antigua animacion
            //animBody.SetLayerWeight(1, 1);
            //Anula el estado de uno de los dos tipos de enemigos

            RestarSoldadoActivo();
            soldado.barra.SetActive(false);

            //Activar animacion de noqueo (Antiguo)
            //anim.SetBool("Sleeping", true);

            //Activa animacion muerte
            animBody.SetBool("Death", true);
            animHead.SetBool("Muerte", true);

            //Tras haber quedado dormmido tu layer cambia
            cuerpo.layer = 12;

            //Rigibody 2D
            rB2D.drag = 0;

            RaycastDeath();

        }
    }
    public void Daño(int daño)
    {
        animBody.SetTrigger("Herir");
        animHead.SetTrigger("Herida");
        vida -= daño;
        //status.indexCasco -= daño;
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
    public void DetenerBody()
    {
        rB2D.bodyType = RigidbodyType2D.Static;
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

    void RaycastDeath()
    {
       
        rayCara = Physics2D.Raycast(rayoInstancia.transform.position, Vector2.up, distanceRay, layerGround);

        rayEspalda = Physics2D.Raycast(rayoInstancia.transform.position, Vector2.down, distanceRay, layerGround);

        if(rayCara || rayEspalda)
        {
            Debug.Log("Cuerpo detenido");
            DetenerBody();
        }
    }
    private void OnDrawGizmos()
    {
        /*
        Gizmos.color = rayCara ? Color.green : Color.red;
        Gizmos.DrawLine(rayoInstancia.transform.position, rayoInstancia.transform.position + Vector3.up * distanceRay);

        Gizmos.color = rayEspalda ? Color.green : Color.red;
        Gizmos.DrawLine(rayoInstancia.transform.position, rayoInstancia.transform.position + Vector3.down * distanceRay);
        */
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ObjetoCaer") || collision.gameObject.CompareTag("B8"))
        {
            Daño(3);
            status.cascoSoldado.SetActive(false);
        }
    }



}
