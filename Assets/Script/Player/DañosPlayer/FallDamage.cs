using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallDamage : MonoBehaviour
{
    [Header("Player Vida")]
    public int vidaTotalBase;
    [Header("Altura Limite")]
    public int alturaDeath;
    public float alturaStartDaño;
    [Header("Registro Antiguo Altura")]
    float registroAireAltura;
    int registroAire;
    [Header("Registro Nuevio Altura")]
    float registroSueloAltura;
    int registroSuelo;
    [Header("Altura Total")]
    float alturaTotalCalculo;
    [Header("Porcentaje Daño")]
    float porcentajeDaño;
    [Header("Daño ")]
    int daño;
    int registroDaño;

    VidaPlayer vida;
    JugadorMovimiento playerMov;
    Rigidbody2D rg2DPlayer;
    Stairs_Hidden stairsPlayer;

    

    private void Awake()
    {
        stairsPlayer = GetComponent<Stairs_Hidden>();
        rg2DPlayer = GetComponent<Rigidbody2D>();
        playerMov = GetComponent<JugadorMovimiento>();
        vida = GetComponent<VidaPlayer>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Si yo no he tocado el agua y además no estoy usando una escalera, se puede calcular el registro de la altura y el daño del mismo
        if (!stairsPlayer.escalar && !playerMov.onWater) 
        {
            RegistrarAlturas();
        }
        //Si una de estas acciones se da no puedes calcular el daño, debido a que si usas las escaleras no se considera que te estas cayendo si lo estas usando. A su vez si caes al agua,
        //esta misma te frena por lo que no te hara daño
        else
        {
            //Resetea el registroAire para que vuelva a calcular el daño, ya que las escaleras te frenan
            //Cuando toco el agua tambien debe resetea el aire
            registroAire = 0;
        }
    }
    void RegistrarAlturas()
    {
        if (playerMov.onGround)
        {
            registroSueloAltura = transform.position.y;
            CalcularAlturaTotal();
            registroAire = 0;
            if(registroDaño < 1)
            {
                CalcularDaño();
                registroDaño++;
            }
        }
        else
        {
            //Deberia almacenar la altura una vez el personaje comience a caer, ya que es la altura máxima que ha llegado
            if (registroAire < 1)
            {
                //Si la velocidad es negativa, significa que estas cayendo
                if(rg2DPlayer.velocity.y < 0)
                {
                    registroAireAltura = transform.position.y;
                    //valor para volver a calcular el daño se resetea aqui
                    registroDaño = 0;
                    registroAire++;
                }
            }

        }
    }
    void CalcularAlturaTotal()
    {
        alturaTotalCalculo = registroAireAltura - registroSueloAltura;
    }
    void CalcularDaño()
    {
        //5 metros es demasiado
        if(alturaTotalCalculo > alturaStartDaño)
        {
            Debug.Log("Damage por altura");
            //Primero calcula el porcentaje del daño que te va hacer la caída
            porcentajeDaño = (alturaTotalCalculo * 100) / alturaDeath;
            //Segundo te calcula el daño de dicho porcentaje
            daño = ((int)porcentajeDaño * vidaTotalBase) / 100;
            //Tercero te hace el daño
            vida.Daño(daño);
        }
    }
}
