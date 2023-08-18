using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

[RequireComponent(typeof(PlayerHere))]
public class ZonaChangeSound : MonoBehaviour
{
    public EventReference zonaSound;
    public enum TypeZona
    {
        ActionPlayer,
        TriggerPlayer,
        Default
    }
    public TypeZona zonaDefinition;

    int oneSound;
    public void CambiarZonaSound()
    {
        switch (zonaDefinition)
        {
            case TypeZona.ActionPlayer:
                AudioManager.instancia.PlayOneShot(zonaSound);
                break;
            case TypeZona.TriggerPlayer:
                if(oneSound < 1)
                {
                    AudioManager.instancia.PlayOneShot(zonaSound);
                    oneSound++;
                }
                break;
        }
    }
}
