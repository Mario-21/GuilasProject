using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotonDrenaje : MonoBehaviour
{
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
    bool drenar;
    bool timeDrenar;
    PlayerHere player;

    void Start()
    {
        drenar = StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion;

        player = GetComponent<PlayerHere>();
    }

    // Update is called once per frame
    void Update()
    {
        StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion = drenar;

        if (player.playerImHere)
        {
            if (Input.GetKeyDown(KeyCode.Z))
            {
                if(!timeDrenar && waterInfo.porcentajeAgua > 0)
                {
                    timeDrenar = true;
                }
                else if(waterInfo.porcentajeAgua <= 0)
                {
                    drenar = !drenar;
                } 

            }
        }
        Drenaje();
        if (timeDrenar) DrenajeTransition();
    }
    void Drenaje()
    {
        //Rejilla Abierta
        if (drenar)
        {
            waterInfo.transform.position = waterInfo.alturaMin.position;
            waterInfo.porcentajeAgua = 0;
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
            drenar = true;
            timeDrenaje = 0;
            timeDrenar = false;
            bloqPlayer.HabilitarMovPlayer();
        }
        else
        {
            timeDrenaje += Time.deltaTime;
            AnimationHud.detectar_echar.SetBool("Transicion", true);
            bloqPlayer.BloquearMovPlayer();
        }
    }
}
