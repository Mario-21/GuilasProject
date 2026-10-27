using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class EncenderTaladro : MonoBehaviour
{
    PlayerHere herePlayer;
    Interruptor interruptor;
    int taladroEjecuciones;
    [Header("Datos Soldado Enemigo")]
    [SerializeField] SoldierLife vidaSoldado;
    float tiempoSoldadoEncender;
    public float tiempoLimiteSoldadoEncender;
    bool enemyHere;
    //Quiza cambiar el static 

    [Header("Sound Effect")]
    [SerializeField] List <StudioEventEmitter> emisoresTaladros;
    [SerializeField] List<GameObject> cabezaTaladros;
    [SerializeField] EventReference drillOn;
    public int sonidoTaladro;

    private void Awake()
    {
        //encender = false;
        interruptor = GetComponent<Interruptor>();
        herePlayer = GetComponent<PlayerHere>();
    }
    private void Start()
    {
        for(int e = 0; e < emisoresTaladros.Count; e++)
        {
            emisoresTaladros[e] = AudioManager.instancia.InitializeEventEmitter(drillOn, cabezaTaladros[e]);
        }
    }
    void Update()
    {
        Funcionamiento_Taladro();
        Apagar_TaladroEnemy();
    }
    
    void Funcionamiento_Taladro()
    {
        //Encendido
        if (interruptor.estadoInterruptor)
        {
            Encender_TaladroVisual();
            Encender_SonidoTaldro();
        }
        //Apagado
        else
        {
            Apagar_TaladroVisual();
            Apagar_SonidoTaladro();
        }

    }
    void Encender_TaladroVisual()
    {
        if (taladroEjecuciones >= 1)
        {
            foreach (GameObject taladro in cabezaTaladros)
            {
                taladro.SetActive(true);
                Debug.Log("Cabezas Taladro dentro");
            }
            taladroEjecuciones--;
        }
    }
    void Apagar_TaladroVisual()
    {
        if(taladroEjecuciones < 1)
        {
            foreach(GameObject taladro in cabezaTaladros)
            {
                taladro.SetActive(false);
                Debug.Log("Cabezas Taladro fuera");
            }
            taladroEjecuciones++;
        }
    }
    void Apagar_SonidoTaladro()
    {
        if(sonidoTaladro < 1)
        {
            foreach (StudioEventEmitter emisor in emisoresTaladros)
            {
                emisor.Stop();
            }
            sonidoTaladro++;
        }
    }
    void Encender_SonidoTaldro()
    {
        if (sonidoTaladro >= 1)
        {
            foreach (StudioEventEmitter emisor in emisoresTaladros)
            {
                emisor.Play();
            }
            sonidoTaladro--;
        }
    }
    void Apagar_TaladroEnemy()
    {
        if (enemyHere)
        {
            if(vidaSoldado.vida > 0)
            {
                tiempoSoldadoEncender += Time.deltaTime;
                if (tiempoSoldadoEncender >= tiempoLimiteSoldadoEncender)
                {
                    interruptor.estadoInterruptor = false;
                }
            }

        }
        else
        {
            tiempoSoldadoEncender = 0;
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            enemyHere = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            enemyHere = false;
        }
    }

}
