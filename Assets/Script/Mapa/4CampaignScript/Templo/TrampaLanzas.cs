using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrampaLanzas : MonoBehaviour
{
    public int indexModTrampaOn;

    [Header("Duracion Trampas")]
    public float tiempoActivarTrampaLimite;
    float tiempoActivarTrampa;

    //Hacerlo por Estados con enum
    enum FasesTrampaLanzas
    {
        subir,
        esperar,
        bajar
    }
    FasesTrampaLanzas fasesTrampaLanzas;
    [SerializeField] bool activarTrampa;

    float originalPosition_y;
    void Start()
    {
        originalPosition_y = transform.position.y;
    }

    void Update()
    {
        
        if (StatusGameobjectsVariables.statusGameobject.modificacion[indexModTrampaOn].modificacion)
        {
            switch (fasesTrampaLanzas)
            {
                case FasesTrampaLanzas.subir:
                    TrampaLanzaActivada();
                    break;
                case FasesTrampaLanzas.esperar:
                    EsperarTrampaLanzas();
                    break;
                case FasesTrampaLanzas.bajar:
                    ResetearTrampa();
                    break;
            }
        }
        else { transform.position = new Vector3(transform.position.x, originalPosition_y, transform.position.z); }
        
    }
    void TrampaLanzaActivada()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y + 2f, transform.position.z);
        activarTrampa = true;
        fasesTrampaLanzas = FasesTrampaLanzas.esperar;
    }
    void ResetearTrampa()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y - 0.01f, transform.position.z);
        activarTrampa = false;
        if(transform.position.y <= originalPosition_y)
        {
            fasesTrampaLanzas = FasesTrampaLanzas.esperar;
        }
    }
    void EsperarTrampaLanzas()
    {
        tiempoActivarTrampa += Time.deltaTime;
        if(tiempoActivarTrampa >= tiempoActivarTrampaLimite)
        {
            if (activarTrampa)
            {
                fasesTrampaLanzas = FasesTrampaLanzas.bajar;
                tiempoActivarTrampa = 0;
            }
            else 
            {
                fasesTrampaLanzas = FasesTrampaLanzas.subir;
                tiempoActivarTrampa = 0;
            }
               
        }
    }
}
