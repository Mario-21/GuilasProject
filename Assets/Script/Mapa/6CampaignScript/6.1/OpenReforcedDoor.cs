using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenReforcedDoor : MonoBehaviour
{
    public int indexMod;

    [SerializeField] Camino_CambiarZona doorClose;

    [HideInInspector] public int keys;
    public int totalKeys;
    

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
            doorClose.enabled = true;
            StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion = true;
        }

    }
}
