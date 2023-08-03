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
                volumeSlider.value = AudioMenu.instancia.masterVolume;
                break;
            case VolumeType.MUSIC:
                volumeSlider.value = AudioMenu.instancia.musicVolume;
                break;
            case VolumeType.AMBIENCE:
                volumeSlider.value = AudioMenu.instancia.ambienceVolume;
                break;
            case VolumeType.SFX:
                volumeSlider.value = AudioMenu.instancia.SFXVolume;
                break;
        }
    }
    public void SliderChangeVolume()
    {
        switch (volumeType)
        {
            case VolumeType.MASTER:
                AudioMenu.instancia.masterVolume = volumeSlider.value;
                break;
            case VolumeType.MUSIC:
                AudioMenu.instancia.musicVolume = volumeSlider.value;
                break;
            case VolumeType.AMBIENCE:
                AudioMenu.instancia.ambienceVolume = volumeSlider.value;
                break;
            case VolumeType.SFX:
                AudioMenu.instancia.SFXVolume = volumeSlider.value;
                break;
        }
    }
}
