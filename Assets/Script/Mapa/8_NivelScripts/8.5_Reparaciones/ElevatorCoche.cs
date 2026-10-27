using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class ElevatorCoche : MonoBehaviour
{
    PlayerHere player;
    public int indexMod;

    [Header("Range Car")]
    [SerializeField] RangeCarTrigger car;
    [Header("Sfx Car Impact")]
    [SerializeField] EventReference sfxImpactCar;
    [Header("Cinematic")]
    [SerializeField] GameObject cutItemCin;
    [SerializeField] int cinematic;
    [Header("Iconos")]
    IconItem icono;
    void Start()
    {
        icono = GetComponent<IconItem>();
        player = GetComponent<PlayerHere>();
        if (StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion)
        {
            icono.enabled = false;
            this.enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        ElevatorVehicle();
    }
    void ElevatorVehicle()
    {
        if (player.playerImHere)
        {
            if (Input.GetButtonDown("Action"))
            {
                AudioManager.instancia.PlayOneShot(FMODEvent.instancia.botonGeneral);
                icono.enabled = false;
                CorteEscena();

            }
        }
        if (StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion)
        {
            AnimationHud.detectar_echar.SetTrigger("Detectar_Echar");
            EstructuraNiveles.nivel = cinematic;
        }
    }
    void CorteEscena()
    {
        if(car.RangeCar && !StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion)
        {
            cutItemCin.SetActive(true);
            AudioManager.instancia.PlayOneShot(sfxImpactCar);
            StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion = true;
        }
    }
}
