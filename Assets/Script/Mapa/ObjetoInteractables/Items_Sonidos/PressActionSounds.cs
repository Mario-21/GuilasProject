using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

[RequireComponent(typeof(PlayerHere))]
public class PressActionSounds : MonoBehaviour
{
    [Header("Sonido PlayOneShot")]
    public EventReference sonidoAction;
    [Header("Sonido Emissor")]
    public EventReference sonidoEmissor;
    public StudioEventEmitter emissorAction;
    public GameObject itemEmissor;
    public enum Type_Sound
    {
        PlayOneShot,
        Emisor,
        Default
    }
    public Type_Sound sonidoTipo;

    public bool action;
    PlayerHere player;
    private void Awake()
    {
        player = GetComponent<PlayerHere>();
    }
    void Start()
    {
        switch (sonidoTipo)
        {
            case Type_Sound.PlayOneShot:
                Debug.Log("Soy PlayOneShot y no tengo que asignar nada");
                break;
            case Type_Sound.Emisor:
                emissorAction = AudioManager.instancia.InitializeEventEmitter(sonidoEmissor, itemEmissor);
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(player.playerImHere) PressAction();
    }
    void PressAction()
    {
        if (Input.GetButtonDown("Action"))
        {
            action = !action;

            if (action)
            {
                switch (sonidoTipo)
                {
                    case Type_Sound.PlayOneShot:
                        AudioManager.instancia.PlayOneShot(sonidoAction);
                        break;
                    case Type_Sound.Emisor:
                        AudioManager.instancia.PlayOneShot(sonidoAction);
                        emissorAction.Play();
                        break;
                }
            }
            else
            {
                switch (sonidoTipo)
                {
                    case Type_Sound.PlayOneShot:
                        AudioManager.instancia.PlayOneShot(sonidoAction);
                        break;
                    case Type_Sound.Emisor:
                        AudioManager.instancia.PlayOneShot(sonidoAction);
                        emissorAction.Stop();
                        break;
                }
            }
        }
    }
}
