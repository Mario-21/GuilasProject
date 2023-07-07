using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeSlider : MonoBehaviour
{
    private enum VolumeType
    {
        MASTER,
        MUSIC,
        AMBIENCE,
        SFX
    }
    [Header("Type")]
    [SerializeField] private VolumeType volumeType;

    private Slider volumeSlider;

    private void Awake()
    {
        volumeSlider = this.GetComponentInChildren<Slider>();
    }
    private void Update()
    {
        switch (volumeType)
        {
            case VolumeType.MASTER:
                volumeSlider.value = AudioManager.instancia.masterVolume;
                break;
            case VolumeType.MUSIC:
                volumeSlider.value = AudioManager.instancia.musicVolume;
                break;
            case VolumeType.AMBIENCE:
                volumeSlider.value = AudioManager.instancia.ambienceVolume;
                break;
            case VolumeType.SFX:
                volumeSlider.value = AudioManager.instancia.SFXVolume;
                break;
        }
    }
    public void SliderChangeVolume()
    {
        switch (volumeType)
        {
            case VolumeType.MASTER:
                AudioManager.instancia.masterVolume = volumeSlider.value;
                break;
            case VolumeType.MUSIC:
                AudioManager.instancia.musicVolume = volumeSlider.value;
                break;
            case VolumeType.AMBIENCE:
                AudioManager.instancia.ambienceVolume = volumeSlider.value;
                break;
            case VolumeType.SFX:
                AudioManager.instancia.SFXVolume = volumeSlider.value;
                break;
        }
    }
}
