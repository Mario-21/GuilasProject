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
    PlayerHere player;

    public int oneSound;
    private void Awake()
    {
        player = GetComponent<PlayerHere>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (player.playerImHere) CambiarZonaSound();
    }
    void CambiarZonaSound()
    {
        switch (zonaDefinition)
        {
            case TypeZona.ActionPlayer:
                if (Input.GetButtonDown("Action"))
                {
                    AudioManager.instancia.PlayOneShot(zonaSound);
                }
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
