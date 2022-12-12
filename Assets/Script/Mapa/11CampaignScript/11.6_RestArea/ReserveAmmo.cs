using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReserveAmmo : MonoBehaviour
{
    public int indexAmmo;
    public int indexRejillaAscensor;
    public ArmaController arma;
    public GameObject ammo;
    void Start()
    {
        if(arma.municionTotal <= 0 && StatusGameobjectsVariables.statusGameobject.modificacion[indexRejillaAscensor].modificacion)
        {
            //Colocar si no tienes el B8
            //Esto se hace por si te quedas sin municion y no has roto la rejilla del ascensor.
            //Dado que es una zona principal aquí siempre tendras este spot de municion infinita, pero sin abusar.
            AmmoRecoveryList.ammoFromLevel.ammo[indexAmmo] = false;
            ammo.SetActive(true);

        }
    }
}
