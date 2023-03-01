using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallDamage : MonoBehaviour
{
    [Header("Player Vida")]
    public VidaPlayer vida;
    public int vidaTotalBase;
    [Header("Altura Limite")]
    public int alturaDeath;
    [Header("Registro Antiguo Altura")]
    public float registroLastAltura;
    public int registroLast;
    [Header("Registro Nuevio Altura")]
    public float registroNewAltura;
    public int registroNew;
    [Header("Altura Total")]
    public float alturaTotalCalculo;
    [Header("Porcentaje Daño")]
    public float porcentajeDaño;
    [Header("Daño ")]
    public int daño;

    JugadorMovimiento playerMov;

    

    private void Awake()
    {
        playerMov = GetComponent<JugadorMovimiento>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RegistrarAlturas();
        CalcularAlturaTotal();
        CalcularDaño();
    }
    void RegistrarAlturas()
    {
        if (playerMov.onGround)
        {
            registroNewAltura = transform.position.y;
            CalcularAlturaTotal();
            registroLast = 0;
        }
        else
        {
            //almacenara la al
            if (registroLast < 1)
            {
                registroLastAltura = transform.position.y;
                registroLast++;
            }

        }
    }
    void CalcularAlturaTotal()
    {
        alturaTotalCalculo = registroLastAltura - registroNewAltura;
    }
    void CalcularDaño()
    {
        if(alturaTotalCalculo > 5)
        {
            Debug.Log("Damage por altura");
            porcentajeDaño = (alturaTotalCalculo * 100) / alturaDeath;

            daño = ((int)porcentajeDaño * vidaTotalBase) / 100;

            vida.Daño(daño);

            alturaTotalCalculo = 0;

        }
    }
}
