using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cin_Tuto_Esconderse : MonoBehaviour
{
    public int indexMod;

    [Header("Estado Cinemática")]
    public CinTutoEsconderse secuenciaEsconderse;
    public enum CinTutoEsconderse
    {
        Inicial,
        VerEnemigo,
        DirigirCaja,
        IconoYEsconderse,
        Enemigo,
        Default
    }

    [Header("Player Cin Datos")]
    [SerializeField] MovPlayerCin movPlayerCin;
    [SerializeField] HiddenPlayerCin hiddenPlayerCin;
    [SerializeField] Transform spawnIcon;
    [SerializeField] GameObject iconItemCin;

    [Header("Enemy Cin Datos")]
    [SerializeField] SoldadoNormal soldadoCin;

    [Header("Tiempo entre Escenas")]
    public float tiempoEscena;
    public float tiempoEscenaLimite;

    [Header("Tiempo de cada Escena")]
    [SerializeField] float inicial;
    [SerializeField] float verEnemigo;
    [SerializeField] float dirigirCaja;
    [SerializeField] float iconoYEsconderse;
    [SerializeField] float enemigo;


   
    void Start()
    {
        secuenciaEsconderse = CinTutoEsconderse.Inicial;
        if (StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion) this.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        SecuenciaTutoEsconderse();
    }
    void SecuenciaTutoEsconderse()
    {
        tiempoEscena += Time.deltaTime;
        switch (secuenciaEsconderse)
        {
            //Player en la misma ubicacion en la que se encuentra
            case CinTutoEsconderse.Inicial:
                Debug.Log("Stage Inicial");
                //Esperas a que cargue la escena unos segundos
                if (tiempoEscena >= inicial)
                {
                    secuenciaEsconderse = CinTutoEsconderse.VerEnemigo;
                    tiempoEscena = 0;
                }
                break;
            case CinTutoEsconderse.VerEnemigo:
                Debug.Log("Stage VerEnemigo");
                //Al player le salta un icono de una exclamacion para representar que ha visto al enemigo
                if (tiempoEscena >= verEnemigo)
                {
                    GameObject iconObjeto = Instantiate(iconItemCin, spawnIcon.position, Quaternion.identity);
                    AudioManager.instancia.PlayOneShot(FMODEvent.instancia.searchMode);
                    secuenciaEsconderse = CinTutoEsconderse.DirigirCaja;
                    tiempoEscena = 0;
                }
                break;
            case CinTutoEsconderse.DirigirCaja:
                Debug.Log("Stage DirigirCaja");
                //Player se espera unos segundos a que termine la animacion del icono
                if (tiempoEscena >= dirigirCaja)
                {
                    //Activa el movimiento del Player en cinematicas
                    movPlayerCin.enabled = true;
                    //Si has dejado de mover quiere decir que has llegado al objetivo
                    if (!movPlayerCin.movPlayerCin)
                    {
                        secuenciaEsconderse = CinTutoEsconderse.IconoYEsconderse;
                        tiempoEscena = 0;
                    }
                }
                break;
            case CinTutoEsconderse.IconoYEsconderse:
                Debug.Log("Stage EsperarIcono");
                //Player espera unos segundos para mostrar el icono
                if (tiempoEscena >= iconoYEsconderse)
                {
                    //Uno vez has esperado para mostrar el icono activas los script del HiddenPlayerCin
                    movPlayerCin.enabled = false;
                    hiddenPlayerCin.ocultoPlayerCin = true;
                    hiddenPlayerCin.SonidoYParticulaEsconderseCin();
                    secuenciaEsconderse = CinTutoEsconderse.Enemigo;
                    tiempoEscena = 0;
                }
                break;
            case CinTutoEsconderse.Enemigo:
                Debug.Log("Stage Esconderse");
                //Player se espera para que de un poco de tiempo a que el enemigo se active
                if (tiempoEscena >= enemigo)
                {
                    soldadoCin.enabled = true;
                    secuenciaEsconderse = CinTutoEsconderse.Default;
                    tiempoEscena = 0;
                }
                break;
            case CinTutoEsconderse.Default:
                StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion = true;
                break;
        }

    }
}
