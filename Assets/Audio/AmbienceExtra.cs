using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;
using FMOD.Studio;

public class AmbienceExtra : MonoBehaviour
{
    [SerializeField] EventReference ambienceSecundario;
    EventInstance ambienceExtra;

    int reproductor;
    void Start()
    {
        //ambienceExtra = MusicAmbienceManager.instance.CreateEventAmbienceInstance(ambienceSecundario);
        ambienceExtra = AudioManager.instancia.CreateEventInstance(ambienceSecundario);
    }
    private void Update()
    {
    }
}
