using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Somnolencia : MonoBehaviour
{
    public ParticleSystem particulasDormido;
    SoldadoNormal soldado;
    SoldierLife soldierLife;

    [Header ("Time Sleep")]
    public float tiempoLimiteSomnoliento;
    public float tiempoLimiteDespierto;
    public float tiempoSomnoliento;
    public float tiempoDespierto;

    [Header("ChangePatrol")]
    public List<Transform> ubis;
    
    [Header("Sleep Mode")]
    public SleepMode sleepMode;
    public enum SleepMode
    {
        Somnolent,
        Sleep
    }

    [HideInInspector] public bool despierto;
    int soundSleep;

    private void Awake()
    {
        soldado = GetComponent<SoldadoNormal>();
        soldierLife = GetComponent<SoldierLife>();
        despierto = true;
    }
    private void Start()
    {
        //Si me muero, da igual estas ejecuciones
        RemoveDeath();
    }
    void Update()
    {
        RemoveDeath();
        if (!soldado.berserker && !soldado.busquedaMode) 
        {
            switch (sleepMode)
            {
                case SleepMode.Somnolent:
                    Somnoliento();
                    break;
                case SleepMode.Sleep:
                    Dormido();
                    break;
            }
        }
        else if(soldado.berserker)
        {
            ChangePatrolMov();
            particulasDormido.Stop();
            soldado.enabled = true;
            this.enabled = false;
            if(soundSleep < 1)
            {
                if(soldierLife.vida > 0) soldierLife.sleepEmitter.Stop();
                soundSleep++;
            }
        }
    }

    void Somnoliento()
    {
        //Despierto
        if (despierto) {tiempoDespierto += Time.deltaTime; tiempoSomnoliento = 0; }
        //Dormido
        else { tiempoSomnoliento += Time.deltaTime; tiempoDespierto = 0; }

        //Te duermes
        if (tiempoDespierto >= tiempoLimiteDespierto) 
        {
            soldierLife.sleepEmitter.Play();
            particulasDormido.Play();
            //Apaga la animacion de caminar
            soldado.OutAnimation();
            //Desactiva al soldado
            soldado.enabled = false; 
            despierto = false;
        }

        //Te despiertas
        if (tiempoSomnoliento >= tiempoLimiteSomnoliento) 
        {
            soldierLife.sleepEmitter.Stop();
            particulasDormido.Stop();
            soldado.enabled = true;
            despierto = true;
        }
    }
    void Dormido()
    {
        particulasDormido.Play();
        soldado.OutAnimation();
        soldado.enabled = false;
        if(soundSleep < 1)
        {
            soldierLife.sleepEmitter.Play();
            soundSleep++;
        }
    }
    void ChangePatrolMov()
    {
        soldado.ubicacionesDirigir.Clear();
        for (int i = 0; i < ubis.Count; i++)
        {
            soldado.ubicacionesDirigir.Add(ubis[i]);
        }
    }
    void RemoveDeath()
    {
        if (soldierLife.vida <= 0)
        {
            this.enabled = false;
        }
    }
}
