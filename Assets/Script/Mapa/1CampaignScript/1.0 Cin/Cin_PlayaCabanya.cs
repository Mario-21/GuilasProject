using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using FMODUnity;
public class Cin_PlayaCabanya : MonoBehaviour
{
    public int indexMod;
    public CinemachineVirtualCamera vCamMain;
    public float sizeCamera;
    float tiempo;
    [SerializeField] float tiempoEntreEscenas;
    public SecuenciaPlayaCabanya secuenciaPlayaCabanya;
    public enum SecuenciaPlayaCabanya
    {
        CabanyaDormido,
        EsperaDormido,
        CabanyaLlamada,
        EsperaLlamada,
        Playa,
        EsperaPlaya,
        //La escena extra solo ocurrira si el persona de la playa ha sido noqueado antes
        //Pequeño inconveniente, como el soldado al ser noquea registra su posicion para volver a spawnear en la misma
        //esto provoca que el soldado puede no llegar a spawnear en la ubicación que tengo asignada, colocar un spawn obligatorio para él.
        PlayaExtraEscena
    }
    public GameObject cambiarAreaFinal;
    [Header("Transiciones Data")]
    public Animator detectar_Echar;
    [SerializeField] GameObject cortinaCorte;
    /*sonido golpes EventReference*/
    [Header("La Cabanya")]
    [SerializeField] GameObject cabanyaGeneral;
    [Header("Escena Cabanya Dormido")]
    [SerializeField] GameObject escenaCabanyaDormido;
    [SerializeField] float tiempoDespertarSoldado;
    [SerializeField] Animator telefonoCabina;
    [SerializeField] Animator cabezaSiesta;
    [SerializeField] EventReference soundSiesta;
    //Transicion
    [Header("Escena Cabanya Llamada")]
    [SerializeField] GameObject escenaCabanyaLlamada;
    [SerializeField] Transform objetivoCamCabanyaLlamada;
    [SerializeField] float tiempoCabanyaLlamada;
    [SerializeField] EventReference cogerTelefono;
    //Transicion
    [Header("Escena Playa")]
    [SerializeField] GameObject playaGeneral;
    [SerializeField] Transform objetivoCamPlaya;
    [SerializeField] float tiempoPlaya;
    [SerializeField] float tiempoPlayaExtra;
    //Establecer que ocurre en la escena con el soldado
    [Header("Soldado Cabanya")]
    [SerializeField] SoldadoNormal soldadoCabanya;
    //Expresiones Soldado Cabanya
    [SerializeField] GameObject enfado;
    [SerializeField] EventReference angrySound;
    [SerializeField] GameObject decepcion;
    [SerializeField] EventReference decepcionSound;
    //Dialogo
    [SerializeField] Transform spawnDialogoSoldadoPlaya;
    [SerializeField] GameObject globoConversacion;
    int instancia;
    int instanciaAudio;
    [Header("Soldado Playa Terminal")]
    //Soldado Normal
    [SerializeField] GameObject soldadoNormal;
    [SerializeField] SoldadoNormal soldadoPlayaTerminal;
    [SerializeField] SoldierLife vidaSoldadoPlayaTerminal;
    [SerializeField] Transform giroSoldado;
    [SerializeField] public Transform spawnSoldadoNormalDormido;
    [SerializeField] EventReference slapAudio;
    bool estadoSoldadoPlaya;
    //Soldado Levantado al caer una vez
    [SerializeField] GameObject soldadoLevantado;
    void Start()
    {
        //comienza con la animacion de llamada
        vCamMain.m_Lens.OrthographicSize = sizeCamera;
        telefonoCabina.SetBool("Cabina_Call", true);
        if (StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion) this.enabled = false;
    }
    void Update()
    {
        CinPlayaCabanya();
    }
    void CinPlayaCabanya()
    {
        switch (secuenciaPlayaCabanya)
        {
            case SecuenciaPlayaCabanya.CabanyaDormido:
                //Pasa un tiempo
                tiempo += Time.deltaTime;
                if (tiempo >= tiempoDespertarSoldado)
                {
                    //El Soldado Se despierta
                    cabezaSiesta.SetBool("SiestaDespertar", true);
                    if (instanciaAudio < 1) { AudioManager.instancia.PlayOneShot(soundSiesta); instanciaAudio++; }
                }
                if(tiempo >= tiempoDespertarSoldado + 2)
                {
                    detectar_Echar.SetBool("Transicion", true);
                    secuenciaPlayaCabanya = SecuenciaPlayaCabanya.EsperaDormido;
                    tiempo = 0;
                }
                break;
            case SecuenciaPlayaCabanya.EsperaDormido:
                if(tiempo >= tiempoEntreEscenas)
                {
                    instanciaAudio = 0;
                    vCamMain.Follow = objetivoCamCabanyaLlamada;
                    //Intercambias los objetos de las escenas
                    escenaCabanyaDormido.SetActive(false);
                    escenaCabanyaLlamada.SetActive(true);
                    detectar_Echar.SetBool("Transicion", false);
                    //Vas a la siguiente escena
                    secuenciaPlayaCabanya = SecuenciaPlayaCabanya.CabanyaLlamada;
                    tiempo = 0;
                    AudioManager.instancia.PlayOneShot(cogerTelefono);
                }
                else
                {
                    tiempo += Time.deltaTime;
                }
                break;
            case SecuenciaPlayaCabanya.CabanyaLlamada:
                if (tiempo >= tiempoCabanyaLlamada)
                {
                    detectar_Echar.SetBool("Transicion", true);
                    secuenciaPlayaCabanya = SecuenciaPlayaCabanya.EsperaLlamada;
                    tiempo = 0;
                }
                else
                {
                    tiempo += Time.deltaTime;
                    //Cambias el objetivo de la camara
                    //Intercambias los objetos de las escenas
                    //Cuando ocurra el intercambio
                }
                //Sonido de Coger Llamada
                //Sonido de llamada con el miniminiminiminiminiminminiminmini
                break;
            case SecuenciaPlayaCabanya.EsperaLlamada:
                if (tiempo >= tiempoEntreEscenas)
                {
                    vCamMain.Follow = objetivoCamPlaya;
                    //Intercambias los objetos de las escenas
                    playaGeneral.SetActive(true);
                    cabanyaGeneral.SetActive(false);
                    //En caso de que el soldado haya quedado KO antes de tiempo, spawnealo cerca de la zona
                    if(estadoSoldadoPlaya) soldadoNormal.gameObject.transform.position = spawnSoldadoNormalDormido.position;
                    detectar_Echar.SetBool("Transicion", false);
                    //Vas a la siguiente escena
                    secuenciaPlayaCabanya = SecuenciaPlayaCabanya.Playa;
                    tiempo = 0;
                }
                else
                {
                    tiempo += Time.deltaTime;
                    //Si el soldado esta muerto coloca el status en verdadero
                    if (vidaSoldadoPlayaTerminal.vida <= 0)
                    {
                        estadoSoldadoPlaya = true;
                    }
                }
                break;
            case SecuenciaPlayaCabanya.Playa:
                //Activamos al soldado para que se dirija al soldado de la playa.
                soldadoCabanya.enabled = true;
                tiempo += Time.deltaTime;
                if(tiempo >= tiempoPlaya)
                {
                    //Si esta vivo todo se ejecuta normal
                    if(!estadoSoldadoPlaya)
                    {
                        //Haces que el soldado se de la vuelta para mirar al soldado
                        soldadoPlayaTerminal.ubicacionesDirigir[0] = giroSoldado;
                        
                        if(instancia < 1)
                        {
                            GameObject copiaDialogoGlobo = Instantiate(globoConversacion, spawnDialogoSoldadoPlaya.transform.position, Quaternion.identity);
                            instancia++;
                        }

                        //Finaliza la escena 
                        if (tiempo >= tiempoPlaya + 2)
                        {
                            //Te vas de escena
                            cambiarAreaFinal.SetActive(true);
                            //Establece la variable
                            StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion = true;
                        }
                    }
                    //Si esta muerto, pasa a la escena extra
                    else
                    {
                        //Activa el icono de la decepcion
                        decepcion.SetActive(true);
                        if (instanciaAudio < 1) { AudioManager.instancia.PlayOneShot(soundSiesta); instanciaAudio++; }
                        if (tiempo >= tiempoPlaya + 2)
                        {
                            cortinaCorte.SetActive(true);
                            AudioManager.instancia.PlayOneShot(slapAudio);
                            detectar_Echar.SetBool("Transicion", true);
                            secuenciaPlayaCabanya = SecuenciaPlayaCabanya.EsperaPlaya;
                            tiempo = 0;
                        }

                    }
                }
                    //Soldado vivo
                    //Soldado KO
                    //copiaEnemyGlobo = Instantiate(globoEntregar, ubiGloboEnemy.transform.position, Quaternion.identity);
                    //Destroy(copiaEnemyGlobo);
                    break;
            case SecuenciaPlayaCabanya.EsperaPlaya:
                if (tiempo >= tiempoEntreEscenas)
                {
                    cortinaCorte.SetActive(false);
                    //Intercambias al soldado caído por otro que este levantado.
                    soldadoNormal.SetActive(false); //Soldado Base
                    soldadoLevantado.SetActive(true);
                    //Intercambias Simbolos de estado
                    decepcion.SetActive(false);
                    enfado.SetActive(true);

                    detectar_Echar.SetBool("Transicion", false);
                    tiempo = 0;
                    secuenciaPlayaCabanya = SecuenciaPlayaCabanya.PlayaExtraEscena;

                }
                else
                {
                    tiempo += Time.deltaTime;
                }
                break;
            case SecuenciaPlayaCabanya.PlayaExtraEscena:
                tiempo += Time.deltaTime;
                if (tiempo >= tiempoPlayaExtra)
                {
                    if (instancia < 1)
                    {
                        GameObject copiaDialogoGlobo = Instantiate(globoConversacion, spawnDialogoSoldadoPlaya.transform.position, Quaternion.identity);
                        AudioManager.instancia.PlayOneShot(angrySound);
                        instancia++;
                    }
                    //Finaliza la escena 
                    if (tiempo >= tiempoPlayaExtra + 2)
                    {
                        //Te vas de escena
                        cambiarAreaFinal.SetActive(true);
                        //Establece la variable
                        StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion = true;
                    }
                }
                break;
        }

    }
}
