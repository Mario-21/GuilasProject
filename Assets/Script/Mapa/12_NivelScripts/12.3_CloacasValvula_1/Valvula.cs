using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Valvula : MonoBehaviour
{
    public int indexMod;
    public int indexDrenar;
    [Header("Player Data")]
    [SerializeField] BloquearMovimientoPlayer bloqPlayer;
    [Header("Water Info")]
    public float porcentajeAgua;
    public float aguaRestar;
    [SerializeField] WaterData waterAltTotal;
    [Header("Tuberia Data")]
    [SerializeField] SpriteRenderer boton;
    public GameObject cascada;
    [Header("Valvula Data")]
    [SerializeField] SpriteRenderer botonValvula;
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
        //Calcular cuanta agua tiene puede llenar una valvula
        PorcentajeAguaCalculoInicial();
        //Saber si la valvula se ha quedado activa o inactiva 
        valvulaOn = StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion;
        //Feedback visual que muestra si ya se ha usado la valvula 
        EstadoValvula();
    }
    void Update()
    {
        EstadoValvula();
        ActiveValvula();
    }
    void ActiveValvula()
    {
        //El problema esta aqui, cuando le das al boton no te puede cambiar la variable dado que esta estableciendo constantemene el de la valvulaOn
        //StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion = valvulaOn;
        if (player.playerImHere && !valvulaOn)
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
    void EstadoValvula()
    {
        if (valvulaOn)
        {
            //Gastas el uso de la Valvula
            boton.color = Color.red;
            botonValvula.color = Color.red;
        }
        else
        {
            //Puedes usar la Valvula
            boton.color = Color.green;
            botonValvula.color = Color.green;
        }
    }
    void TrasnsicionValvula()
    {
        if(timeValvula >= timeLimitValvula)
        {
            AnimationHud.detectar_echar.SetBool("Transicion", false);
            //Activas el estado de los botones
            valvulaOn = true;
            //Ya no necesitan la transicion
            valvulaTime = false;
            //Desactivas la valvula ya que no necesitas que este activada
            cascada.SetActive(false);
            //Resetea el timing
            timeValvula = 0;
            //Calcula cuanto sube el agua si el drenaje esta cerrado
            if (!StatusGameobjectsVariables.statusGameobject.modificacion[indexDrenar].modificacion) 
            {
                //Desactiva el icono
                iconSee = false;
                iconoZone.SetActive(false);
                StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion = true;
                //StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion = true;
                //Si el porcentaje es superior a 100 no quieres que te calcule nada, debido a que a habido un bug
                //en el que si te mueves a la vez que le das a la valvula, por alguna razón, el agua se desborda,
                //haciendo que te golpeé
                if (waterAltTotal.porcentajeAgua < 100) CalculoDeAguas();
            }
            //Puedes volver a moverte
            bloqPlayer.HabilitarMovPlayer();

            //StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion = true;

        }
        else
        {
            timeValvula += Time.deltaTime;
            AnimationHud.detectar_echar.SetBool("Transicion", true);
            bloqPlayer.BloquearMovPlayer();
        }
    }
    void CalculoDeAguas()
    {
        //Establece la altura del agua 
        float aguaTotal = waterAltTotal.transform.position.y;
        //Resta la capacidad total del agua menos el porcentaje de agua de la valvula
        aguaTotal += aguaRestar;
        // Coloca el agua segun la posicion dada tras hacer la resta con la valvula
        waterAltTotal.transform.position = new Vector3(waterAltTotal.transform.position.x, aguaTotal, waterAltTotal.transform.position.z);
        //Suma el porcentaje del agua tras activar la valvula
        waterAltTotal.porcentajeAgua += (int)porcentajeAgua;
        ListWaters.listWaters.infoAguas[waterAltTotal.indexWater].porcentajeAgua += (int)porcentajeAgua;
    }
    [ContextMenu("Recalcula el porcentaje de agua")]
    void PorcentajeAguaCalculoInicial()
    {
        aguaRestar = (porcentajeAgua * waterAltTotal.alturaTotal) / 100;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (!valvulaOn) iconSee = true;
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
