using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class FMODEvent : MonoBehaviour
{

    [Header("Music")]
    [SerializeField] public EventReference music;
    [Header("Ambience")]
    [SerializeField] public EventReference wind;
    [Header("Player SFX")]
    public string apartado_1;
    [SerializeField] public EventReference grassSteps;
    [SerializeField] public EventReference sandSteps;
    [SerializeField] public EventReference concreteSteps;
    [SerializeField] public EventReference metalSteps;
    [SerializeField] public EventReference woodSteps;
    [SerializeField] public EventReference caveSteps;
    [SerializeField] public EventReference mudSteps;
    [SerializeField] public EventReference forestSteps;
    [SerializeField] public EventReference wetSteps;
    [SerializeField] public EventReference swimSteps;
    [Space(20)]
    public string apartado_2;
    [SerializeField] public EventReference woodLadder;
    [SerializeField] public EventReference stealLadder;
    [SerializeField] public EventReference ropeLadder;
    [SerializeField] public EventReference splashWater;
    [Space(20)]
    public string apartado_3;
    [SerializeField] public EventReference arbustoHidden;
    [SerializeField] public EventReference cajaHidden;
    [SerializeField] public EventReference taquillaHidden;
    [SerializeField] public EventReference basuraHidden;
    [SerializeField] public EventReference puertaHidden;
    [Space(20)]
    public string apartado_4;
    [SerializeField] public EventReference damage;
    [SerializeField] public EventReference electroDamage;
    [Space(20)]
    public string apartado_5;
    [SerializeField] public EventReference takeClothes;
    [SerializeField] public EventReference takeOffClothes;
    [Space(20)]
    public string apartado_6;
    [SerializeField] public EventReference shoot;
    [SerializeField] public EventReference noAmmo;
    [SerializeField] public EventReference drawWeapon;
    [SerializeField] public EventReference outWeapon;
    [SerializeField] public EventReference recoveryAmmo;
    [SerializeField] public EventReference b8Lanzar;
    [SerializeField] public EventReference b8Recoger;
    [SerializeField] public EventReference b8CollisionGround;
    //CAMBIAR EL SOPNIDO DEL COCHE A AMBIENTE
    [Header("Enemy SFX")]
    [SerializeField] public EventReference stepsEnemy;
    

    public static FMODEvent instancia;
    public void Awake()
    {
        if(FMODEvent.instancia == null)
        {
            FMODEvent.instancia = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
