using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using FMOD.Studio;

public class Portatil_Info : MonoBehaviour
{
    [Header("See Player")]
    [SerializeField] OcultacionByWeapon player;
    bool seePlayer;
    
    [Header("Icono")]
    public SpriteRenderer exclamacionMark;
    Animator animExclamacion;

    [Header("Barra Data")]
    public int indexTerminal;
    public Image downloadBar;
    public SpriteRenderer screenLight;
    public GameObject contorno;

    bool infoCompiled;
    bool active;
    public int numeroDeTerminalesTotales;


    [Header("Completar Tarea")]
    public GameObject zonaCompletarNivel;

    EstructuraNiveles nivelCompletado = new EstructuraNiveles();

    PlayerHere playerInTerminal;

    EventInstance teclearTerminalSound;
    int onceTeclearSound;
    

    //NOTA
    //Si no funciona probar con armacontroler 
    private void Awake()
    {
        animExclamacion = GetComponent<Animator>();

        playerInTerminal = GetComponent<PlayerHere>();

        //SaveScene.instancia.SaveThings();
    }
    private void Start()
    {
        LoadPorcentaje(); 
        downloadBar.fillAmount = 0;
        teclearTerminalSound = AudioManager.instancia.CreateEventInstance(FMODEvent.instancia.teclear);
    }
    private void Update()
    {
        CanHacking();
        HackingTerminal();
        CollectAllInfo();
        ActiveYourTerminal();
        
        
        //NOTA
        //quiza el desactivar el script hay que cambiar lo mas adelantea por SceneManager.GetActiveScene().buildIndex < entreNiveles[1]
    }
    void CollectAllInfo()
    {
        if (TotalTerminales.terminalesTotales.terminalesActivados >= numeroDeTerminalesTotales) 
        {
            infoCompiled = true;
            TotalTerminales.terminalesTotales.carga = infoCompiled;
            infoCompiled = true;

        }
        if (infoCompiled) nivelCompletado.Nivel_1(infoCompiled, zonaCompletarNivel);

    }

    void ActiveYourTerminal()
    {
        if (active) 
        { 
            screenLight.color = Color.green; 
            this.enabled = false;
        };
    }

    void CanHacking()
    {
        if(playerInTerminal.playerImHere && downloadBar.fillAmount < 1 && !active)
        {
            animExclamacion.enabled = true;
        }
    }
    void HackingTerminal()
    {
        //If you are here and don't active the terminal
        if(playerInTerminal.playerImHere)
        {
            if(!active)
            {
                if (downloadBar.fillAmount < 1)
                {
                    if (Input.GetKey(KeyCode.E))
                    {
                        //Deja de verse la exclamacion y comienza a visualizar se el progreso de la descargar
                        contorno.SetActive(true);
                        animExclamacion.enabled = false;
                        exclamacionMark.enabled = false;
                        downloadBar.fillAmount += 0.01f;

                        seePlayer = true;
                        player.SeeByAction(seePlayer);

                        //Reproducir sonido del tecleado
                        if (onceTeclearSound < 1)
                        {
                            teclearTerminalSound.start();
                            onceTeclearSound++;
                        }

                    }
                    else
                    {
                        seePlayer = false;
                        player.SeeByAction(seePlayer);

                        contorno.SetActive(false);
                        animExclamacion.enabled = true;
                        exclamacionMark.enabled = true;
                        if (downloadBar.fillAmount < 1)
                        {
                            downloadBar.fillAmount = 0;
                            //Parar el tecleado y el conteo
                            teclearTerminalSound.stop(STOP_MODE.IMMEDIATE);
                            onceTeclearSound = 0;
                        }
                    }
                }
                else
                {
                    seePlayer = false;
                    player.SeeByAction(seePlayer);

                    contorno.SetActive(false);

                    TotalTerminales.terminalesTotales.terminalesActivados++;

                    active = true;
                    TotalTerminales.terminalesTotales.terminalesActivos[indexTerminal] = active;

                    //Paramos el audio teclear
                    teclearTerminalSound.stop(STOP_MODE.IMMEDIATE);
                    //Sonido de confirmacion
                    AudioManager.instancia.PlayOneShot(FMODEvent.instancia.endTerminal);

                }
            }
            
        }
        else
        {
            if (downloadBar.fillAmount < 1)
            {
                contorno.SetActive(false);
                animExclamacion.enabled = false;
                exclamacionMark.enabled = false;
                downloadBar.fillAmount = 0;

                //Parar el tecleado y resetear
                teclearTerminalSound.stop(STOP_MODE.IMMEDIATE);
                onceTeclearSound = 0;
            }
        }
    }
    void LoadPorcentaje()
    {
        
        infoCompiled = TotalTerminales.terminalesTotales.carga;
        
        active = TotalTerminales.terminalesTotales.terminalesActivos[indexTerminal];

    }
}
