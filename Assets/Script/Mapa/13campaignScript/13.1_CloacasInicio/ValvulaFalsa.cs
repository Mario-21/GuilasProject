using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ValvulaFalsa : MonoBehaviour
{
    public int indexMod;
    [Header("Player Data")]
    [SerializeField] BloquearMovimientoPlayer bloqPlayer;
    [Header("Tuberia Data")]
    [SerializeField] SpriteRenderer boton;
    public GameObject cascada;
    //[SerializeField] Valvula valvulaReal;
    [Header("Time Valvula")]
    public float timeLimitValvula;
    public float timeValvula;
    [Header("Icono Usar Valvulas")]
    public GameObject iconoZone;
    [SerializeField] SpriteRenderer iconeZoneSprite;
    [SerializeField] Sprite icon;

    bool iconSee;

    PlayerHere player;

    public bool valvulaOn;
    bool valvulaTime;
    private void Awake()
    {
        player = GetComponent<PlayerHere>();
    }
    void Start()
    {
        if (StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion)
        {
            this.enabled = false;
        }
    }
    void Update()
    {
        if (StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion)
        {
            this.enabled = false;
        }
        ActiveValvula();
    }
    void ActiveValvula()
    {
        //El problema esta aqui, cuando le das al boton no te puede cambiar la variable dado que esta estableciendo constantemene el de la valvulaOn
        //StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion = valvulaOn;
        if (player.playerImHere)
        {
            if (iconSee)
            {
                iconeZoneSprite.sprite = icon;
                iconoZone.SetActive(true);
            }
            if (Input.GetButtonDown("Action") && !valvulaTime)
            {
                AudioManager.instancia.PlayOneShot(FMODEvent.instancia.valvula);
                //CalculoDeAguas();
                //Conserva si la valvula ha sido activada
                cascada.SetActive(true);
                //valvulaOn = true;
                valvulaTime = true;
            }
        }

        if (valvulaTime) TrasnsicionValvula();
    }
    void TrasnsicionValvula()
    {
        if (timeValvula >= timeLimitValvula)
        {
            AnimationHud.detectar_echar.SetBool("Transicion", false);
            //Activas el estado de los botones
            //Ya no necesitan la transicion
            valvulaTime = false;
            //Desactivas la valvula ya que no necesitas que este activada
            cascada.SetActive(false);
            //Resetea el timing
            timeValvula = 0;
            //Calcula cuanto sube el agua si el drenaje esta cerrado
            //Puedes volver a moverte
            bloqPlayer.HabilitarMovPlayer();

        }
        else
        {
            timeValvula += Time.deltaTime;
            AnimationHud.detectar_echar.SetBool("Transicion", true);
            bloqPlayer.BloquearMovPlayer();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            iconSee = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            iconSee = false;
            iconoZone.SetActive(false);
        }
    }
}

