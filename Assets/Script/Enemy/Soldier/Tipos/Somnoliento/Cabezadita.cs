using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cabezadita : MonoBehaviour
{
    public ParticleSystem particulasDormido;
    public SoldierLife soldadoLife;
    public Somnolencia somnolencia;
    public SoldadoNormal soldado;
    public void Dormir()
    {
        somnolencia.tiempoSomnoliento = 0;
        soldadoLife.sleepEmitter.Play();
        particulasDormido.Play();
    }
    public void Despertar()
    {
        soldadoLife.sleepEmitter.Stop();
        particulasDormido.Stop();
    }
    public void OnSoldado()
    {
        somnolencia.onSoldier = 1;
        soldado.siguienteUbi = soldado.maxTiempoUbi;
    }
}
