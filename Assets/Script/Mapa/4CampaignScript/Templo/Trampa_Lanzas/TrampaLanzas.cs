using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class TrampaLanzas : MonoBehaviour
{
    public int indexModTrampaOn;

    [Header("Duracion Trampas")]
    public float tiempoActivarTrampaLimite;
    [HideInInspector] public float tiempoActivarTrampa;
    [Header("Info Distancias Trampa")]
    [SerializeField] bool debugDistancia;
    //Hacerlo por Estados con enum
    enum FasesTrampaLanzas
    {
        subir,
        esperar,
        bajar
    }
    FasesTrampaLanzas fasesTrampaLanzas;
    [SerializeField] bool activarTrampa;
    public bool posOrigen;

    float originalPosition_y;
    [Header("Sound Effect Lanza")]
    [SerializeField] GameObject gearLanza;
    StudioEventEmitter emissorGear;
    int reproduceGear;
    StudioEventEmitter emissorLanza;
    void Start()
    {
        emissorLanza = AudioManager.instancia.InitializeEventEmitter(FMODEvent.instancia.spearActive, this.gameObject);
        emissorGear = AudioManager.instancia.InitializeEventEmitter(FMODEvent.instancia.spearGear, gearLanza);
        originalPosition_y = transform.position.y;
    }

    void Update()
    {
        if (debugDistancia)
        {
            Debug.Log("La distancia con respecto al punto de origen es " + DistanciaAOrigen());
        }
        //magnitudMeOrigen = DistanciaPosOrigen().magnitude;
        if (StatusGameobjectsVariables.statusGameobject.modificacion[indexModTrampaOn].modificacion)
        {
            IdentificarEstarPosOrigen();
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
        emissorLanza.Play();
        transform.position = new Vector3(transform.position.x, transform.position.y + 2f, transform.position.z);
        activarTrampa = true;
        fasesTrampaLanzas = FasesTrampaLanzas.esperar;
    }
    void ResetearTrampa()
    {
        activarTrampa = false;
        if(transform.position.y <= originalPosition_y)
        {
            fasesTrampaLanzas = FasesTrampaLanzas.esperar;
            reproduceGear = 0;
            //Punto Origen
            emissorGear.Stop();
        }
        else
        {
            transform.position = new Vector3(transform.position.x, transform.position.y - 0.01f, transform.position.z);
            if (reproduceGear < 1)
            {
                emissorGear.Play();
                reproduceGear++;
            }
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
    void IdentificarEstarPosOrigen()
    {
        if(DistanciaAOrigen() <= Mathf.Clamp(DistanciaAOrigen(), 0f, 0.005f))
        {
            posOrigen = true;
        }
        else
        {
            posOrigen = false;
        }
    }
    float DistanciaAOrigen()
    {
        float distanciaAOrigen;
        return distanciaAOrigen = Mathf.Abs(originalPosition_y - transform.position.y);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            AudioManager.instancia.PlayOneShot(FMODEvent.instancia.spearImpact);
        }
    }
}
