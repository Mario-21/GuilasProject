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
    [SerializeField] ArmaController armaPlayer;
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

    int restaurarArmaLayer;
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
            restaurarArmaLayer = 0;
            if(!active)
            {
                if (downloadBar.fillAmount < 1)
                {
                    if (Input.GetButton("Action"))
                    {
                        //Deja de verse la exclamacion y comienza a visualizar se el progreso de la descargar
                        contorno.SetActive(true);
                        animExclamacion.enabled = false;
                        exclamacionMark.enabled = false;
                        downloadBar.fillAmount += 0.01f;

                        seePlayer = true;
                        player.SeeByAction(seePlayer);
                        //Mientras estes usando el terminal no puedes usar el arma
                        //Guardar Arma en caso de comenzar el hackeo con el arma desechada
                        #region
                        
                        if (armaPlayer.activarDisparo) 
                        {
                            AudioManager.instancia.PlayOneShot(FMODEvent.instancia.outWeapon);
                            Debug.Log("Arma desechada");
                        }
                        armaPlayer.activarDisparo = false;
                        armaPlayer.enabled = false;
                        armaPlayer.weaponSprite.enabled = false;
                        armaPlayer.municionText.enabled = false;
                        armaPlayer.mira.localPosition = new Vector2(0f, armaPlayer.mira.localPosition.y);
                        armaPlayer.mira.gameObject.GetComponent<SpriteRenderer>().enabled = false;
                        armaPlayer.brazo.transform.rotation = Quaternion.identity;
                        
                        #endregion 

                        //Reproducir sonido del tecleado
                        if (onceTeclearSound < 1)
                        {
                            teclearTerminalSound.start();
                            onceTeclearSound++;
                        }

                    }
                    else
                    {
                        //Cuando dejes de usar el terminal habilitas el arma
                        armaPlayer.enabled = true;

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
                    AudioManager.instancia.PlayOneShot(FMODEvent.instancia.confirmTerminal);

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
            //Que me restaure el arma y el layer del soldado, una única vez
            RestaurarLayerAndArma();
        }
    }
    void LoadPorcentaje()
    {
        
        infoCompiled = TotalTerminales.terminalesTotales.carga;
        
        active = TotalTerminales.terminalesTotales.terminalesActivos[indexTerminal];

    }
    void RestaurarLayerAndArma()
    {
        if(restaurarArmaLayer < 1)
        {
            armaPlayer.enabled = true;
            seePlayer = false;
            player.SeeByAction(seePlayer);
            restaurarArmaLayer++;
        }
    }
}
