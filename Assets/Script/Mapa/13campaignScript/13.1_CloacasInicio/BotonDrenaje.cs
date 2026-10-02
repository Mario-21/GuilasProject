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
    [Header("Boton Drenaje")]
    [SerializeField] SpriteRenderer spriteBotonDrenaje;
    [Header("Sprite rejillas")]
    [SerializeField] Sprite rejillaOpen;
    [SerializeField] Sprite rejillaClose;
    [SerializeField] List<SpriteRenderer> rejillas;
    public bool statusRejillas;
    int limitRejillaSound;
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

    int soundDrenaje;
    int soundDrenaje_NoMaintenance;
    float timeRepeatPressButton;
    bool repeatButton;
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
            //ListWaters.listWaters.infoAguas[waterInfo.indexWater].porcentajeAgua = 0;
        }
    }

    // Update is called once per frame
    void Update()
    {
        StatusButtonColor();
        //RefreshButton();

        if (player.playerImHere)
        {
            if (Input.GetButtonDown("Action") && !repeatButton)
            {
                AudioManager.instancia.PlayOneShot(FMODEvent.instancia.botonGeneral);
                limitRejillaSound = 0;
                if(!timeDrenar && waterInfo.porcentajeAgua > 0)
                {
                    timeDrenar = true;
                }
                else if(waterInfo.porcentajeAgua <= 0)
                {
                    timeLoadAgua = true;
                    StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion = !StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion;
                    RejillasSound();
                    /*if (limitRejillaSound < 1)
                    {
                        RejillasSound();
                        limitRejillaSound++;
                    }*/
                }
                
            }
        }
        Drenaje();
        if (timeDrenar) 
        {
            DrenajeTransition();
            StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion = true;
            if(limitRejillaSound < 1)
            {
                AudioManager.instancia.PlayOneShot(FMODEvent.instancia.rejillaOpen);
                limitRejillaSound++;
            }
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
            statusRejillas = true;
            //Por esto ya no llega a funcionar el trasladar agua, el boton de drenaje absorbe constantemente el agua, si activas una de las valvulas ya no se efectua por el timing de 1.5
            //Hay que eliminar el tiempo, hacerlo aparte o algo.
            if (timeDrenaje >= limitTimeDrenaje)
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
            statusRejillas = false;
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
            //Cuando vayas a abrir la rejilla de drenaje, también debes resetear sus variables, para evitar que al entrar de nuevo a la zona inhabilite el uso de las valvulas
            StatusGameobjectsVariables.statusGameobject.modificacion[valvulas[e].indexMod].modificacion = false;
        }
    }
    void DrenajeTransition()
    {
        if(timeDrenaje >= limitTimeDrenaje)
        {
            //Añadir sonido agua siendo drenada
            if(timeDrenar)
            {
                Debug.Log("Drenaste Agua");
                ListWaters.listWaters.infoAguas[waterInfo.indexWater].porcentajeAgua = 0;
            }
            else if (timeLoadAgua)
            {
                Debug.Log("Llenaste Agua");
                ListWaters.listWaters.infoAguas[waterInfo.indexWater].porcentajeAgua = 100;
            }
            AnimationHud.detectar_echar.SetBool("Transicion", false);
            timeDrenaje = 0;
            soundDrenaje = 0;
            soundDrenaje_NoMaintenance = 0;
            timeDrenar = false;
            timeLoadAgua = false;
            repeatButton = false;
            bloqPlayer.HabilitarMovPlayer();
        }
        else
        {
            timeDrenaje += Time.deltaTime;
            AnimationHud.detectar_echar.SetBool("Transicion", true);
            bloqPlayer.BloquearMovPlayer();
            if(soundDrenaje < 1 && StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion)
            {
                AudioManager.instancia.PlayOneShot(FMODEvent.instancia.drenar);
                soundDrenaje++;
            }
        }
    }
    void LlenarWaterAgain()
    {
        //Si no has activado la palanca de mantenimiento y has cerrado el drenaje
        if (!StatusGameobjectsVariables.statusGameobject.modificacion[indexMantinance].modificacion && !StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion)
        {
            if (soundDrenaje_NoMaintenance < 1)
            {
                AudioManager.instancia.PlayOneShot(FMODEvent.instancia.llenarDrenaje);
                soundDrenaje_NoMaintenance++;
            }
            //colocar audio de llenado
            repeatButton = true;
            DrenajeTransition();
            //LlenarTransition();
            if (timeDrenaje >= (limitTimeDrenaje * 3 )/ 4)
            {//Colocar el fresh button
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
    void RejillasSound()
    {
        //Abrir
        if (StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion)
        {
            AudioManager.instancia.PlayOneShot(FMODEvent.instancia.rejillaOpen);
        }
        //Cerrar
        else
        {
            AudioManager.instancia.PlayOneShot(FMODEvent.instancia.rejillaClose);
        }
    }

}
