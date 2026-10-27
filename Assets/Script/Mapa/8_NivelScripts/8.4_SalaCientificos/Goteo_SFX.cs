using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMOD.Studio;
using FMODUnity;

public class Goteo_SFX : MonoBehaviour
{
    EventInstance goteo;
    [SerializeField] EventReference sfx_Goteo;
    void Start()
    {
        goteo = AudioManager.instancia.CreateEventInstance(sfx_Goteo);
        goteo.start();
    }

    private void OnDisable()
    {
        goteo.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
    }
}
