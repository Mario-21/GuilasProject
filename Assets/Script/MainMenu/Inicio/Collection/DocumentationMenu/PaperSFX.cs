using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;
public class PaperSFX : MonoBehaviour
{
    [Header("SFX")]
    [SerializeField] EventReference enterSfx;
    [SerializeField] EventReference exitSfx;
    public void EnterAnimations()
    {
        AudioManager.instancia.PlayOneShot(enterSfx);
    }
    public void ExitAnimations()
    {
        AudioManager.instancia.PlayOneShot(exitSfx);
    }
}
