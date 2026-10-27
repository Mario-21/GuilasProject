using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMOD.Studio;
using FMODUnity;

public class CrySound : MonoBehaviour
{
    EventInstance cry;
    [SerializeField] EventReference crySound;
    void Start()
    {
        cry = AudioManager.instancia.CreateEventInstance(crySound);
        cry.start();
    }

    // Update is called once per frame
    private void OnDestroy()
    {
        cry.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        cry.release();
    }
}
