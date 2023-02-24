using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Valvula : MonoBehaviour
{
    public int indexMod;
    [Header("Player Data")]
    [SerializeField] BloquearMovimientoPlayer bloqPlayer;
    [Header("Water Info")]
    public float porcentajeAgua;
    public float aguaRestar;
    [SerializeField] WaterData waterAltTotal;
    [Header("Tuberia Data")]
    [SerializeField] SpriteRenderer boton;
    [SerializeField] GameObject cascada;
    [Header("Time Valvula")]
    public float timeLimitValvula;
    public float timeValvula;

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
        aguaRestar = (porcentajeAgua * waterAltTotal.alturaTotal) / 100;
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
        StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion = valvulaOn;
        if (player.playerImHere && !valvulaOn)
        {
            if (Input.GetKeyDown(KeyCode.Z) && !valvulaTime)
            {
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
        }
        else
        {
            //Puedes usar la Valvula
            boton.color = Color.green;
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
            //Calcula cuanto sube el agua
            CalculoDeAguas();
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
    }
}
