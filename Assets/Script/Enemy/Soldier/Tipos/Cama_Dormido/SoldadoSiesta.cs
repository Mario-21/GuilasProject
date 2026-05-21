using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;


public class SoldadoSiesta : MonoBehaviour
{
    //El sonido de despertar
    public GameObject particlesDormir;
    public StudioEventEmitter emiterSiesta;
    public EventReference despertarSiestaSound;
    public void DespertarSiesta()
    {
        particlesDormir.SetActive(false);
        emiterSiesta.enabled = false;
        AudioManager.instancia.PlayOneShot(despertarSiestaSound);
    }
}
