using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class EmissorAction : MonoBehaviour
{
    public int indexAction;
    [Header("Tipo de Sonido")]
    public EventReference sonidoAction;
    [HideInInspector]public StudioEventEmitter emissorAction;
    void Start()
    {
        emissorAction = AudioManager.instancia.InitializeEventEmitter(sonidoAction, this.gameObject);
        if (StatusGameobjectsVariables.statusGameobject.modificacion[indexAction].modificacion)
        {
            emissorAction.Play();
        }
    }
}
