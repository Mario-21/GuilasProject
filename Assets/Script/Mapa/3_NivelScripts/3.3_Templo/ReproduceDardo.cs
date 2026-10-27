using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;
public class ReproduceDardo : MonoBehaviour
{
    StudioEventEmitter emitter;

    private void Start()
    {
        emitter = AudioManager.instancia.InitializeEventEmitter(FMODEvent.instancia.dardoImpact, this.gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Dardo"))
        {
            emitter.Play();
        }
    }
}
