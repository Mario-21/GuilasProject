using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Somnolencia : MonoBehaviour
{
    public ParticleSystem particulasDormido;
    SoldadoNormal soldado;

    [Header ("Time Sleep")]
    public float tiempoLimiteSomnoliento;
    public float tiempoLimiteDespierto;
    float tiempoSomnoliento;
    float tiempoDespierto;

    [Header("ChangePatrol")]
    public List<Transform> ubis;
    
    [Header("Sleep Mode")]
    public SleepMode sleepMode;
    public enum SleepMode
    {
        Somnolent,
        Sleep
    }

    bool despierto;

    private void Awake()
    {
        soldado = GetComponent<SoldadoNormal>();
        despierto = true;
    }
    
    void Update()
    {
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
    }
    void ChangePatrolMov()
    {
        soldado.ubicacionesDirigir.Clear();
        for (int i = 0; i < ubis.Count; i++)
        {
            soldado.ubicacionesDirigir.Add(ubis[i]);
        }
    }
}
