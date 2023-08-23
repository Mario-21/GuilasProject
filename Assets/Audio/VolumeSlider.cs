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
        ITEMSFX,
        ENEMYSFX,
        PLAYERSFX
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
            case VolumeType.ITEMSFX:
                volumeSlider.value = AudioMenu.instancia.sfxItems;
                break;
            case VolumeType.ENEMYSFX:
                volumeSlider.value = AudioMenu.instancia.sfxEnemy;
                break;
            case VolumeType.PLAYERSFX:
                volumeSlider.value = AudioMenu.instancia.sfxPlayer;
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
            case VolumeType.ITEMSFX:
                AudioMenu.instancia.sfxItems = volumeSlider.value;
                break;
            case VolumeType.ENEMYSFX:
                AudioMenu.instancia.sfxEnemy = volumeSlider.value;
                break;
            case VolumeType.PLAYERSFX:
                AudioMenu.instancia.sfxPlayer = volumeSlider.value;
                break;
        }
    }
}
