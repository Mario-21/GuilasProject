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
    [Space(20)]
    public string name_2;
    [Header("Weapon SFX")]
    [SerializeField] public EventReference shoot;
    [Header("Hidden SFX")]
    [SerializeField] public EventReference arbusto;
    [Header("Enemy SFX")]
    [SerializeField] public EventReference stepsEnemy;
    [Header("Stairs SFX")]
    [SerializeField] public EventReference stairsUpDown;
    

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
