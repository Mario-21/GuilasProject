    using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;
public class TriggerSoundEffect : MonoBehaviour
{
    [Header("Sonido Trigger")]
    public EventReference sonidoAction;
    bool reproducirSonido;
    void Update()
    {
        if (reproducirSonido)
        {
            AudioManager.instancia.PlayOneShot(sonidoAction);
            reproducirSonido = false;
            this.enabled = false;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            reproducirSonido = true;
        }
    }
}
