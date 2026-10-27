using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LuzSound : MonoBehaviour
{
    private void OnEnable()
    {
        AudioManager.instancia.PlayOneShot(FMODEvent.instancia.failLight);
    }
}
