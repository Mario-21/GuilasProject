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

    [Header("Weapon SFX")]
    [SerializeField] public EventReference shoot;
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
