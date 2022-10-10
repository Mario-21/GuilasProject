using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorSafeCollider : MonoBehaviour
{
    public int indexMod;

    //Nota Quiza cambiar más adelante para que en vez un collider sea un objeto y poder usar lo de manera más abierta
    [SerializeField] BoxCollider2D doorSafe;
    void Update()
    {
        DoorSafeOpen();
    }
    void DoorSafeOpen()
    {
        if (StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion)
        {
            doorSafe.enabled = false;
            this.enabled = false;
        }
    }
}
