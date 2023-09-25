using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;
public class SoundButton : MonoBehaviour
{
    [SerializeField] EventReference buttonAudio;

    public void AudioBoton()
    {
        AudioManager.instancia.PlayOneShot(buttonAudio);
    }
}
