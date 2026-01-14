using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using FMOD.Studio;

[RequireComponent(typeof(IconItem))]
public class Portatil_Info : MonoBehaviour
{
    public int indexMod;

    [Header("See Player")]
    [SerializeField] OcultacionByWeapon playerOcultar;
    [SerializeField] ArmaController armaPlayer;
    bool seePlayer;
    
    [Header("Icono")]
    IconItem iconItem;

    [Header("Barra Data")]
    public int indexTerminal;
    public Image downloadBar;
    //public SpriteRenderer screenLight;
    public GameObject contorno;

    //Estas 3 variables me dan igual
    bool infoCompiled;
    bool active;
    public int numeroDeTerminalesTotales; //Eliminar


    [Header("Completar Tarea")]
    public GameObject zonaCompletarNivel;
    public SpriteRenderer pantallaPortatil;
    public Sprite pantallaPortatilCompleta;

    EstructuraNiveles nivelCompletado = new EstructuraNiveles();

    PlayerHere playerInTerminal;

    EventInstance teclearTerminalSound;
    int onceTeclearSound;
    int confirmSound;

    CompletarPortatiles completarPortatil;

    int restaurarArmaLayer; //quiza hay que cambiar el layer porque lo tengo en 0, cuando el 0 no sé corresponde al del player
    private void Awake()
    {
        iconItem = GetComponent<IconItem>();
        playerInTerminal = GetComponent<PlayerHere>();

        //SaveScene.instancia.SaveThings();
    }
    private void Start()
    {
        //LoadPorcentaje(); 
        //downloadBar.fillAmount = 0;
        completarPortatil = FindObjectOfType<CompletarPortatiles>();
        if (StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion)
        {
            iconItem.enabled = false;
            //Comprobar esto una vez
            pantallaPortatil.sprite = pantallaPortatilCompleta;
            this.enabled = false;
        }
        teclearTerminalSound = AudioManager.instancia.CreateEventInstance(FMODEvent.instancia.teclear);
    }
    private void Update()
    {
        //CanHacking();
        HackingTerminal();
        //CollectAllInfo();
        //ActiveYourTerminal();
        

        /////////////////////////////////// Cuando presionas el Action el icono debe desaparecer mientras la barra del contorno de la informacion se llena
        
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
        /*
        if (active) 
        { 
            screenLight.color = Color.green; 
            this.enabled = false;
        };
        */
    }

    void CanHacking()
    {
        if(playerInTerminal.playerImHere && downloadBar.fillAmount < 1 && !active)
        {

        }
    }
    void HackingTerminal()
    {
        //If you are here and don't active the terminal
        if(playerInTerminal.playerImHere)
        {
            restaurarArmaLayer = 0;
            if (downloadBar.fillAmount < 1)
            {
                if (Input.GetButton("Action"))
                {
                    //Deja de verse la exclamacion y comienza a visualizar se el progreso de la descargar
                    contorno.SetActive(true);
                    downloadBar.fillAmount += 0.01f;
                    iconItem.enabled = false;
                    iconItem.iconoZone.SetActive(false);

                    seePlayer = true;
                    playerOcultar.SeeByAction(seePlayer);
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
                    armaPlayer.pistola.enabled = false;
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

                    iconItem.enabled = true;
                    iconItem.iconoZone.SetActive(true);

                    seePlayer = false;
                    playerOcultar.SeeByAction(seePlayer);

                    contorno.SetActive(false);
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
                playerOcultar.SeeByAction(seePlayer);
                iconItem.enabled = false;
                contorno.SetActive(false);

                StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion = true;

                //Cambiar la pantalla de Rojo a Verde una vez completado
                pantallaPortatil.sprite = pantallaPortatilCompleta;
                //TotalTerminales.terminalesTotales.terminalesActivados++;

                //active = true;
                //TotalTerminales.terminalesTotales.terminalesActivos[indexTerminal] = active;

                //Paramos el audio teclear
                teclearTerminalSound.stop(STOP_MODE.IMMEDIATE);
                //Sonido de confirmacion
                if(confirmSound < 1)
                {
                    AudioManager.instancia.PlayOneShot(FMODEvent.instancia.confirmTerminal);
                    completarPortatil.ResetearIndex();
                    completarPortatil.ComprobarTerminales();
                    confirmSound++;
                }

            }




        }
        else
        {
            if (downloadBar.fillAmount < 1)
            {
                contorno.SetActive(false);
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
            playerOcultar.SeeByAction(seePlayer);
            restaurarArmaLayer++;
        }
    }
}
