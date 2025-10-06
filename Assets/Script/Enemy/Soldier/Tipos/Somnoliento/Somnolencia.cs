using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Somnolencia : MonoBehaviour
{
    public ParticleSystem particulasDormido;
    SoldadoNormal soldado;
    SoldierLife soldierLife;
    public int onSoldier;

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

    public bool despierto;
    int soundSleep;

    private void Awake()
    {
        soldado = GetComponent<SoldadoNormal>();
        soldierLife = GetComponent<SoldierLife>();
        despierto = true;
    }
    private void Start()
    {
        if (!soldado.berserker)
        {
            soldado.animHead.SetBool("Idle_Somnoliento", true);
        }
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
                    //Si estoy parado que active el estado de somnolencia
                    if (!soldado.movimiento)
                    {
                        Somnoliento();
                    }
                    //Si estoy moviendo que cambie el aspecto y no este en el estado de Somnolineto
                    else
                    {
                        soldado.animHead.SetBool("Idle_Somnoliento", true);
                    }
                    break;
                case SleepMode.Sleep:
                    Dormido();
                    break;
            }
        }
        else if (soldado.berserker)
        {
            soldado.animHead.SetBool("Somnolencia", false);
            soldado.animHead.SetBool("Idle_Somnoliento", false);
            ChangePatrolMov();
            particulasDormido.Stop();
            soldado.enabled = true;
            this.enabled = false;
            if (soundSleep < 1)
            {
                if (soldierLife.vida > 0) soldierLife.sleepEmitter.Stop();
                soundSleep++;
            }
        }

        if (soldado.busquedaMode)
        {
            soldado.animHead.SetBool("Somnolencia", false);
        }
    }

    void Somnoliento()
    {
        //Despierto
        if (despierto) 
        {
            soldado.animHead.SetBool("Idle_Somnoliento", false);
            soldado.animHead.SetBool("Somnolencia", true);
            tiempoDespierto += Time.deltaTime; 
            tiempoSomnoliento = 0;
            soldado.animHead.SetBool("Dormido", false);
            if (onSoldier > 0) { soldado.enabled = true; onSoldier = 0; }
        }
        //Dormido
        else 
        { 
            tiempoSomnoliento += Time.deltaTime;
            tiempoDespierto = 0;
            soldado.animHead.SetBool("Dormido", true);
        }

        //Te duermes, tiempo que requieres para entrar en el modo dormido
        if (tiempoDespierto >= tiempoLimiteDespierto) 
        {
            //soldierLife.sleepEmitter.Play();
            //particulasDormido.Play();
            //Apaga la animacion de caminar
            soldado.OutAnimation();
            //Desactiva al soldado
            soldado.enabled = false; 
            despierto = false;
        }

        //Te despiertas, tiempo que requieres para entrar en el modo somnoliento
        if (tiempoSomnoliento >= tiempoLimiteSomnoliento) 
        {
            despierto = true;
        }
    }
    void Dormido()
    {
        //particulasDormido.Play();
        soldado.animHead.SetBool("Dormido", true);
        soldado.OutAnimation();
        soldado.enabled = false;
        /*
        if(soundSleep < 1)
        {
            soldierLife.sleepEmitter.Play();
            soundSleep++;
        }
        */
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
            soldado.animHead.SetBool("Somnolencia", false);
            soldado.animHead.SetBool("Muerte", true);
            this.enabled = false;
        }
    }
}
