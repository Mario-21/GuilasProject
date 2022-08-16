using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorQuarry : MonoBehaviour
{
    public int indexMod;
    [SerializeField] AscensorMinero quarryElevator;
    void Start()
    {
        if(SaveScene.instancia.listaItemsNivelGuardar[indexMod].objetoObtenido)
        {
            quarryElevator.enabled = true;
            this.enabled = false;
        }
    }
}
