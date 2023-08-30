using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompuertaSound : MonoBehaviour
{
    public void SoundCompuerta()
    {
        AudioManager.instancia.PlayOneShot(FMODEvent.instancia.compuertaFood);
    }
}
