using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class OpenReforcedDoor : MonoBehaviour
{
    public int indexMod;
    [Header("Door Private")]
    [SerializeField] Camino_CambiarZona doorClose;
    [Header("Keys Requirement")]
    [HideInInspector] public int keys;
    public int totalKeys;
    [Header("Sonido Desbloquear")]
    [SerializeField] EventReference unlockDoor;
    int unlockCheck;
    

    void Start()
    {
        if (StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion) doorClose.enabled = true;
    }

    // Update is called once per frame
    private void Update()
    {
        ConfirmedOpenDoor();
    }

    void ConfirmedOpenDoor()
    {

        if(keys == totalKeys)
        {
            if(unlockCheck < 1 && !StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion)
            {
                AudioManager.instancia.PlayOneShot(unlockDoor);
                unlockCheck++;
            }
            doorClose.enabled = true;
            StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion = true;
        }

    }
}
