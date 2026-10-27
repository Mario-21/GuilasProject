using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;
public class PruebaSharkSound : MonoBehaviour
{
    StudioEventEmitter emissorShark;
    public EventReference sonido;

    public int source;
    void Start()
    {
        emissorShark = AudioManager.instancia.InitializeEventEmitter(sonido, this.gameObject);
        
    }

    // Update is called once per frame
    void Update()
    {
        if (source < 1)
        {
            emissorShark.Play();
            source++;
        }
    }
}
