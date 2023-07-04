using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class FMODEvent : MonoBehaviour
{
    [Header("Player SFX")]
    [SerializeField] public EventReference footStepGlass;
    [Header("Weapon SFX")]
    [SerializeField] public EventReference shoot;

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
