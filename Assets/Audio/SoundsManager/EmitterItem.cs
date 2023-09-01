using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class EmitterItem : MonoBehaviour
{
    StudioEventEmitter emitter;
    [SerializeField] EventReference sound_Effect;
    [SerializeField] GameObject itemEmitter;
    void Start()
    {
        emitter = AudioManager.instancia.InitializeEventEmitter(sound_Effect, itemEmitter);
    }
}
