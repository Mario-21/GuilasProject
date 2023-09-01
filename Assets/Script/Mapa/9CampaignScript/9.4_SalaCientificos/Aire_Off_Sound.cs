using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class Aire_Off_Sound : MonoBehaviour
{
    public int indexMod;
    StudioEventEmitter aireEmitter;
    [SerializeField] EventReference aireSFX;
    [SerializeField] GameObject aireItem;
    private void Start()
    {
        aireEmitter = AudioManager.instancia.InitializeEventEmitter(aireSFX, aireItem);
    }
    void Update()
    {
        if (StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion)
        {
            aireEmitter.Stop();
        }
    }
}
