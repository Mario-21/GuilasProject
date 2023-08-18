using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class TrampaDardos : MonoBehaviour
{
    public int indexModTrampasOn;
    [Header("Datos Dardos")]
    public float tiempoSpawnDardoLimite;
    public float velocidadDardo;
    [SerializeField] GameObject dardo;
    [SerializeField] Transform spawnDardo;
    float tiempoSpawnDardo;

    [SerializeField] bool rapido;

    StudioEventEmitter emissorDardo;
    int reproduceAudio;

    private void Start()
    {
        emissorDardo = AudioManager.instancia.InitializeEventEmitter(FMODEvent.instancia.dardoShoot, this.gameObject);
    }
    void Update()
    {
        if (StatusGameobjectsVariables.statusGameobject.modificacion[indexModTrampasOn].modificacion)
        {
            DispararDardo();
        }
    }

    void DispararDardo()
    {
        if(tiempoSpawnDardo >= tiempoSpawnDardoLimite)
        {
            //Probar el playOneShot con un emissor
            if (reproduceAudio < 1) emissorDardo.Play();
            GameObject dardoClone = Instantiate(dardo, spawnDardo.position, Quaternion.Euler(new Vector3(0,0,-90f)));
            if(rapido) velocidadDardo = Random.Range(15, 20);
            else velocidadDardo = Random.Range(9,10);
            dardoClone.GetComponent<Rigidbody2D>().AddForce(transform.right * velocidadDardo, ForceMode2D.Impulse);
            tiempoSpawnDardo = 0;
        }
        else
        {
            tiempoSpawnDardo += Time.deltaTime;
            reproduceAudio = 0;
        }
    }
}
