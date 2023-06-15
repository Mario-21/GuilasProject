using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotonDrenaje : MonoBehaviour
{
    public int indexMantinance;
    public int indexMod;
    [Header("Player Data")]
    [SerializeField] BloquearMovimientoPlayer bloqPlayer;
    [Header("Agua Data")]
    [SerializeField] WaterData waterInfo;
    [Header("Sprite rejillas")]
    [SerializeField] Sprite rejillaOpen;
    [SerializeField] Sprite rejillaClose;
    [SerializeField] List<SpriteRenderer> rejillas;
    [Header("Valvulas Data")]
    [SerializeField] List<Valvula> valvulas;
    [Header("Time Drenar")]
    public float limitTimeDrenaje;
    float timeDrenaje;

    //Añadir el habilitar la valvula 
    //Pero solo si se ha dado previamente a la palanca de mantenimiento de su respectiva zona
    //ademas de 
    //bool drenar;
    bool timeDrenar;
    bool timeLoadAgua;
    PlayerHere player;
    SpriteRenderer spriteBotonDrenaje;

    private void Awake()
    {
        spriteBotonDrenaje = GetComponent<SpriteRenderer>();
    }
    void Start()
    {
        //drenar = StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion;
        player = GetComponent<PlayerHere>();
        //Si dejas abierto 
        if (StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion)
        {
            Debug.Log("el Drenaje " + indexMod + " en esta zona esta abierto");
            waterInfo.transform.position = waterInfo.alturaMin.position;
            waterInfo.porcentajeAgua = 0;
            ListWaters.listWaters.infoAguas[waterInfo.indexWater].porcentajeAgua = 0;
        }
    }

    // Update is called once per frame
    void Update()
    {
        StatusButtonColor();

        if (player.playerImHere)
        {
            if (Input.GetButtonDown("Action"))
            {
                if(!timeDrenar && waterInfo.porcentajeAgua > 0)
                {
                    timeDrenar = true;
                }
                else if(waterInfo.porcentajeAgua <= 0)
                {
                    timeLoadAgua = true;
                    StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion = !StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion;
                } 

            }
        }
        Drenaje();
        if (timeDrenar) 
        {
            DrenajeTransition();
            StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion = true;
        }
        if (timeLoadAgua)
        {
            LlenarWaterAgain();
        }
    }
    void Drenaje()
    {
        //Rejilla Abierta
        if (StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion)
        {
            //Por esto ya no llega a funcionar el trasladar agua, el boton de drenaje absorbe constantemente el agua, si activas una de las valvulas ya no se efectua por el timing de 1.5
            //Hay que eliminar el tiempo, hacerlo aparte o algo.
            if (timeDrenaje >= 1.5)
            {
                waterInfo.transform.position = waterInfo.alturaMin.position;
                waterInfo.porcentajeAgua = 0;
            }
            BloquearValvulas();
            foreach(SpriteRenderer rejilla in rejillas)
            {
                rejilla.sprite = rejillaOpen;
            }
        }
        //Rejilla Cerrada
        else
        {
            foreach (SpriteRenderer rejilla in rejillas)
            {
                rejilla.sprite = rejillaClose;
            }
        }
    }
    void BloquearValvulas()
    {
        for (int e = 0; e < valvulas.Count; e++)
        {
            valvulas[e].valvulaOn = false;
        }
    }
    void DrenajeTransition()
    {
        if(timeDrenaje >= limitTimeDrenaje)
        {
            //Añadir sonido agua siendo drenada
            AnimationHud.detectar_echar.SetBool("Transicion", false);
            timeDrenaje = 0;
            timeDrenar = false;
            timeLoadAgua = false;
            bloqPlayer.HabilitarMovPlayer();
        }
        else
        {
            timeDrenaje += Time.deltaTime;
            AnimationHud.detectar_echar.SetBool("Transicion", true);
            bloqPlayer.BloquearMovPlayer();
        }
    }
    void LlenarWaterAgain()
    {
        //Si no has activado la palanca de mantenimiento y has cerrado el drenaje
        if(!StatusGameobjectsVariables.statusGameobject.modificacion[indexMantinance].modificacion && !StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion)
        {
            DrenajeTransition();
            if (timeDrenaje >= 1.5)
            {
                waterInfo.transform.position = waterInfo.alturaMax.position;
                waterInfo.porcentajeAgua = 100;
            }
        }
    }
    void StatusButtonColor()
    {
        if (StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion)
        {
            spriteBotonDrenaje.color = Color.green;
        }
        else
        {
            spriteBotonDrenaje.color = Color.red;
        }
    }
}
