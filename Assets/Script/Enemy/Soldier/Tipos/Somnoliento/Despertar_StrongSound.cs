using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Despertar_StrongSound : MonoBehaviour
{
    SoldadoNormal soldadoDormido;
    Somnolencia somnolenciaSoldado;
    SoldierLife soldierLife;

    [Header("Ubicaciones")]
    [SerializeField] Transform ubiSwitch;
    [SerializeField] Transform ubiOriginal;

    [Header("Time Despertar Data")]
    [SerializeField] float timeDespertarLimit;
    float timeDespertar;
    int onceAWake;

    private void Awake()
    {
        soldadoDormido = GetComponent<SoldadoNormal>();
        somnolenciaSoldado = GetComponent<Somnolencia>();
        soldierLife = GetComponent<SoldierLife>();
    }

    // Update is called once per frame
    void Update()
    {
        DespertarPorSonido();
    }
    void DespertarPorSonido()
    {
        if (EncenderTaladro.encender)
        {
            Despertar();
        }
        else
        {
            soldadoDormido.ubicacionesDirigir[0] = ubiOriginal;
            if(soldadoDormido.ubicacionesDirigir[0].position.x != transform.position.x)
            {

            }
            else
            {
                RegresarSleep();
            }
        }
        

    }
    void Despertar()
    {
        if(timeDespertar >= timeDespertarLimit)
        {
            //Change your direction guide you towards switch 
            soldadoDormido.ubicacionesDirigir[0] = ubiSwitch;
            //Somnolencia se desactiva
            somnolenciaSoldado.enabled = false;
            //Parar particulas y sonido 
            soldierLife.sleepEmitter.Stop();
            soldierLife.particularDormir.Stop();
            //Soldado Activar
            soldadoDormido.enabled = true;

            onceAWake = 0;

        }
        else
        {
            timeDespertar += Time.deltaTime;
        }
    }
    void RegresarSleep()
    {
        timeDespertar = 0;
        somnolenciaSoldado.enabled = true;
        soldadoDormido.enabled = false;

        if(onceAWake < 1)
        {
            somnolenciaSoldado.despierto = true;
            onceAWake++;
        }
    }
}
