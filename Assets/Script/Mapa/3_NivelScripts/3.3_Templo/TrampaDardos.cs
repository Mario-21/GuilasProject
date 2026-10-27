using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class TrampaDardos : MonoBehaviour
{
    public int indexModTrampasOn;
    [Header("Modo Disparo")]
    public ModoDisparo modoDisparo;
    public enum ModoDisparo
    {
        Normal,
        Doble,
        Triple,
        No_Disparo
    }
    [Header("Datos Dardos")]
    public float tiempoSpawnDardo;
    public float tiempoSpawnDardoLimite;
    [SerializeField] GameObject dardo;
    [SerializeField] Transform spawnDardo;
    [Header("Velocidad y Direccion Dardos")]
    public float velocidadDardo;
    [Range(-1, 1)]
    public int direccionflecha = 1;
    [Header("Datos Disparo Multiple")]
    public int numeroDisparosTotales;
    int numeroDisparos;
    public float tiempoEntreDisparosLimite;
    float tiempoEntreDisparos;

    StudioEventEmitter emissorDardo;
    int reproduceAudio;
    private void Start()
    {
        emissorDardo = AudioManager.instancia.InitializeEventEmitter(FMODEvent.instancia.dardoShoot, this.gameObject);
    }
    void FixedUpdate()
    {
        if (StatusGameobjectsVariables.statusGameobject.modificacion[indexModTrampasOn].modificacion)
        {
            if (tiempoSpawnDardo >= tiempoSpawnDardoLimite)
            {
                TipoDisparo();
            }
            else
            {
                tiempoSpawnDardo += Time.deltaTime;
                reproduceAudio = 0;
                numeroDisparos = 0;
            }
        }
    }
    void TipoDisparo()
    {
        switch (modoDisparo)
        {
            case ModoDisparo.Normal:
                DispararDardo();
                tiempoSpawnDardo = 0;
                break;
            case ModoDisparo.Doble:
                MultiplesDisparos();
                break;
            case ModoDisparo.Triple:
                MultiplesDisparos();
                break;
            case ModoDisparo.No_Disparo:
                Debug.Log("Esta Roto");
                break;
        }
    }
    void DispararDardo()
    {
        //Probar el playOneShot con un emissor
        int reproAudio = 0;
        ReproducirSonidoDardo(reproAudio);
        //if (reproduceAudio < 1) emissorDardo.Play();
        GameObject dardoClone = Instantiate(dardo, spawnDardo.position, Quaternion.identity);
        //if(rapido) velocidadDardo = Random.Range(15, 20);
        //else velocidadDardo = Random.Range(9,10);
        dardoClone.GetComponent<Transform>().localScale = new Vector3(1, direccionflecha, 1);
        dardoClone.GetComponent<Rigidbody2D>().AddForce(transform.right * velocidadDardo * direccionflecha, ForceMode2D.Impulse);
    }
    void ReproducirSonidoDardo(int numReproAudio)
    {
        if (numReproAudio < 1) 
        {
            emissorDardo.Play();
            Debug.Log("Audio Reproducido con exito");
        }
    }
    void MultiplesDisparos()
    {
        if (tiempoEntreDisparos >= tiempoEntreDisparosLimite)
        {
            DispararDardo();
            tiempoEntreDisparos = 0;
            numeroDisparos++;
        }
        else
        {
            tiempoEntreDisparos += Time.deltaTime;
        }
        if (numeroDisparos >= numeroDisparosTotales)
        {
            tiempoSpawnDardo = 0;
        }
        
    }
}
